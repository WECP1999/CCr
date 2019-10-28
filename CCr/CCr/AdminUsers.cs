using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminUsers : CCr.AdminForm
    {
        Class.Validaciones val = new Class.Validaciones();
        Class.Conexion con = new Class.Conexion();
        Class.Capacitadores tr = new Class.Capacitadores();
        Class.Usuarios us = new Class.Usuarios();
        List<Class.Usuarios> SR = new List<Class.Usuarios>();
        private int edit_indice = -1;
        static bool ver = false;
        public AdminUsers()
        {
            InitializeComponent();
        }
        private void refresh()
        {
            dgvUsuarios.DataSource = null;
            con.startConnection();
            SR = us.read();

            dgvUsuarios.DataSource = SR;
            dgvUsuarios.Columns["Contra"].Visible = false;
            dgvUsuarios.Columns["Idtipo"].Visible = false;
            dgvUsuarios.Columns["Xid"].Visible = false;
            dgvUsuarios.Columns[0].HeaderText = "Nombre de usuario";
            dgvUsuarios.Columns[0].Width = 230;
            dgvUsuarios.Columns[2].Width = 200;
            dgvUsuarios.Columns[3].Width = 230;
            dgvUsuarios.Columns[2].HeaderText = "Estado";
            dgvUsuarios.Columns[3].HeaderText = "Modulo";
            con.closeConnection();
        }
        private void btnhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(163, 3, 3);
            pbxhome.BackColor = Color.FromArgb(163, 3, 3);
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

        private void pbxhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(163, 3, 3);
            pbxhome.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btnusuarios_MouseLeave(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(37, 37, 37);
            pbxusuarios.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btnusuarios_MouseEnter(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(0, 0, 0);
            pbxusuarios.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxusuarios_MouseLeave(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(37, 37, 37);
            pbxusuarios.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxusuarios_MouseEnter(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(0, 0, 0);
            pbxusuarios.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {

        }

        private void AdminUsers_Load(object sender, EventArgs e)
        {
            cmbtipo.SelectedIndex = 0;
            refresh();
        }

        private void cmbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtipo.SelectedIndex == 2)
            {
                label5.Visible = true;
                label6.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                txtnombre.Visible = true;
                txtapellido.Visible = true;

                groupBox1.Height = 372;

                btningresar.Location = new Point(337,315);
            }
            else
            {
                label5.Visible = false;
                label6.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                txtnombre.Visible = false;
                txtapellido.Visible = false;

                groupBox1.Height = 310;

                btningresar.Location = new Point(337, 254);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Black;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Black;
        }

        private void txtVerify_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtVerify_Leave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Black;
        }

        private void txtnombre_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Black;
        }

        private void txtapellido_Click(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
            {
                if (txtPass.Text != "" && (txtPass.Text == txtVerify.Text))
                {
                    if ((cmbtipo.SelectedIndex + 1) == 3)
                    {
                        if (val.validateName(txtnombre.Text) && val.validateName(txtapellido.Text))
                        {
                            tr.Nombre = txtnombre.Text; tr.Apellido = txtapellido.Text;
                            us.NombreUsuario = txtUserName.Text;
                            us.Contra = txtPass.Text;
                            us.Idtipo = cmbtipo.SelectedIndex + 1;
                            con.startConnection();
                            int po = us.signUp(us.NombreUsuario, us.Contra, us.Idtipo);
                            if (po == 0)
                            {
                                MessageBox.Show("Hubo un error, usuario repetido");
                            }
                            else
                            {
                                tr.create(tr.Nombre, tr.Apellido, po);
                                MessageBox.Show("Usuario ingresado exitosamente");
                            }
                            con.closeConnection();
                        }
                        else
                        {
                            MessageBox.Show("Error con el nombre o el apellido \r\n (primera letra de cada nombre en mayuscula)");
                        }
                    }
                    else
                    {
                        us.NombreUsuario = txtUserName.Text; 
                        us.Contra = txtPass.Text;
                        us.Idtipo = cmbtipo.SelectedIndex + 1;
                        con.startConnection();
                        if (us.signUp(us.NombreUsuario, us.Contra, us.Idtipo) == 0)
                        {
                            MessageBox.Show("Hubo un error, usuario repetido");
                        }
                        else
                        {
                            MessageBox.Show("Usuario ingresado exitosamente");
                        }
                        con.closeConnection();
                        txtUserName.Clear();
                        txtUserName.Focus();
                        txtVerify.Clear();
                        txtPass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Error con la contraseña");
                }
            }else
            {
                MessageBox.Show("Error con el nombre de usuario");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ver)
            {
                ver = true;
                txtPass.PasswordChar = '\0';
                txtVerify.PasswordChar = '\0';
            }
            else
            {
                ver = false;
                txtPass.PasswordChar = '*';
                txtVerify.PasswordChar = '*';
            }
        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvUsuarios.SelectedRows[0];
            int posicion = dgvUsuarios.Rows.IndexOf(selected);
            edit_indice = posicion;
            Class.Usuarios auxS = SR[posicion];
            con.startConnection();
            if (auxS.Estado == "Activo")
            {
                if (MessageBox.Show("¿Estas seguro que deseas dar de baja al usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    us.update(auxS.Xid, false);
                }
            }
            else
            {
                if (MessageBox.Show("¿Estas seguro que deseas reintegrar al usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    us.update(auxS.Xid, true);
                }
            }
            con.closeConnection();
            refresh();
        }
    }
}
