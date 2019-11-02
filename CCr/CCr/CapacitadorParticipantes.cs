using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class CapacitadorParticipantes : CCr.CapacitadorTemplate
    {
        public CapacitadorParticipantes()
        {
            InitializeComponent();
        }

        private void CapacitadorParticipantes_Load(object sender, EventArgs e)
        {

        }

        private void btnParticipantes_MouseEnter(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(0, 0, 0);
            pbxParticipantes.BackColor = Color.FromArgb(0, 0, 0);
        }
    }
}
