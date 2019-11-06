using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AsesorForm : CCr.AsesorTemplate
    {
        public AsesorForm()
        {
            InitializeComponent();
        }

        private void btnhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(0, 0, 0);
            pbxhome.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {

        }

        private void pbxcerrar_Click(object sender, EventArgs e)
        {

        }

        private void btnParticipantes_Click(object sender, EventArgs e)
        {

        }
    }
}
