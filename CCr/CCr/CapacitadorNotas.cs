using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class CapacitadorNotas : CCr.CapacitadorTemplate
    {
        public CapacitadorNotas()
        {
            InitializeComponent();
        }

        private void btnNotas_MouseEnter(object sender, EventArgs e)
        {
            btnNotas.BackColor = Color.Black;
            pbxNotas.BackColor = Color.Black;
        }

        private void pbxNotas_Click(object sender, EventArgs e)
        {

        }

        private void CapacitadorNotas_Load(object sender, EventArgs e)
        {

        }
    }
}
