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
        int indice = -1;
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
                    dgvusuarios.Columns[5].HeaderText = "Telefono movil";
                    dgvusuarios.Columns[6].HeaderText = "Telefono fijo";
                    dgvusuarios.Columns[7].HeaderText = "Telefono alterno";

                    dgvusuarios.Columns[1].Width = 150;
                    dgvusuarios.Columns[2].Width = 150;
                    dgvusuarios.Columns[3].Width = 70;
                    dgvusuarios.Columns[4].Width = 150;
                    dgvusuarios.Columns[5].Width = 70;
                    dgvusuarios.Columns[6].Width = 70;
                    dgvusuarios.Columns[7].Width = 70;
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
            btningresar.Location = new Point(295, 330);

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
            btningresar.Location = new Point(295, 273);
        }

        private void btningresar_Click(object sender, EventArgs e)
        {

        }
    }
}
