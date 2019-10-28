using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class Login : CCr.Template
    {
        Class.Validaciones val = new Class.Validaciones();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnlogin.BackColor = Color.FromArgb(175, 4, 4);
            label2.ForeColor = Color.FromArgb(175, 4, 4);
            label3.ForeColor = Color.FromArgb(175, 4, 4);
            txtpass.BackColor = Color.FromArgb(246, 246, 246);
            txtusuario.BackColor = Color.FromArgb(246, 246, 246);
        }

        private void txtusuario_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Black;
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            bool ban1 = false;
            AdminForm adf = new AdminForm();
            try
            {
                if (val.validateUs(txtusuario.Text))
                {
                    ban1 = true;
                }
                else
                {
                    ban1 = false;
                    MessageBox.Show("Formato de usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusuario.Focus();
                    panel1.BackColor = Color.FromArgb(175, 4, 4);
                }

                if (txtpass.Text.Trim() != "")
                {
                    ban1 = true;
                }
                else
                {
                    ban1 = false;
                    MessageBox.Show("Ingrese una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass.Focus();
                    panel2.BackColor = Color.FromArgb(175, 4, 4);
                }

                if (ban1)
                {
                    Class.Conexion conexionSQL = new Class.Conexion();
                    Class.Usuarios us = new Class.Usuarios();
                    Class.Usuarios aux = new Class.Usuarios();
                    conexionSQL.startConnection();

                    if (us.login(txtusuario.Text, txtpass.Text) == true)
                    {
                        aux = us.getUser(int.Parse(Class.Usuarios.Id));
                        if (aux.Estado == "True")
                        {
                            if (aux.Descripcion == "1")
                            {
                                conexionSQL.closeConnection();
                                MessageBox.Show("Bienvenido " + txtusuario.Text, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                adf.Show();
                            }
                            else if (aux.Descripcion == "2")
                            {
                                conexionSQL.closeConnection();
                                MessageBox.Show("Bienvenido " + txtusuario.Text, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (aux.Descripcion == "3")
                            {
                                conexionSQL.closeConnection();
                                MessageBox.Show("Bienvenido " + txtusuario.Text, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            conexionSQL.closeConnection();
                            MessageBox.Show("El usuario esta de baja, consulte con el administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                        else
                    {
                        conexionSQL.closeConnection();
                        MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    conexionSQL.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Credits cre = new Credits();
            this.Hide();
            cre.Show();
        }
    }
}
