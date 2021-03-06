﻿using System;
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
            Class.Usuarios us = new Class.Usuarios();
            Class.Conexion conexionSQL = new Class.Conexion();
                conexionSQL.startConnection();
                us = us.getUser(1);
                conexionSQL.closeConnection();
                lblUsername.Text = us.NombreUsuario.ToString();

                if (us.Descripcion == "1")
                {
                    lblTypeUser.Text = "Administrador";
                }
                else
                {
                    new Login().Show();
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
            adminPagos ac = new adminPagos();
            ac.Show();
            this.Hide();
        }

        private void pbxpagos_Click(object sender, EventArgs e)
        {
            adminPagos ac = new adminPagos();
            ac.Show();
            this.Hide();
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
            adminContactos ac = new adminContactos();
            ac.Show();
            this.Hide();
        }

        private void pbxcontactos_Click(object sender, EventArgs e)
        {
            adminContactos ac = new adminContactos();
            ac.Show();
            this.Hide();
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

        private void btncapacitaciones_Click(object sender, EventArgs e)
        {
            AdminCapacitaciones ac = new AdminCapacitaciones();
            ac.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminCapacitaciones ac = new AdminCapacitaciones();
            ac.Show();
            this.Hide();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            btnCertificados.BackColor = Color.FromArgb(163, 3, 3);
            pbxCertificados.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btnCertificados_Click(object sender, EventArgs e)
        {
            adminCertificados ac = new adminCertificados();
            ac.Show();
            this.Hide();
        }

        private void pbxCertificados_Click(object sender, EventArgs e)
        {
            adminCertificados ac = new adminCertificados();
            ac.Show();
            this.Hide();
        }
    }
}
