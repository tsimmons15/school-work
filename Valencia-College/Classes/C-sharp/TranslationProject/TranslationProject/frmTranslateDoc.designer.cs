namespace TranslationProject
{
    partial class frmTranslateDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranslateDoc));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.txtDocOrigin = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBrowseOrigin = new System.Windows.Forms.Button();
            this.btnBrowseSaveTo = new System.Windows.Forms.Button();
            this.diaFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.diaFileSave = new System.Windows.Forms.SaveFileDialog();
            this.chkAutoInsert = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTranslateTo = new System.Windows.Forms.ComboBox();
            this.cmbTranslateFrom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original Document";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Save to Location";
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(12, 112);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.Size = new System.Drawing.Size(245, 20);
            this.txtSaveTo.TabIndex = 2;
            // 
            // txtDocOrigin
            // 
            this.txtDocOrigin.Location = new System.Drawing.Point(12, 25);
            this.txtDocOrigin.Name = "txtDocOrigin";
            this.txtDocOrigin.Size = new System.Drawing.Size(248, 20);
            this.txtDocOrigin.TabIndex = 1;
            this.txtDocOrigin.Leave += new System.EventHandler(this.updateSaveTo);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(12, 138);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(75, 23);
            this.btnTranslate.TabIndex = 4;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.TranslateDocument);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(198, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.closeForm);
            // 
            // btnBrowseOrigin
            // 
            this.btnBrowseOrigin.Location = new System.Drawing.Point(258, 23);
            this.btnBrowseOrigin.Name = "btnBrowseOrigin";
            this.btnBrowseOrigin.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseOrigin.TabIndex = 6;
            this.btnBrowseOrigin.Text = "...";
            this.btnBrowseOrigin.UseVisualStyleBackColor = true;
            this.btnBrowseOrigin.Click += new System.EventHandler(this.RequestFile);
            // 
            // btnBrowseSaveTo
            // 
            this.btnBrowseSaveTo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSaveTo.Location = new System.Drawing.Point(255, 110);
            this.btnBrowseSaveTo.Name = "btnBrowseSaveTo";
            this.btnBrowseSaveTo.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseSaveTo.TabIndex = 7;
            this.btnBrowseSaveTo.Text = "...";
            this.btnBrowseSaveTo.UseVisualStyleBackColor = true;
            this.btnBrowseSaveTo.Click += new System.EventHandler(this.RequestFile);
            // 
            // diaFileOpen
            // 
            this.diaFileOpen.DefaultExt = "txt";
            // 
            // diaFileSave
            // 
            this.diaFileSave.DefaultExt = "txt";
            this.diaFileSave.ShowHelp = true;
            // 
            // chkAutoInsert
            // 
            this.chkAutoInsert.AutoSize = true;
            this.chkAutoInsert.Checked = true;
            this.chkAutoInsert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoInsert.Location = new System.Drawing.Point(103, 92);
            this.chkAutoInsert.Name = "chkAutoInsert";
            this.chkAutoInsert.Size = new System.Drawing.Size(167, 17);
            this.chkAutoInsert.TabIndex = 8;
            this.chkAutoInsert.Text = "Auto-Insert Save-to File Path?";
            this.chkAutoInsert.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Translate To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Translate From:";
            // 
            // cmbTranslateTo
            // 
            this.cmbTranslateTo.FormattingEnabled = true;
            this.cmbTranslateTo.Items.AddRange(new object[] {
            "Select A Language...",
            "Arabic",
            "Bulgarian",
            "Catalan",
            "Chinese(Simplified)",
            "Chinese(Traditional)",
            "Czech",
            "Danish",
            "Dutch",
            "English",
            "Estonian",
            "Finnish",
            "French",
            "German",
            "Greek",
            "Haitian Creole",
            "Hebrew",
            "Hindi",
            "Hmong Daw",
            "Hungarian",
            "Indonesian",
            "Italian",
            "Japanese",
            "Korean",
            "Latvian",
            "Lithuanian",
            "Norwegian",
            "Persian(Farsi)",
            "Polish",
            "Portuguese",
            "Romanian",
            "Russian",
            "Slovak",
            "Slovenian",
            "Spanish",
            "Swedish",
            "Thai",
            "Turkish",
            "Ukrainian",
            "Vietnamese"});
            this.cmbTranslateTo.Location = new System.Drawing.Point(95, 71);
            this.cmbTranslateTo.Name = "cmbTranslateTo";
            this.cmbTranslateTo.Size = new System.Drawing.Size(138, 21);
            this.cmbTranslateTo.TabIndex = 11;
            // 
            // cmbTranslateFrom
            // 
            this.cmbTranslateFrom.FormattingEnabled = true;
            this.cmbTranslateFrom.Items.AddRange(new object[] {
            "Select A Language...",
            "Arabic",
            "Bulgarian",
            "Catalan",
            "Chinese(Simplified)",
            "Chinese(Traditional)",
            "Czech",
            "Danish",
            "Dutch",
            "English",
            "Estonian",
            "Finnish",
            "French",
            "German",
            "Greek",
            "Haitian Creole",
            "Hebrew",
            "Hindi",
            "Hmong Daw",
            "Hungarian",
            "Indonesian",
            "Italian",
            "Japanese",
            "Korean",
            "Latvian",
            "Lithuanian",
            "Norwegian",
            "Persian(Farsi)",
            "Polish",
            "Portuguese",
            "Romanian",
            "Russian",
            "Slovak",
            "Slovenian",
            "Spanish",
            "Swedish",
            "Thai",
            "Turkish",
            "Ukrainian",
            "Vietnamese"});
            this.cmbTranslateFrom.Location = new System.Drawing.Point(94, 47);
            this.cmbTranslateFrom.Name = "cmbTranslateFrom";
            this.cmbTranslateFrom.Size = new System.Drawing.Size(138, 21);
            this.cmbTranslateFrom.TabIndex = 12;
            // 
            // frmTranslateDoc
            // 
            this.AcceptButton = this.btnTranslate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.cmbTranslateFrom);
            this.Controls.Add(this.cmbTranslateTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseOrigin);
            this.Controls.Add(this.chkAutoInsert);
            this.Controls.Add(this.btnBrowseSaveTo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txtDocOrigin);
            this.Controls.Add(this.txtSaveTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTranslateDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTranslateDoc";
            this.Load += new System.EventHandler(this.appStart);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.TextBox txtDocOrigin;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBrowseOrigin;
        private System.Windows.Forms.Button btnBrowseSaveTo;
        private System.Windows.Forms.OpenFileDialog diaFileOpen;
        private System.Windows.Forms.SaveFileDialog diaFileSave;
        private System.Windows.Forms.CheckBox chkAutoInsert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTranslateTo;
        private System.Windows.Forms.ComboBox cmbTranslateFrom;
    }
}