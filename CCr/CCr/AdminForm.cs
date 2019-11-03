using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminForm : CCr.AdminTemplate
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnhome_Click(object sender, EventArgs e){}

        private void btnhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(0, 0, 0);
            pbxhome.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void btnhome_MouseLeave(object sender, EventArgs e)
        {

            btnhome.BackColor = Color.FromArgb(37, 37, 37);
            pbxhome.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(37, 37, 37);
            pbxhome.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(0, 0, 0);
            pbxhome.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void btntemas_Click(object sender, EventArgs e)
        {

        }
    }
}
