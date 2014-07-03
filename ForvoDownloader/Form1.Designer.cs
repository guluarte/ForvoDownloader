namespace ForvoDownloader
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDownload = new System.Windows.Forms.Button();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOutputDir = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxLanguageList = new System.Windows.Forms.ComboBox();
            this.buttonLoadLanguageList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelNumWords = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(345, 371);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(26, 36);
            this.textBoxApiKey.MaxLength = 32;
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(389, 20);
            this.textBoxApiKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "apikey:";
            // 
            // textBoxWords
            // 
            this.textBoxWords.Location = new System.Drawing.Point(26, 167);
            this.textBoxWords.Multiline = true;
            this.textBoxWords.Name = "textBoxWords";
            this.textBoxWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxWords.Size = new System.Drawing.Size(394, 182);
            this.textBoxWords.TabIndex = 3;
            this.textBoxWords.TextChanged += new System.EventHandler(this.textBoxWords_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Words:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output dir:";
            // 
            // textBoxOutputDir
            // 
            this.textBoxOutputDir.Location = new System.Drawing.Point(26, 79);
            this.textBoxOutputDir.Name = "textBoxOutputDir";
            this.textBoxOutputDir.Size = new System.Drawing.Size(309, 20);
            this.textBoxOutputDir.TabIndex = 6;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(345, 76);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 7;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Language:";
            // 
            // comboBoxLanguageList
            // 
            this.comboBoxLanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguageList.FormattingEnabled = true;
            this.comboBoxLanguageList.Location = new System.Drawing.Point(26, 118);
            this.comboBoxLanguageList.Name = "comboBoxLanguageList";
            this.comboBoxLanguageList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguageList.TabIndex = 9;
            // 
            // buttonLoadLanguageList
            // 
            this.buttonLoadLanguageList.Location = new System.Drawing.Point(154, 115);
            this.buttonLoadLanguageList.Name = "buttonLoadLanguageList";
            this.buttonLoadLanguageList.Size = new System.Drawing.Size(115, 23);
            this.buttonLoadLanguageList.TabIndex = 11;
            this.buttonLoadLanguageList.Text = "Load Language List";
            this.buttonLoadLanguageList.UseVisualStyleBackColor = true;
            this.buttonLoadLanguageList.Click += new System.EventHandler(this.buttonLoadLanguageList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Num Words:";
            // 
            // labelNumWords
            // 
            this.labelNumWords.AutoSize = true;
            this.labelNumWords.Location = new System.Drawing.Point(99, 356);
            this.labelNumWords.Name = "labelNumWords";
            this.labelNumWords.Size = new System.Drawing.Size(13, 13);
            this.labelNumWords.TabIndex = 13;
            this.labelNumWords.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 405);
            this.Controls.Add(this.labelNumWords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonLoadLanguageList);
            this.Controls.Add(this.comboBoxLanguageList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxOutputDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.buttonDownload);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "ForvoDownloader";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOutputDir;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxLanguageList;
        private System.Windows.Forms.Button buttonLoadLanguageList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelNumWords;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

