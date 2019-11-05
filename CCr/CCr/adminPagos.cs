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
    public partial class adminPagos : AdminTemplate
    {
        public adminPagos()
        {
            InitializeComponent();
        }

        private void adminPagos_Load(object sender, EventArgs e)
        {

        }

        private void btnpagos_MouseLeave(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(37, 37, 37);
            pbxpagos.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxpagos_MouseLeave(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(37, 37, 37);
            pbxpagos.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btnpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(0, 0, 0);
            pbxpagos.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(0, 0, 0);
            pbxpagos.BackColor = Color.FromArgb(0, 0, 0);
        }
    }
}
