using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

namespace ForvoDownloader
{
    public partial class MainForm : Form
    {
        private readonly Forvo forvo = new Forvo();

        public MainForm()
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

        private void buttonDownload_Click(object sender, EventArgs e)
        {

            if (!ValidateForm())
            {
                MessageBox.Show("Please fill all the fields.", "Error");
                return;
            }

            disableDownloadButton();


            LanguageItem language = (LanguageItem)comboBoxLanguageList.SelectedItem;
            forvo.Language = language.Code;
            string[] wordsTxt = textBoxWords.Text.Trim().Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            initializeProgressBar(wordsTxt.Length);

            Stack<string> wordsNotDownloaded = new Stack<string>();

            using (var errorWriter = new StreamWriter(Path.Combine(textBoxOutputDir.Text, "errors.txt"), true))
            using (var writer = new StreamWriter(Path.Combine(textBoxOutputDir.Text, "words.tsv"), true))
            using (var webClient = new WebClient())
            {
                foreach (string wordTxt in wordsTxt)
                {
                    progressBar.PerformStep();
                    Application.DoEvents();
                    progressBar.Text = wordTxt;
                    var word = new Word(wordTxt.ToLower());
                    try
                    {
                        WordPronunciation wordPronunciation = forvo.GetBestPronunciation(word.ToString());
                        
                        if (wordPronunciation != null)
                        {
                            string filename = Path.Combine(textBoxOutputDir.Text, word + ".mp3");
                            webClient.DownloadFile(wordPronunciation.PathMp3, filename);
                            writer.WriteLine(word + "\t" + word + ".mp3");
                        }
                        else
                        {
                            errorWriter.WriteLine("Couldn't download the word:" + word);
                            wordsNotDownloaded.Push(word.ToString());
                        }
                    }
                        // The word doesn't exists
                    catch (RuntimeBinderException ex)
                    {
                        errorWriter.WriteLine("Couldn't download the word:" + word);
                        errorWriter.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        //log the error
                        errorWriter.WriteLine("Couldn't download the word:" + word);
                        wordsNotDownloaded.Push(word.ToString());
                        errorWriter.WriteLine(ex.Message);
                    }
                }
            }
            textBoxWords.Text = "";
            if (wordsNotDownloaded.Count > 0)
            {
                MessageBox.Show(caption: "Done!", text: "Download complete!\nSome words couldn't downloaded");
                FilltextBoxWords(wordsNotDownloaded);
            }
            else
            {
                MessageBox.Show(caption: "Done!", text: "Download complete!");
            }

            progressBar.Visible = false;
            enableDownloadButton();
        }

        private void disableDownloadButton()
        {
            buttonDownload.Text = "Downloading";
            buttonDownload.Enabled = false;
        }

        private void enableDownloadButton()
        {
            buttonDownload.Text = "Download";
            buttonDownload.Enabled = true;
        }

        private void initializeProgressBar(int len)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = len;
            progressBar.Value = 1;
            progressBar.Step = 1;
            
        }

        private void FilltextBoxWords(Stack<string> wordsNotDownloaded)
        {
            var sb = new StringBuilder();
            foreach (string word in wordsNotDownloaded)
            {
                sb.Append(word + Environment.NewLine);
            }
            textBoxWords.Text = sb.ToString().Trim();
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
            Contract.EndContractBlock();
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