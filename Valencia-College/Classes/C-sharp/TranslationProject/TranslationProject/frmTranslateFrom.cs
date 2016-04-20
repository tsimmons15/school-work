using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TranslationProject
{
    public partial class frmTranslateFrom : Form
    {
        public frmTranslateFrom()
        {
            InitializeComponent();
        }
        
        //Reset the form, to update with the new styles.
        public frmTranslateFrom(Font style, object enumeration)
        {
            txtTranslateText.Font = style;
            label1.Font = style;
            cmbTranslateLanguage.SelectedItem = enumeration;
            this.Invalidate();
        }

        //On startup, make sure the form is set to go
        private void formStartup(object sender, EventArgs e)
        {
            this.Height = 505;
            this.Width = 420;

            txtTranslateText.Width = Convert.ToInt32(this.Width * .895);
            txtTranslateText.Height = Convert.ToInt32(this.Height * .822);
            cmbTranslateLanguage.SelectedIndex = 0;

            txtTranslateText.Text = txtTranslateText.Font.ToString();
        }

        //Transfer text from this form to frmTranslateMain
        private void formClose(object o, FormClosingEventArgs f)
        {
            this.Tag = txtTranslateText.Text;
        }
    }
}
