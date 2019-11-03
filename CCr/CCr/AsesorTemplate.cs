using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AsesorTemplate : CCr.Template
    {
        public AsesorTemplate()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(160, 3, 3);
            pbxhome.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btnhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(115, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(140, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            new AsesorForm().Show();
            this.Hide();
        }

        private void btntemas_MouseLeave(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(160, 3, 3);
            pbxtemas.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btntemas_MouseEnter(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(115, 3, 3);
            pbxtemas.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxtemas_MouseEnter(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(140, 3, 3);
            pbxtemas.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnempresas_MouseEnter(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(115, 3, 3);
            pbxempresa.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxempresa_MouseEnter(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(140, 3, 3);
            pbxempresa.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxempresa_MouseLeave(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(160, 3, 3);
            pbxempresa.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btnpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(115, 3, 3);
            pbxpagos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(140, 3, 3);
            pbxpagos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxpagos_MouseLeave(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(160, 3, 3);
            pbxpagos.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btnpagos_Click(object sender, EventArgs e)
        {

        }

        private void btncontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(115, 3, 3);
            pbxcontactos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxcontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(140, 3, 3);
            pbxcontactos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxcontactos_MouseLeave(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(160, 3, 3);
            pbxcontactos.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btnParticipantes_MouseEnter(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(115, 3, 3);
            pbxParticipantes.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxParticipantes_MouseEnter(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(140, 3, 3);
            pbxParticipantes.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxParticipantes_MouseLeave(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(160, 3, 3);
            pbxParticipantes.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btnCapacitaciones_MouseEnter(object sender, EventArgs e)
        {
            btnCapacitaciones.BackColor = Color.FromArgb(115, 3, 3);
            pbxCapacitaciones.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxCapacitaciones_MouseEnter(object sender, EventArgs e)
        {
            btnCapacitaciones.BackColor = Color.FromArgb(140, 3, 3);
            pbxCapacitaciones.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxCapacitaciones_MouseLeave(object sender, EventArgs e)
        {
            btnCapacitaciones.BackColor = Color.FromArgb(160, 3, 3);
            pbxCapacitaciones.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btnCertificados_MouseEnter(object sender, EventArgs e)
        {
            btnCertificados.BackColor = Color.FromArgb(115, 3, 3);
            pbxCertificados.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxCertificados_MouseEnter(object sender, EventArgs e)
        {
            btnCertificados.BackColor = Color.FromArgb(140, 3, 3);
            pbxCertificados.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxCertificados_MouseLeave(object sender, EventArgs e)
        {
            btnCertificados.BackColor = Color.FromArgb(160, 3, 3);
            pbxCertificados.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void btncerrar_MouseEnter(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.FromArgb(115, 3, 3);
            pbxcerrar.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxcerrar_MouseEnter(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.FromArgb(140, 3, 3);
            pbxcerrar.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxcerrar_MouseLeave(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.FromArgb(160, 3, 3);
            pbxcerrar.BackColor = Color.FromArgb(160, 3, 3);
        }

        private void AsesorTemplate_Load(object sender, EventArgs e)
        {
            Class.Usuarios us = new Class.Usuarios();
            Class.Conexion conexionSQL = new Class.Conexion();
            conexionSQL.startConnection();
            us = us.getUser(3);
            conexionSQL.closeConnection();
            lblUsername.Text = us.NombreUsuario.ToString();

            if (us.Descripcion == "3")
            {
                lblTypeUser.Text = "Asesor";
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (MessageBox.Show("¿Estas seguro que deseas cerrar sesion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class.Usuarios.Id = "";
                log.Show();
                this.Hide();
            }
        }
    }
}
