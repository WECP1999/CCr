using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class CapacitadorTemplate : CCr.Template
    {
        public CapacitadorTemplate()
        {
            InitializeComponent();
        }

        private void btnhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(115, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(163, 3, 3);
            pbxhome.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(140, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(163, 3, 3);
            pbxhome.BackColor = Color.FromArgb(163, 3, 3);
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

        private void pbxcerrar_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (MessageBox.Show("¿Estas seguro que deseas cerrar sesion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class.Usuarios.Id = "";
                log.Show();
                this.Hide();
            }
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
            btncerrar.BackColor = Color.FromArgb(163, 3, 3);
            pbxcerrar.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            new CapacitadorNotas().Show();
            this.Hide();
        }

        private void btnNotas_MouseEnter(object sender, EventArgs e)
        {
            btnNotas.BackColor = Color.FromArgb(115, 3, 3);
            pbxNotas.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxNotas_MouseEnter(object sender, EventArgs e)
        {
            btnNotas.BackColor = Color.FromArgb(140, 3, 3);
            pbxNotas.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxNotas_MouseLeave(object sender, EventArgs e)
        {
            btnNotas.BackColor = Color.FromArgb(163, 3, 3);
            pbxNotas.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btnParticipantes_MouseEnter(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(115, 3, 3);
            pbxParticipantes.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnParticipantes_MouseLeave(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(163, 3, 3);
            pbxParticipantes.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxParticipantes_MouseEnter(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(140, 3, 3);
            pbxParticipantes.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void CapacitadorTemplate_Load(object sender, EventArgs e)
        {
            Class.Usuarios us = new Class.Usuarios();
            Class.Conexion conexionSQL = new Class.Conexion();
            conexionSQL.startConnection();
            us = us.getUser(int.Parse(Class.Usuarios.Id));
            conexionSQL.closeConnection();
            lblTypeUser.Text = us.NombreUsuario.ToString();

            if (us.Descripcion == "3")
            {
                lblUsername.Text = "Capacitador";
            }
            else
            {
                new Login().Show();
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            new CapacitadorForm().Show();
            this.Hide();
        }

        private void btnParticipantes_Click(object sender, EventArgs e)
        {
            new CapacitadorParticipantes().Show();
            this.Hide();
        }

        private void pbxParticipantes_Click(object sender, EventArgs e)
        {
            new CapacitadorParticipantes().Show();
            this.Hide();
        }
    }
}
