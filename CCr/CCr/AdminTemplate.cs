using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminTemplate : CCr.Template
    {
        public AdminTemplate()
        {
            InitializeComponent();
        }

        private void AdminTemplate_Load(object sender, EventArgs e)
        {
            Class.Users us = new Class.Users();
            Class.Connection conexionSQL = new Class.Connection();
            conexionSQL.startConnection();
            us = us.getUser(1);
            conexionSQL.closeConnection();
            lblUsername.Text = us.Username.ToString();

            if (us.Description == "1")
            {
                lblTypeUser.Text = "Administrador";
            }
            else if(us.Description == "2")
            {
                lblTypeUser.Text = "Asesor";
            }
            else if (us.Description == "3")
            {
                lblTypeUser.Text = "Capacitador";
            }
        }
        private void pbxhome_Click(object sender, EventArgs e)
        {
            AdminForm ac = new AdminForm();
            ac.Show();
            this.Hide();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            AdminForm ac = new AdminForm();
            ac.Show();
            this.Hide();
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

        private void pbxhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(163, 3, 3);
            pbxhome.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(140, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btntemas_MouseEnter(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(115, 3, 3);
            pbxtemas.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btntemas_MouseLeave(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(163, 3, 3);
            pbxtemas.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxtemas_MouseEnter(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(140, 3, 3);
            pbxtemas.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxtemas_MouseLeave(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(163, 3, 3);
            pbxtemas.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btntemas_Click(object sender, EventArgs e)
        {
            crudSubjects ac = new crudSubjects();
            ac.Show();
            this.Hide();
        }

        private void pbxtemas_Click(object sender, EventArgs e)
        {
            crudSubjects ac = new crudSubjects();
            ac.Show();
            this.Hide();
        }

        private void btnusuarios_MouseEnter(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(115, 3, 3);
            pbxusuarios.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnusuarios_MouseLeave(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(163, 3, 3);
            pbxusuarios.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxusuarios_MouseLeave(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(163, 3, 3);
            pbxusuarios.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxusuarios_MouseEnter(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(140, 3, 3);
            pbxusuarios.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxusuarios_Click(object sender, EventArgs e)
        {
            AdminUsers ac = new AdminUsers();
            ac.Show();
            this.Hide();
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {
            AdminUsers ac = new AdminUsers();
            ac.Show();
            this.Hide();
        }

        private void btnempresas_MouseEnter(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(115, 3, 3);
            pbxempresa.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnempresas_MouseLeave(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(163, 3, 3);
            pbxempresa.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxempresa_MouseLeave(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(163, 3, 3);
            pbxempresa.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxempresa_MouseEnter(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(140, 3, 3);
            pbxempresa.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnempresas_Click(object sender, EventArgs e)
        {
            AdminCompany ac = new AdminCompany();
            ac.Show();
            this.Hide();
        }

        private void pbxempresa_Click(object sender, EventArgs e)
        {
            AdminCompany ac = new AdminCompany();
            ac.Show();
            this.Hide();
        }

        private void btnpagos_MouseLeave(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(163, 3, 3);
            pbxpagos.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btnpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(115, 3, 3);
            pbxpagos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxpagos_MouseLeave(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(163, 3, 3);
            pbxpagos.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(140, 3, 3);
            pbxpagos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnpagos_Click(object sender, EventArgs e)
        {

        }

        private void pbxpagos_Click(object sender, EventArgs e)
        {

        }

        private void btncerrar_MouseEnter(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.FromArgb(115, 3, 3);
            pbxcerrar.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.FromArgb(163, 3, 3);
            pbxcerrar.BackColor = Color.FromArgb(163, 3, 3);
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

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (MessageBox.Show("¿Estas seguro que deseas cerrar sesion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class.Users.id = null;
                log.Show();
                this.Hide();
            }
        }

        private void pbxcerrar_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (MessageBox.Show("¿Estas seguro que deseas cerrar sesion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class.Users.id = null;
                log.Show();
                this.Hide();
            }
        }

        private void btncontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(115, 3, 3);
            pbxcontactos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btncontactos_MouseLeave(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(163, 3, 3);
            pbxcontactos.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pbxcontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(140, 3, 3);
            pbxcontactos.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxcontactos_MouseLeave(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(163, 3, 3);
            pbxcontactos.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btncontactos_Click(object sender, EventArgs e)
        {

        }

        private void pbxcontactos_Click(object sender, EventArgs e)
        {

        }

        private void btncapacitaciones_MouseEnter(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(115, 3, 3);
            pictureBox2.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btncapacitaciones_MouseLeave(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(163, 3, 3);
            pictureBox2.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(140, 3, 3);
            pictureBox2.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(163, 3, 3);
            pictureBox2.BackColor = Color.FromArgb(163, 3, 3);
        }
    }
}
