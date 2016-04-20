namespace TranslationProject
{
    partial class frmTranslateFrom
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
            this.cmbTranslateLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTranslateText = new System.Windows.Forms.TextBox();
            this.btnTxt2Speech = new System.Windows.Forms.Button();
            this.btnSwapText = new System.Windows.Forms.Button();
            this.btnSwapLanguage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbTranslateLanguage
            // 
            this.cmbTranslateLanguage.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTranslateLanguage.FormattingEnabled = true;
            this.cmbTranslateLanguage.Items.AddRange(new object[] {
            "Select...",
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
            this.cmbTranslateLanguage.Location = new System.Drawing.Point(119, 6);
            this.cmbTranslateLanguage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbTranslateLanguage.Name = "cmbTranslateLanguage";
            this.cmbTranslateLanguage.Size = new System.Drawing.Size(143, 28);
            this.cmbTranslateLanguage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Translate From:";
            // 
            // txtTranslateText
            // 
            this.txtTranslateText.Location = new System.Drawing.Point(16, 43);
            this.txtTranslateText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTranslateText.Multiline = true;
            this.txtTranslateText.Name = "txtTranslateText";
            this.txtTranslateText.Size = new System.Drawing.Size(376, 447);
            this.txtTranslateText.TabIndex = 2;
            // 
            // btnTxt2Speech
            // 
            this.btnTxt2Speech.Location = new System.Drawing.Point(364, 10);
            this.btnTxt2Speech.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTxt2Speech.Name = "btnTxt2Speech";
            this.btnTxt2Speech.Size = new System.Drawing.Size(28, 25);
            this.btnTxt2Speech.TabIndex = 5;
            this.btnTxt2Speech.UseVisualStyleBackColor = true;
            // 
            // btnSwapText
            // 
            this.btnSwapText.Location = new System.Drawing.Point(330, 10);
            this.btnSwapText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSwapText.Name = "btnSwapText";
            this.btnSwapText.Size = new System.Drawing.Size(28, 25);
            this.btnSwapText.TabIndex = 3;
            this.btnSwapText.UseVisualStyleBackColor = true;
            // 
            // btnSwapLanguage
            // 
            this.btnSwapLanguage.Location = new System.Drawing.Point(296, 10);
            this.btnSwapLanguage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSwapLanguage.Name = "btnSwapLanguage";
            this.btnSwapLanguage.Size = new System.Drawing.Size(28, 25);
            this.btnSwapLanguage.TabIndex = 4;
            this.btnSwapLanguage.UseVisualStyleBackColor = true;
            // 
            // frmTranslateFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 503);
            this.Controls.Add(this.btnTxt2Speech);
            this.Controls.Add(this.btnSwapLanguage);
            this.Controls.Add(this.btnSwapText);
            this.Controls.Add(this.txtTranslateText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTranslateLanguage);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmTranslateFrom";
            this.Text = "Original Text Popout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClose);
            this.Load += new System.EventHandler(this.formStartup);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTranslateLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTranslateText;
        private System.Windows.Forms.Button btnTxt2Speech;
        private System.Windows.Forms.Button btnSwapText;
        private System.Windows.Forms.Button btnSwapLanguage;
    }
}