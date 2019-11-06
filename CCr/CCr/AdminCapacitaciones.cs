using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminCapacitaciones : CCr.AdminTemplate
    {
        //variables
        Class.Empresas em = new Class.Empresas();
        Class.Capacitadores ca = new Class.Capacitadores();
        Class.Temas te = new Class.Temas();
        Class.Conexion con = new Class.Conexion();
        Class.Capacitaciones cap = new Class.Capacitaciones();
        Class.Participantes pa = new Class.Participantes();

        static string id;
        private int edit_indice = -1;
        private bool crear = true;
        //listas
        List<Class.Empresas> lista = new List<Class.Empresas>();
        List<Class.Capacitadores> lista1 = new List<Class.Capacitadores>();
        List<Class.Temas> lista2 = new List<Class.Temas>();
        List<Class.Capacitaciones> Lista3 = new List<Class.Capacitaciones>();
        List<Class.Participantes> lista4 = new List<Class.Participantes>();
        List<Class.Participantes> listap = new List<Class.Participantes>();

        //funciones para cargar cosas
        private void cargar()
        {
            try
            {
                cmbEmpresa.Items.Clear(); cmbCapacitador.Items.Clear(); cmbTema.Items.Clear(); lista.Clear(); lista1.Clear(); lista2.Clear();
                bool a1 = false, a2 = false, a3 = false;
                con.startConnection();
                lista = em.read();
                foreach (var em in lista)
                {
                    a1 = true;
                    cmbEmpresa.Items.Add(em.Nombre);
                }
                lista1 = ca.read();
                foreach (var ca in lista1)
                {
                    a2 = true;
                    cmbCapacitador.Items.Add(ca.Apellido + " " + ca.Nombre);
                }
                lista2 = te.read(3);
                foreach (var te in lista2)
                {
                    a3 = true;
                    cmbTema.Items.Add(te.Descripcion);
                }
                if (a1 && a2 && a3)
                {
                    btningresar.Enabled = true;
                }
                con.closeConnection();
                cmbTema.SelectedIndex = 0; cmbCapacitador.SelectedIndex = 0; cmbEmpresa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //funciones para cargar cosas
        private void cargarL()
        {
            try
            {
                cmbTemal.Items.Clear(); cmbCapacitadorl.Items.Clear(); lista.Clear(); lista1.Clear(); lista2.Clear();
                bool a2 = false, a3 = false;
                con.startConnection();
                lista1 = ca.read();
                foreach (var ca in lista1)
                {
                    a2 = true;
                    cmbCapacitadorl.Items.Add(ca.Apellido + " " + ca.Nombre);
                }
                lista2 = te.read(2);
                foreach (var te in lista2)
                {
                    a3 = true;
                    cmbTemal.Items.Add(te.Descripcion);
                }
                if (a2 && a3)
                {
                    btnIngresarl.Enabled = true;
                }
                con.closeConnection();
                cmbTemal.SelectedIndex = 0; cmbCapacitadorl.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //funciones para llenar dgv cosas
        private void refresh()
        {
            try
            {
                dgvCapacitaciones.DataSource = null;
                con.startConnection();
                Lista3 = cap.read(true);
                dgvCapacitaciones.DataSource = Lista3;
                dgvCapacitaciones.Columns["id"].Visible = false;
                dgvCapacitaciones.Columns[3].HeaderText = "Precio";
                dgvCapacitaciones.Columns[0].HeaderText = "Fecha de inicio";
                dgvCapacitaciones.Columns[1].HeaderText = "Fehca de final";
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void refreshPa()
        {
            try
            {
                dgvCapacitaciones.DataSource = null;
                if (listap.Count() != 0)
                {
                    dgvCapacitaciones.DataSource = listap;
                    dgvCapacitaciones.Columns["id"].Visible = false;
                    dgvCapacitaciones.Columns[5].Visible = false;
                    dgvCapacitaciones.Columns[6].Visible = false;
                    dgvCapacitaciones.Columns[7].Visible = false;
                }
                else
                {
                    btnInscribir.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //funciones para llenar dgv cosas
        private void rLibre()
        {
            try
            {
                dgvCapacitaciones.DataSource = null;
                con.startConnection();
                Lista3 = cap.read(false);
                dgvCapacitaciones.DataSource = Lista3;
                dgvCapacitaciones.Columns["id"].Visible = false;
                dgvCapacitaciones.Columns[3].Visible = false;
                dgvCapacitaciones.Columns[0].HeaderText = "Fecha de inicio";
                dgvCapacitaciones.Columns[1].HeaderText = "Fecha de final";
                dgvCapacitaciones.Columns[5].HeaderText = "Tipo de capacitacion";
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //funciones para llenar dgv cosas

        private void llenar(string par)
        {
            try
            {
                dgvAux.DataSource = null;
                con.startConnection();
                lista4 = pa.leer(par);
                dgvAux.DataSource = lista4;
                con.closeConnection();
                dgvAux.Columns["id"].Visible = false;
                dgvAux.Columns[5].Visible = false;
                dgvAux.Columns[6].Visible = false;
                dgvAux.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //funciones para llenar dgv cosas

        private void combo()
        {
            try
            {
                cmbCapacita.Items.Clear() ;
                con.startConnection();
                List<Class.Capacitaciones> lista3b = new List<Class.Capacitaciones>();
                Lista3.Clear();
                lista3b = cap.read();
                bool a1 = false;
                foreach (var cp in lista3b)
                {//validar si existe tipo de capacitacion
                    if (cap.Detalles(cp.Id.ToString()))
                    {
                        Lista3.Add(cp);
                        a1 = true;
                        cmbCapacita.Items.Add(cp.Tema + " -> (" + cp.Empresa + ")(" + cp.DiaInicio.ToString("dd/MM/yyyy")+ ")");
                    }
                }
                if (a1)
                {
                    dgvAux.Visible = true; txtbusqueda.Enabled = true;
                    cmbCapacita.SelectedIndex = 0;
                }
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public AdminCapacitaciones()
        {
            InitializeComponent();
        }
        private void btncapacitaciones_MouseEnter(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void btncapacitaciones_MouseLeave(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(37, 37, 37);
            pictureBox2.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            btncapacitaciones.BackColor = Color.FromArgb(37, 37, 37);
            pictureBox2.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void AdminCapacitaciones_Load_1(object sender, EventArgs e)
        {
            cargar(); refresh();
            dtpInicio.MinDate = DateTime.Today;
            dtpFinal.MinDate = dtpInicio.MinDate.AddDays(1);
            dtpInicio.MaxDate = dtpFinal.Value;
            dtpiniciol.MinDate = DateTime.Today;
            dtpfinl.MinDate = dtpiniciol.MinDate.AddDays(1);
            dtpiniciol.MaxDate = dtpfinl.Value;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedIndex == 0)
            {
                refresh();
                cargar();
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                rLibre();
                cargarL();
            }
            else
            {
                listap.Clear();
                llenar("");
                combo();
                dgvCapacitaciones.DataSource = null;
            }
        }
        private void dtpFinal_ValueChanged_1(object sender, EventArgs e)
        {
            dtpInicio.MaxDate = dtpFinal.Value;
        }

        private void dtpInicio_ValueChanged_1(object sender, EventArgs e)
        {
            dtpFinal.MinDate = dtpInicio.Value.AddDays(1);
        }

        private void btningresar_Click_1(object sender, EventArgs e)
        {
            try
            {
                cap.Tema = lista2[cmbTema.SelectedIndex].Id.ToString();
                cap.Empresa = lista[cmbEmpresa.SelectedIndex].Id.ToString();
                cap.Capacitador = lista1[cmbCapacitador.SelectedIndex].Id.ToString();
                cap.DiaInicio = dtpInicio.Value;
                cap.DiaFinal = dtpFinal.Value;
                con.startConnection();
                cap.create(cap.DiaInicio, cap.DiaFinal, cap.Tema, cap.Empresa, cap.Capacitador);
                con.closeConnection(); refresh();
                MessageBox.Show("Se ha ingresado con exito");
                cmbEmpresa.SelectedIndex = 0;cmbEmpresa.SelectedIndex = 0;cmbCapacitador.SelectedIndex = 0;
                dtpInicio.Value = DateTime.Today; dtpFinal.Value = DateTime.Today.AddDays(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpiniciol_ValueChanged(object sender, EventArgs e)
        {
            dtpfinl.MinDate = dtpiniciol.Value.AddDays(1);
        }

        private void dtpfinl_ValueChanged(object sender, EventArgs e)
        {
            dtpiniciol.MaxDate = dtpfinl.Value;
        }

        private void cmbTemal_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar(txtbusqueda.Text);
        }

        private void btnIngresarl_Click(object sender, EventArgs e)
        {
            try
            {
                cap.Tema = lista2[cmbTemal.SelectedIndex].Id.ToString();
                cap.Empresa = "1";
                cap.Capacitador = lista1[cmbCapacitadorl.SelectedIndex].Id.ToString();
                cap.DiaInicio = dtpInicio.Value;
                cap.DiaFinal = dtpFinal.Value;
                con.startConnection();
                cap.create(cap.DiaInicio, cap.DiaFinal, cap.Tema, cap.Empresa, cap.Capacitador);
                con.closeConnection(); rLibre();
                MessageBox.Show("Se ha ingresado con exito");
                cmbTemal.SelectedIndex = 0; cmbCapacitadorl.SelectedIndex = 0;
                dtpiniciol.Value = DateTime.Today; dtpfinl.Value = DateTime.Today.AddDays(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error durante la ejecución " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAux_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvAux.SelectedRows[0];
            int posicion = dgvAux.Rows.IndexOf(selected);
            edit_indice = posicion;
            Class.Participantes SS = lista4[posicion];
            con.startConnection();
            if (pa.empresa(SS.Id.ToString(), id))
            {
                bool repetido = true;
                foreach (var adios in listap)
                {
                    if (SS.Id == adios.Id)
                    {
                        repetido = false;
                    }
                }
                if (repetido)
                {
                    listap.Add(SS);
                    refreshPa();
                    btnInscribir.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("El participante no pertenece a esa empresa");
            }
            con.closeConnection();
        }
        private void txtUserName_TextChanged(object sender, EventArgs e) 
        {
            llenar(txtbusqueda.Text);
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = Lista3[cmbCapacita.SelectedIndex].TipoCapacitacion;
            dgvCapacitaciones.DataSource = null;
            listap.Clear();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            txtbusqueda.Clear();
            con.startConnection();
            if (pa.crearDD(listap,Lista3[cmbCapacita.SelectedIndex].Id))
            {
                listap.Clear();combo();refreshPa();dgvCapacitaciones.DataSource = null;
                MessageBox.Show("Se registro correctamente");
            }
            else
            {
                MessageBox.Show("No se registro");
            }
            con.closeConnection();
        }

        private void dgvCapacitaciones_DoubleClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                DataGridViewRow selected = dgvCapacitaciones.SelectedRows[0];
                int posicion = dgvCapacitaciones.Rows.IndexOf(selected);
                edit_indice = posicion;
                listap.RemoveAt(posicion);
                refreshPa();
            }
        }
    }
}
