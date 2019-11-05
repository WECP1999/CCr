using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class CapacitadorNotas : CCr.CapacitadorTemplate
    {
        public CapacitadorNotas()
        {
            InitializeComponent();
        }


        Class.Validaciones val = new Class.Validaciones();
        List<Class.Evaluacion> listComp = new List<Class.Evaluacion>();
        List<Class.Notas> listNot = new List<Class.Notas>();
        int indice = -1;

        public void refresh()
        {
            try
            {
                Class.Notas comp = new Class.Notas();
                Class.Conexion conexionSQL = new Class.Conexion();
                conexionSQL.startConnection();
                listNot = comp.listarParticipantes();
                dgvparticipantes.DataSource = null;
                dgvparticipantes.DataSource = listNot;
                if (listComp != null)
                {
                    dgvparticipantes.Columns[0].Visible = false;
                    dgvparticipantes.Columns[1].Visible = false;

                    dgvparticipantes.Columns[2].Width = 280;
                    dgvparticipantes.Columns[3].Width = 280;
                }
                conexionSQL.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void refresh(string name)
        {
            try
            {
                Class.Notas comp = new Class.Notas();
                Class.Conexion conexionSQL = new Class.Conexion();
                conexionSQL.startConnection();
                listNot = comp.buscarParticipante(name);
                dgvparticipantes.DataSource = null;
                dgvparticipantes.DataSource = listNot;
                if (listComp != null)
                {
                    dgvparticipantes.Columns[0].Visible = false;
                    dgvparticipantes.Columns[1].Visible = false;

                    dgvparticipantes.Columns[2].Width = 280;
                    dgvparticipantes.Columns[3].Width = 280;
                }
                conexionSQL.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNotas_MouseEnter(object sender, EventArgs e)
        {
            btnNotas.BackColor = Color.Black;
            pbxNotas.BackColor = Color.Black;
        }

        private void pbxNotas_Click(object sender, EventArgs e)
        {

        }

        private void CapacitadorNotas_Load(object sender, EventArgs e)
        {
            refresh();
            Class.Evaluacion comp = new Class.Evaluacion();
            Class.Conexion conexionSQL = new Class.Conexion();
            conexionSQL.startConnection();
            listComp = comp.listarEvaluaciones();
            conexionSQL.closeConnection();

            foreach (Class.Evaluacion eva in listComp)
            {
                cmbnotas.Items.Add(eva.Descripcion);
            }

            cmbnotas.SelectedIndex = 0;
        }

        private void cmbnotas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtdui_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(175, 4, 4);
            txtdui.ForeColor = Color.FromArgb(0, 0, 0);
        }
        private void txtdui_Leave_1(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtdui.Text.Trim() != "")
            {
                if (val.validateName(txtdui.Text))
                {
                    refresh(txtdui.Text);
                }
                else
                {
                    MessageBox.Show("Ingrese un nombre o apellido valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdui.Focus();
                    panel2.BackColor = Color.FromArgb(175, 4, 4);
                }
            }
            else
            {
                refresh();
            }
        }

        private void dgvparticipantes_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvparticipantes.SelectedRows[0];
            int posicion = dgvparticipantes.Rows.IndexOf(selected);
            indice = posicion;

            Class.Notas comp = listNot[indice];

            lblid.Text = comp.Id.ToString();

            groupBox2.Visible = true;

            label1.Text = "El participante " + comp.Participante + " tiene una nota de:";

        }

        private void txtdui_TextChanged(object sender, EventArgs e)
        {
            if (txtdui.Text.Trim() == "")
            {
                refresh();
            }
        }

        private void btningresar_Click(object sender, EventArgs e)
        {

        }
    }
}
