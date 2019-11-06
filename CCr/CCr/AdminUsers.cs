using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminUsers : CCr.AdminTemplate
    {
        Class.Validaciones val = new Class.Validaciones();
        Class.Conexion con = new Class.Conexion();
        Class.Capacitadores tr = new Class.Capacitadores();
        Class.Usuarios us = new Class.Usuarios();
        List<Class.Usuarios> SR = new List<Class.Usuarios>();
        private int edit_indice = -1;
        static bool ver = false;
        private bool bb = false;
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

        private void btnusuarios_Click(object sender, EventArgs e){ }

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
            try
            {
                con.startConnection();
                if (txtUserName.Text != "")
                {
                    if (bb)
                    {
                        if (txtPass.Text == txtVerify.Text)
                        {
                            if (cmbtipo.SelectedIndex == 2)
                            {
                                if (val.validateName(txtnombre.Text) && val.validateName(txtapellido.Text))
                                {//aqui se modifica con nombre
                                    if (txtPass.Text == "")
                                    {
                                        if (us.update(txtUserName.Text, us.Xid))
                                        {
                                            tr.update(txtnombre.Text, txtapellido.Text, us.Xid);
                                            MessageBox.Show("Usuario modificado exitosamente");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Hubo un error, usuario repetido");
                                        }
                                    }
                                    else
                                    {
                                        if (us.update(txtUserName.Text, txtPass.Text, us.Xid))
                                        {
                                            tr.update(txtnombre.Text, txtapellido.Text, us.Xid);
                                            MessageBox.Show("Usuario ingresado exitosamente");
                                            txtapellido.Clear(); txtnombre.Clear(); txtPass.Clear(); txtVerify.Clear(); txtUserName.Clear(); txtUserName.Focus();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Hubo un error, usuario repetido");
                                        }
                                    }
                                    //MessageBox.Show("Usuario Modificado exitosamente");
                                }
                                else
                                {
                                    MessageBox.Show("Error con el nombre o el apellido \r\n (primera letra de cada nombre en mayuscula)");
                                }
                            }
                            else
                            {//aqui se modifica sin nombre
                                if (txtPass.Text == "")
                                {
                                    if (us.update(txtUserName.Text, us.Xid))
                                    {
                                        MessageBox.Show("Usuario modificado exitosamente");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hubo un error, usuario repetido");
                                    }
                                }
                                else
                                {
                                    if (us.update(txtUserName.Text, txtPass.Text, us.Xid))
                                    {
                                        MessageBox.Show("Usuario ingresado exitosamente");
                                        txtapellido.Clear(); txtnombre.Clear(); txtPass.Clear(); txtVerify.Clear(); txtUserName.Clear(); txtUserName.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hubo un error, usuario repetido");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error con la contraseña");
                        }
                        bb = false; btningresar.Text = "Ingresar";
                        txtapellido.Clear(); txtnombre.Clear(); txtPass.Clear(); txtVerify.Clear(); txtUserName.Clear(); txtUserName.Focus();
                    }
                    else
                    {
                        if (txtPass.Text != "" && (txtPass.Text == txtVerify.Text))
                        {//aqui se ingresa con nombre       
                            us.NombreUsuario = txtUserName.Text;
                            us.Contra = txtPass.Text;
                            us.Idtipo = cmbtipo.SelectedIndex + 1;
                            if (cmbtipo.SelectedIndex == 2)
                            {
                                if (val.validateName(txtnombre.Text) && val.validateName(txtapellido.Text))
                                {
                                    int po = us.signUp(us.NombreUsuario, us.Contra, us.Idtipo);
                                    if (po == 0)
                                    {
                                        MessageBox.Show("Hubo un error, usuario repetido");
                                    }
                                    else
                                    {
                                        tr.Nombre = txtnombre.Text; tr.Apellido = txtapellido.Text;
                                        tr.create(tr.Nombre, tr.Apellido, po);
                                        MessageBox.Show("Usuario ingresado exitosamente");
                                        txtapellido.Clear();txtnombre.Clear();txtPass.Clear();txtVerify.Clear();txtUserName.Clear();txtUserName.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error con el nombre o el apellido \r\n (primera letra de cada nombre en mayuscula)");
                                }
                            }
                            else
                            {//aqui se ingresa SIN nombre
                                int po = us.signUp(us.NombreUsuario, us.Contra, us.Idtipo);
                                if (po == 0)
                                {
                                    MessageBox.Show("Hubo un error, usuario repetido");
                                }
                                else
                                {
                                    MessageBox.Show("Usuario ingresado exitosamente");
                                    txtapellido.Clear();txtnombre.Clear();txtPass.Clear();txtVerify.Clear();txtUserName.Clear();txtUserName.Focus();
                                }
                            }    
                        }
                        else
                        {
                            MessageBox.Show("Error con la contraseña");
                        }
                    }                
                }
                else
                {
                    MessageBox.Show("Error con el nombre de usuario");
                }
                refresh();
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
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
                        us.shutdown(auxS.Xid, false);
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Estas seguro que deseas reintegrar al usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        us.shutdown(auxS.Xid, true);
                    }
                }
                bb = false; btningresar.Text = "Ingresar";
                con.closeConnection();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtapellido.Clear();txtnombre.Clear();txtPass.Clear();txtVerify.Clear();txtUserName.Clear();txtUserName.Focus();
        }

        private void dgvUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selected = dgvUsuarios.SelectedRows[0];
                int posicion = dgvUsuarios.Rows.IndexOf(selected);
                edit_indice = posicion;
                Class.Usuarios auxS = SR[posicion];
                con.startConnection();
                switch (auxS.Descripcion)
                {
                    case "Administrador":
                        cmbtipo.SelectedIndex = 0;
                        break;
                    case "Asesor":
                        cmbtipo.SelectedIndex = 1;
                        break;
                    case "Capacitador":
                        cmbtipo.SelectedIndex = 2;
                        tr = tr.nombres(auxS.Xid);
                        txtapellido.Text = tr.Nombre.ToString();
                        txtnombre.Text = tr.Apellido.ToString();
                        //MessageBox.Show("Si no desea cambiar la contraseña dejarla en blanco");
                        break;
                    default:
                        break;
                }
                bb = true;
                btningresar.Text = "Modificar";
                us = us.getUser(Convert.ToInt32(auxS.Xid));
                txtUserName.Text = us.NombreUsuario;
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbtipo_SelectedValueChanged(object sender, EventArgs e)
        {
            txtapellido.Clear(); txtnombre.Clear(); txtPass.Clear(); txtVerify.Clear(); txtUserName.Clear(); txtUserName.Focus();
            bb = false; btningresar.Text = "Ingresar";
        }
    }
}
