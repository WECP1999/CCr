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
    public partial class adminCertificados : AdminTemplate
    {
        public adminCertificados()
        {
            InitializeComponent();
        }

        private void adminCertificados_Load(object sender, EventArgs e)
        {

        }

        private void btnCertificados_MouseLeave(object sender, EventArgs e)
        {
            btnCertificados.BackColor = Color.FromArgb(37, 37, 37);
            pbxCertificados.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btnCertificados_MouseEnter(object sender, EventArgs e)
        {
            btnCertificados.BackColor = Color.FromArgb(0, 0, 0);
            pbxCertificados.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxCertificados_MouseLeave(object sender, EventArgs e)
        {
            btnCertificados.BackColor = Color.FromArgb(37, 37, 37);
            pbxCertificados.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxCertificados_MouseEnter(object sender, EventArgs e)
        {
            btnCertificados.BackColor = Color.FromArgb(0, 0, 0);
            pbxCertificados.BackColor = Color.FromArgb(0, 0, 0);
        }
    }
}
