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
    public partial class adminContactos : AdminTemplate
    {

        Class.Conexion con = new Class.Conexion();
        Class.Empresas em = new Class.Empresas();
        Class.Contactos cont = new Class.Contactos();
        Class.Validaciones val = new Class.Validaciones();

        List<Class.Empresas> lista = new List<Class.Empresas>();
        List<Class.Contactos> lista2 = new List<Class.Contactos>();
        private void combo()
        {
            bool a1 = false;
            con.startConnection();
            lista = em.read();
            foreach (var em in lista)
            {
                a1 = true;
                cmbEmpresa.Items.Add(em.Nombre);
            }
            if (a1)
            {
                btningresar.Enabled = true;
                cmbEmpresa.SelectedIndex = 0;
            }
        }

        public adminContactos()
        {
            InitializeComponent();
        }

        private void adminContactos_Load(object sender, EventArgs e)
        {
            combo();
        }

        private void btncontactos_MouseLeave(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(37, 37, 37);
            pbxcontactos.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btncontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(0, 0, 0);
            pbxcontactos.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxcontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(0, 0, 0);
            pbxcontactos.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxcontactos_MouseLeave(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.FromArgb(37, 37, 37);
            pbxcontactos.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void dgvusuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            con.startConnection();
            if (val.validateFon(txtNumero.Text))
            {
                int hh;
                hh = cont.create(txtNumero.Text, txtNumeroe.Text);
                cont.create(textBox2.Text, hh, lista[cmbEmpresa.SelectedIndex].Id);
                MessageBox.Show("Se ha ingresado todo correctamente");textBox2.Clear();cmbEmpresa.SelectedIndex = 0;
                txtNumero.Clear();txtNumeroe.Clear();
            }
            else
            {
                MessageBox.Show("No se cumple con el formato del numero");
            }
            con.closeConnection();
        }

        private void txtNumeroe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
