using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminCompany : CCr.AdminForm
    {
        public AdminCompany()
        {
            InitializeComponent();
        }

        Class.Validations val = new Class.Validations();
        List<Class.Companys> listComp = new List<Class.Companys>();
        int indice = -1;

        public void refresh()
        {
            Class.Companys comp = new Class.Companys();
            Class.Connection conexionSQL = new Class.Connection();
            conexionSQL.startConnection();
            listComp = comp.read();
            dgvusuarios.DataSource = null;
            dgvusuarios.DataSource = listComp;
            dgvusuarios.Columns[0].Visible = false;
            dgvusuarios.Columns[1].HeaderText = "Nombre de la empresa";
            dgvusuarios.Columns[2].HeaderText = "Dirección";
            dgvusuarios.Columns[3].HeaderText = "Número de empleados";
            dgvusuarios.Columns[4].HeaderText = "Correo";
            conexionSQL.closeConnection();
        }

        public void refreshComp()
        {
            txtempresa.Text = "";
            txtcorreo.Text = "";
            txtdireccion.Text = "";
            nudcantempleados.Value = 0;
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

        private void btnhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(115, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void btnempresas_MouseLeave(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(37, 37, 37);
            pbxempresa.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btnempresas_MouseEnter(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(0, 0, 0);
            pbxempresa.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxempresa_MouseEnter(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(0, 0, 0);
            pbxempresa.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxempresa_MouseLeave(object sender, EventArgs e)
        {
            btnempresas.BackColor = Color.FromArgb(37, 37, 37);
            pbxempresa.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void txtempresa_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Black;
        }

        private void txtempresa_Leave_1(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Black;
        }

        private void txtdireccion_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtdireccion_Leave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
        }

        private void txtcorreo_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtcorreo_Leave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Black;
        }

        //Codigo fuera de estilo

        private void btningresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtempresa.Text.Trim() != "")
                {
                    if (val.validateNumber(nudcantempleados.Value.ToString()))
                    {
                        if (txtdireccion.Text.Trim() != "")
                        {
                            if (val.validateEmail(txtcorreo.Text))
                            {
                                if(indice > -1)
                                {
                                    Class.Connection conexionSQL = new Class.Connection();
                                    Class.Companys comp = new Class.Companys();
                                    conexionSQL.startConnection();
                                    int resultado = comp.update(int.Parse(label5.Text),txtempresa.Text, int.Parse(nudcantempleados.Value.ToString()), txtdireccion.Text, txtcorreo.Text);
                                    conexionSQL.closeConnection();
                                    if (resultado == 1)
                                    {
                                        MessageBox.Show("Empresa editada con exito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        refresh();
                                        indice = -1;
                                        btningresar.Text = "Ingresar";
                                        refreshComp();
                                    }
                                }
                                else
                                {
                                    Class.Connection conexionSQL = new Class.Connection();
                                    Class.Companys comp = new Class.Companys();
                                    conexionSQL.startConnection();
                                    int resultado = comp.create(txtempresa.Text, int.Parse(nudcantempleados.Value.ToString()), txtdireccion.Text, txtcorreo.Text);
                                    conexionSQL.closeConnection();
                                    if (resultado == 1)
                                    {
                                        MessageBox.Show("Empresa ingresada con exito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        refresh();
                                        refreshComp();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un correo valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtcorreo.Focus();
                                panel5.BackColor = Color.FromArgb(175, 4, 4);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese la dirección de la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtdireccion.Focus();
                            panel4.BackColor = Color.FromArgb(175, 4, 4);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una cantidad de empleados valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nudcantempleados.Focus();
                        panel3.BackColor = Color.FromArgb(175, 4, 4);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el nombre de la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtempresa.Focus();
                    panel2.BackColor = Color.FromArgb(175, 4, 4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminCompany_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dgvusuarios_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvusuarios.SelectedRows[0];
            int posicion = dgvusuarios.Rows.IndexOf(selected);
            indice = posicion;

            Class.Companys comp = listComp[indice];

            txtempresa.Text = comp.Name;
            txtdireccion.Text = comp.Address;
            txtcorreo.Text = comp.Email;
            nudcantempleados.Value = comp.NumberParticipants;
            btningresar.Text = "Modificar";
            label5.Text = comp.Id.ToString();
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {

        }

        private void pbxhome_Click(object sender, EventArgs e)
        {

        }

        private void btnempresas_Click(object sender, EventArgs e)
        {

        }
    }
}
