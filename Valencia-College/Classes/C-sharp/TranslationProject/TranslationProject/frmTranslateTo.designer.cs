namespace TranslationProject
{
    partial class frmTranslateTo
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
            this.txtTranslateText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTranslateLanguage = new System.Windows.Forms.ComboBox();
            this.btnSwapLanguage = new System.Windows.Forms.Button();
            this.btnSwapText = new System.Windows.Forms.Button();
            this.btnTxt2Speech = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTranslateText
            // 
            this.txtTranslateText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranslateText.Location = new System.Drawing.Point(16, 40);
            this.txtTranslateText.Multiline = true;
            this.txtTranslateText.Name = "txtTranslateText";
            this.txtTranslateText.Size = new System.Drawing.Size(380, 412);
            this.txtTranslateText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Translate To:";
            // 
            // cmbTranslateLanguage
            // 
            this.cmbTranslateLanguage.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTranslateLanguage.FormattingEnabled = true;
            this.cmbTranslateLanguage.Items.AddRange(new object[] {
            "German",
            "Spanish",
            "English",
            "Dutch"});
            this.cmbTranslateLanguage.Location = new System.Drawing.Point(119, 6);
            this.cmbTranslateLanguage.Name = "cmbTranslateLanguage";
            this.cmbTranslateLanguage.Size = new System.Drawing.Size(143, 28);
            this.cmbTranslateLanguage.TabIndex = 2;
            // 
            // btnSwapLanguage
            // 
            this.btnSwapLanguage.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapLanguage.Location = new System.Drawing.Point(296, 9);
            this.btnSwapLanguage.Name = "btnSwapLanguage";
            this.btnSwapLanguage.Size = new System.Drawing.Size(28, 23);
            this.btnSwapLanguage.TabIndex = 3;
            this.btnSwapLanguage.UseVisualStyleBackColor = true;
            // 
            // btnSwapText
            // 
            this.btnSwapText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapText.Location = new System.Drawing.Point(330, 9);
            this.btnSwapText.Name = "btnSwapText";
            this.btnSwapText.Size = new System.Drawing.Size(28, 23);
            this.btnSwapText.TabIndex = 4;
            this.btnSwapText.UseVisualStyleBackColor = true;
            // 
            // btnTxt2Speech
            // 
            this.btnTxt2Speech.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTxt2Speech.Location = new System.Drawing.Point(364, 9);
            this.btnTxt2Speech.Name = "btnTxt2Speech";
            this.btnTxt2Speech.Size = new System.Drawing.Size(28, 23);
            this.btnTxt2Speech.TabIndex = 5;
            this.btnTxt2Speech.UseVisualStyleBackColor = true;
            // 
            // frmTranslateTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 467);
            this.Controls.Add(this.btnTxt2Speech);
            this.Controls.Add(this.btnSwapText);
            this.Controls.Add(this.btnSwapLanguage);
            this.Controls.Add(this.cmbTranslateLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTranslateText);
            this.Name = "frmTranslateTo";
            this.Text = "Translated Text Popout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClose);
            this.Load += new System.EventHandler(this.formStartup);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTranslateText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTranslateLanguage;
        private System.Windows.Forms.Button btnSwapLanguage;
        private System.Windows.Forms.Button btnSwapText;
        private System.Windows.Forms.Button btnTxt2Speech;
    }
}