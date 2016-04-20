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
    public partial class splshLoad : Form
    {
        public splshLoad()
        {
            InitializeComponent();
        }

        private void splshLoad_Load(object sender, EventArgs e)
        {
            Timer load = new Timer();

            load.Enabled = true;
            load.Interval = 100;
            load.Tick += new EventHandler(this.TickEvent);
        }

        private void TickEvent(object o, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.PerformStep();
            }
            else
            {
                progressBar1.PerformStep();
                this.Close();
            }
        }
    }
}
