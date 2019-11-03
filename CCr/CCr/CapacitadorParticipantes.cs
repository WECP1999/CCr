using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class CapacitadorParticipantes : CCr.CapacitadorTemplate
    {
        public CapacitadorParticipantes()
        {
            InitializeComponent();
        }
        Class.Validaciones val = new Class.Validaciones();
        List<Class.Participantes> listComp = new List<Class.Participantes>();
        Class.Participantes partAux = new Class.Participantes();
        int indice = -1;

        public void refreshComp()
        {
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtdui.Text = "";
            txtemail.Text = "";
            txtMov.Text = "";
            txtem.Text = "";
            txtFij.Text = "";
            btningresar.Text = "Ingresar";
        }

        public void refresh()
        {
            try
            {
                Class.Participantes comp = new Class.Participantes();
                Class.Conexion conexionSQL = new Class.Conexion();
                conexionSQL.startConnection();
                listComp = comp.leer();
                dgvusuarios.DataSource = null;
                dgvusuarios.DataSource = listComp;
                if (listComp != null)
                {
                    dgvusuarios.Columns[0].Visible = false;
                    dgvusuarios.Columns[1].HeaderText = "Nombre";
                    dgvusuarios.Columns[2].HeaderText = "Apellido";
                    dgvusuarios.Columns[3].HeaderText = "Dui";
                    dgvusuarios.Columns[4].HeaderText = "Email";
                    dgvusuarios.Columns[5].HeaderText = "Telefono alterno";
                    dgvusuarios.Columns[6].HeaderText = "Telefono fijo";
                    dgvusuarios.Columns[7].HeaderText = "Telefono movil";

                    dgvusuarios.Columns[1].Width = 150;
                    dgvusuarios.Columns[2].Width = 150;
                    dgvusuarios.Columns[3].Width = 70;
                    dgvusuarios.Columns[4].Width = 150;
                    dgvusuarios.Columns[5].Width = 90;
                    dgvusuarios.Columns[6].Width = 90;
                    dgvusuarios.Columns[7].Width = 90;
                }
                conexionSQL.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CapacitadorParticipantes_Load(object sender, EventArgs e)
        {
            rdbNo.Checked = true;
            refresh();
        }

        private void btnParticipantes_MouseEnter(object sender, EventArgs e)
        {
            btnParticipantes.BackColor = Color.FromArgb(0, 0, 0);
            pbxParticipantes.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void txtempresa_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void rdbSi_CheckedChanged(object sender, EventArgs e)
        {
            lbltel.Visible = true;
            lblem.Visible = true;
            lblfij.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            txtem.Visible = true;
            txtFij.Visible = true;
            txtMov.Visible = true;
            groupBox1.Height = 380;
            if (indice > -1)
            {
                btningresar.Location = new Point(195, 330);
                btneliminar.Location = new Point(398, 330);
            }
            else
            {
                btningresar.Location = new Point(295, 330);
            }

        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            lbltel.Visible = false;
            lblem.Visible = false;
            lblfij.Visible = false;
            txtem.Visible = false;
            txtFij.Visible = false;
            txtMov.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            groupBox1.Height = 332;
            if (indice > -1)
            {
                btningresar.Location = new Point(195, 273);
                btneliminar.Location = new Point(398, 273);
            }
            else
            {
                btningresar.Location = new Point(295, 273);
                btneliminar.Visible = false;
            }
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (val.validateName(txtnombre.Text))
                {
                    if (val.validateName(txtapellido.Text))
                    {
                        if (val.validateDUI(txtdui.Text))
                        {
                            if (val.validateEmail(txtemail.Text))
                            {
                                partAux.Nombre = txtnombre.Text;
                                partAux.Apellido = txtapellido.Text;
                                partAux.Dui = txtdui.Text;
                                partAux.Email = txtemail.Text;

                                if (rdbNo.Checked)
                                {
                                    partAux.Telem = txtem.Text;
                                    partAux.Telfij = txtFij.Text;
                                    partAux.Telmov = txtMov.Text;
                                }
                                else
                                {

                                    if (txtMov.Text.Trim() != "")
                                    {
                                        if (val.validateFon(txtMov.Text))
                                        {
                                            partAux.Telmov = txtMov.Text;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ingrese un número de telefono valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtMov.Focus();
                                            panel6.BackColor = Color.FromArgb(175, 4, 4);
                                        }
                                    }
                                    else
                                    {
                                        partAux.Telmov = txtMov.Text;
                                        partAux.Telem = txtem.Text;
                                        partAux.Telfij = txtFij.Text;
                                    }

                                    if (txtFij.Text.Trim() != "")
                                    {
                                        if (val.validateFon(txtFij.Text))
                                        {
                                            partAux.Telfij = txtFij.Text;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ingrese un número de telefono valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtFij.Focus();
                                            panel7.BackColor = Color.FromArgb(175, 4, 4);
                                        }
                                    }
                                    else
                                    {
                                        partAux.Telmov = txtMov.Text;
                                        partAux.Telem = txtem.Text;
                                        partAux.Telfij = txtFij.Text;
                                    }

                                    if (txtem.Text.Trim() != "")
                                    {
                                        if (val.validateFon(txtem.Text))
                                        {
                                            partAux.Telem = txtem.Text;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ingrese un número de telefono valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtem.Focus();
                                            panel8.BackColor = Color.FromArgb(175, 4, 4);
                                        }
                                    }
                                    else
                                    {
                                        partAux.Telmov = txtMov.Text;
                                        partAux.Telem = txtem.Text;
                                        partAux.Telfij = txtFij.Text;
                                    }
                                }
                                if (indice > -1)
                                {
                                    Class.Conexion conexionSQL = new Class.Conexion();
                                    Class.Participantes comp = new Class.Participantes();

                                    partAux.Id = int.Parse(lblaux.Text);

                                    conexionSQL.startConnection();
                                    int resultado = comp.actualizar(partAux);
                                    conexionSQL.closeConnection();
                                    if (resultado == 1)
                                    {
                                        MessageBox.Show("Participante modificado con exito", "Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        indice = -1;
                                        refresh();
                                        refreshComp();
                                        rdbNo.Checked = false;
                                        rdbNo.Checked = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrio un error al intentar modificar este registro, por favor intentelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    Class.Conexion conexionSQL = new Class.Conexion();
                                    Class.Participantes comp = new Class.Participantes();

                                    conexionSQL.startConnection();
                                    int resultado = comp.crear(partAux);
                                    conexionSQL.closeConnection();
                                    if (resultado == 1)
                                    {
                                        MessageBox.Show("Participante ingresada con exito", "Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        refresh();
                                        refreshComp();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrio un error al intentar agregar este registro, por favor intentelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un correo valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtemail.Focus();
                                panel5.BackColor = Color.FromArgb(175, 4, 4);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un dui valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtdui.Focus();
                            panel4.BackColor = Color.FromArgb(175, 4, 4);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un apellido valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtapellido.Focus();
                        panel3.BackColor = Color.FromArgb(175, 4, 4);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un nombre valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnombre.Focus();
                    panel2.BackColor = Color.FromArgb(175, 4, 4);
                }
                refresh();
            }catch(Exception ex)
            {

                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvusuarios_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvusuarios.SelectedRows[0];
            int posicion = dgvusuarios.Rows.IndexOf(selected);
            indice = posicion;

            Class.Participantes comp = listComp[indice];

            lblaux.Text = comp.Id.ToString();

            txtnombre.Text = comp.Nombre;
            txtapellido.Text = comp.Apellido;
            txtdui.Text = comp.Dui;
            txtemail.Text = comp.Email;

            if (comp.Telmov.Trim() == "" && comp.Telfij.Trim() == "" && comp.Telem.Trim() == "")
            {
                rdbNo.Checked = false;
                rdbNo.Checked = true;

            }
            else
            {
                rdbSi.Checked = true;
            }

            txtFij.Text = comp.Telfij;
            txtMov.Text = comp.Telmov;
            txtem.Text = comp.Telem;
            btneliminar.Visible = true;
            btningresar.Text = "Modificar";
        }

        private void dgvusuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
