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
    public partial class adminPagos : AdminTemplate
    {
        Class.Pagos pago = new Class.Pagos();
        Class.Capacitaciones capacitacion = new Class.Capacitaciones();
        Class.Conexion con = new Class.Conexion();

        List<Class.Capacitaciones> Lista3 = new List<Class.Capacitaciones>();
        List<Class.Pagos> Lista2 = new List<Class.Pagos>();

        private void llenar_combobox()
        {
            con.startConnection();
            List<Class.Capacitaciones> Lista3a = new List<Class.Capacitaciones>();
            Lista3a = capacitacion.read(true);
            foreach (var item in Lista3a)
            {
                if (pago.deuda(item.Id.ToString(), Convert.ToDouble(item.TipoCapacitacion.Replace("$",""))) > 0)
                {
                    Lista3.Add(item); btningresar.Enabled = true;
                    cmbCapacitacion.Items.Add(item.Empresa + " -> (" + item.DiaInicio.ToString() + ")(" +item.Tema+")");
                }
            }
            con.closeConnection();
            cmbCapacitacion.SelectedIndex = 0;
        }
        private void refresh()
        {
            try
            {
                con.startConnection();
                Lista2 = pago.leer();
                con.closeConnection();
                dgvPagos.DataSource = null;
                dgvPagos.DataSource = Lista2;
                dgvPagos.Columns[2].Visible = false;
                dgvPagos.Columns[3].Visible = false;

                dgvPagos.Columns["Fecha"].Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public adminPagos()
        {
            InitializeComponent();
        }

        private void adminPagos_Load(object sender, EventArgs e) { 
            llenar_combobox();
            dtpInicio.MaxDate = DateTime.Today;
            refresh();
        }

        private void btnpagos_MouseLeave(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(37, 37, 37);
            pbxpagos.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxpagos_MouseLeave(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(37, 37, 37);
            pbxpagos.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btnpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(0, 0, 0);
            pbxpagos.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxpagos_MouseEnter(object sender, EventArgs e)
        {
            btnpagos.BackColor = Color.FromArgb(0, 0, 0);
            pbxpagos.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void groupBox1_Enter(object sender, EventArgs e){}

        private void cmbCapacitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.startConnection();
            txtprecio.Maximum = Convert.ToDecimal(pago.deuda(Lista3[cmbCapacitacion.SelectedIndex].Id.ToString(), Convert.ToDouble(Lista3[cmbCapacitacion.SelectedIndex].TipoCapacitacion.Replace("$", ""))));
            con.closeConnection();
        }

        private void txtprecio_ValueChanged(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            txtprecio.Value = txtprecio.Maximum;
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            if (txtprecio.Value > 0)
            {
                pago.crear(dtpInicio.Value,txtprecio.Value.ToString(), Lista3[cmbCapacitacion.SelectedIndex].Id.ToString());
            }
        }
    }
}
