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
    //Same as frmTranslateFrom
    public partial class frmTranslateTo : Form
    {
        public frmTranslateTo()
        {
            InitializeComponent();
        }

        public frmTranslateTo(Font style, object enumeration)
        {
            txtTranslateText.Font = style;
            label1.Font = style;
            cmbTranslateLanguage.SelectedItem = enumeration;
            this.Invalidate();
        }

        private void formStartup(object sender, EventArgs e)
        {
            this.Height = 505;
            this.Width = 420;

            txtTranslateText.Width = Convert.ToInt32(this.Width * .895);
            txtTranslateText.Height = Convert.ToInt32(this.Height * .822);
        }

        private void formClose(object o, FormClosingEventArgs f)
        {
            Tag += txtTranslateText.Text;
        }
    }
}
