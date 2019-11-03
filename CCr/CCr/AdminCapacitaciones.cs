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
        //listas
        List<Class.Empresas> lista = new List<Class.Empresas>();
        List<Class.Capacitadores> lista1 = new List<Class.Capacitadores>();
        List<Class.Temas> lista2 = new List<Class.Temas>();
        List<Class.Capacitaciones> Lista3 = new List<Class.Capacitaciones>();
        private void cargar()
        {
            con.startConnection();
            lista = em.read();
            foreach (var em in lista)
            {
                cmbEmpresa.Items.Add(em.Nombre);
            }
            lista1 = ca.read();
            foreach (var ca in lista1)
            {
                cmbCapacitador.Items.Add(ca.Apellido + " " + ca.Nombre);
            }
            lista2 = te.read(3);
            foreach (var te in lista2)
            {
                cmbTema.Items.Add(te.Descripcion);
            }
            btningresar.Enabled = true;
            con.closeConnection();
        }
        private void refresh()
        {
            dgvCapacitaciones.DataSource = null;
            con.startConnection();
            Lista3 = cap.read(true);
            dgvCapacitaciones.DataSource = Lista3;
            dgvCapacitaciones.Columns["id"].Visible = false;
            dgvCapacitaciones.Columns[3].HeaderText = "Precio";
            con.closeConnection();
        }
        public AdminCapacitaciones()
        {
            InitializeComponent();
        }

        private void AdminCapacitaciones_Load(object sender, EventArgs e){}
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

        private void groupBox1_Enter(object sender, EventArgs e){ }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void AdminCapacitaciones_Load_1(object sender, EventArgs e){
            cargar(); refresh();
            dtpInicio.MinDate = DateTime.Today;
            dtpFinal.MinDate = dtpInicio.MinDate.AddDays(1);
            dtpInicio.MaxDate = dtpFinal.Value;
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            cap.Tema = lista2[cmbTema.SelectedIndex].Id.ToString();
            cap.Empresa = lista[cmbEmpresa.SelectedIndex].Id.ToString();
            cap.Capacitador = lista1[cmbCapacitador.SelectedIndex].Id.ToString();
            cap.DiaInicio = dtpInicio.Value;
            cap.DiaFinal = dtpFinal.Value;
            con.startConnection();
            cap.create(cap.DiaInicio,cap.DiaFinal,cap.Tema,cap.Empresa,cap.Capacitador);
            con.closeConnection(); refresh();
            MessageBox.Show("Se ha ingresado con exito");
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFinal.MinDate = dtpInicio.Value.AddDays(1);
        }

        private void dtpFinal_ValueChanged(object sender, EventArgs e)
        {
            dtpInicio.MaxDate = dtpFinal.Value;
        }
    }
}
