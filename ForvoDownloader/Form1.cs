using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ForvoDownloader
{
    public partial class MainWindow : Form
    {
        private readonly Forvo forvo = new Forvo();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            /*
             * Add the most common languages
             * */
            comboBoxLanguageList.Items.Add(new LanguageItem("English", "en"));
            comboBoxLanguageList.Items.Add(new LanguageItem("Spanish", "es"));
            comboBoxLanguageList.Items.Add(new LanguageItem("French", "fr"));
            comboBoxLanguageList.Items.Add(new LanguageItem("Italian", "it"));
            comboBoxLanguageList.Items.Add(new LanguageItem("German", "de"));
            comboBoxLanguageList.Sorted = true;
        }

        private void btnSetApiKey_Click(object sender, EventArgs e)
        {
        }

        private void buttonLoadLanguageList_Click(object sender, EventArgs e)
        {
            if (!SetForvoApi())
            {
                return;
            }
 
            try
            {
                Dictionary<string, string> languagePairs = forvo.GetLanguageList();
                comboBoxLanguageList.Items.Clear();
                foreach (string languageCode in languagePairs.Keys)
                {
                    comboBoxLanguageList.Items.Add(new LanguageItem(languagePairs[languageCode], languageCode));
                }
                MessageBox.Show("Languages loaded", "Languages");
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading language list", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!ValidateForm())
            {
                MessageBox.Show("Please fill all the fields.", "Error");
                return;
            }
            
            LanguageItem language = (LanguageItem)comboBoxLanguageList.SelectedItem;
            forvo.Language = language.Code;
            string[] wordsTxt = textBoxWords.Text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            using (var errorWriter = new StreamWriter(Path.Combine(textBoxOutputDir.Text, "errors.txt")))
            using (var writer = new StreamWriter(Path.Combine(textBoxOutputDir.Text, "words.tsv")))
            using (var webClient = new WebClient())
            {
                foreach (string wordTxt in wordsTxt)
                {
                    var word = new Word(wordTxt.ToLower());
                    try
                    {
                        word.Pronunciations = forvo.GetListWordPronunciations(word);
                        WordPronunciation pronunciation = word.GetBestPronunciation();
                        if (pronunciation != null)
                        {
                            string filename = Path.Combine(textBoxOutputDir.Text, word + ".mp3");
                            webClient.DownloadFile(pronunciation.PathMp3, filename);
                            writer.WriteLine(word + "\t" + word + ".mp3");
                        }
                        else
                        {
                            errorWriter.WriteLine("Couldn't download the word:" + word);
                        }
                    }
                    catch (Exception ex)
                    {
                        //log the error
                        errorWriter.WriteLine("Couldn't download the word:" + word);
                        errorWriter.WriteLine(ex.Message);
                    }
                }
            }

            MessageBox.Show("Done!", "Download complete!");
        }

        private bool SetForvoApi()
        {
            try
            {
                forvo.Apikey = textBoxApiKey.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid API");
                return false;
            }

            return true;

        }


        private bool ValidateForm()
        {
            if (!SetForvoApi())
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(comboBoxLanguageList.Text))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBoxOutputDir.Text))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBoxWords.Text))
            {
                return false;
            }

            return true;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBoxOutputDir.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void textBoxWords_TextChanged(object sender, EventArgs e)
        {
            int numWords = textBoxWords.Text.Split(new[] {Environment.NewLine}, StringSplitOptions.None).Count();
            labelNumWords.Text = numWords.ToString();
            if (numWords > 500)
            {
                labelNumWords.ForeColor = Color.Red;
            }
            else
            {
                labelNumWords.ResetForeColor();
            }
        }
    }
}