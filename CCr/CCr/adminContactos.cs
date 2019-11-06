using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCr
{
    public partial class adminContactos : AdminTemplate
    {
        public adminContactos()
        {
            InitializeComponent();
        }

        private void adminContactos_Load(object sender, EventArgs e)
        {

        }

        private void btncontactos_MouseLeave(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(37, 37, 37);
            pbxcontactos.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btncontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(0, 0, 0);
            pbxcontactos.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxcontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(0, 0, 0);
            pbxcontactos.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxcontactos_MouseLeave(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(37, 37, 37);
            pbxcontactos.BackColor = Color.FromArgb(37, 37, 37);
        }
    }
}
