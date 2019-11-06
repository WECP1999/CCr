using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminModis : CCr.AdminTemplate
    {
        public AdminModis()
        {
            InitializeComponent();
        }

        List<Class.Modificaciones> listComp = new List<Class.Modificaciones>();
        int indice = -1;

        public void refresh()
        {
            try
            {
                Class.Modificaciones comp = new Class.Modificaciones();
                Class.Conexion conexionSQL = new Class.Conexion();
                conexionSQL.startConnection();
                listComp = comp.obtenerModificaciones();
                dgvmodificaciones.DataSource = null;
                dgvmodificaciones.DataSource = listComp;
                dgvmodificaciones.Columns[0].Visible = false;
                dgvmodificaciones.Columns[1].Visible = false;
                dgvmodificaciones.Columns[2].HeaderText = "Capacitador";
                dgvmodificaciones.Columns[3].HeaderText = "Participante";
                dgvmodificaciones.Columns[4].HeaderText = "Evaluacion";

                dgvmodificaciones.Columns[2].Width = 190;
                dgvmodificaciones.Columns[3].Width = 190;
                dgvmodificaciones.Columns[4].Width = 190;

                conexionSQL.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            pbxhome.BackColor = Color.FromArgb(0,0,0);
            btnhome.BackColor = Color.Black;
        }

        private void AdminModis_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dgvmodificaciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selected = dgvmodificaciones.SelectedRows[0];
                Class.Conexion conexionSQL = new Class.Conexion();
                conexionSQL.startConnection();
                int posicion = dgvmodificaciones.Rows.IndexOf(selected);
                indice = posicion;

                Class.Modificaciones comp = listComp[indice];

                if (MessageBox.Show("Presione SI para habilitar la modificacion de esta evaluacion", "¿Está seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    comp.update(0, comp.Id);
                    conexionSQL.closeConnection();
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar habilitar esta actualizacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
