using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AsesorContactos : CCr.AsesorTemplate
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

        public AsesorContactos()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            con.startConnection();
            if (val.validateFon(txtNumero.Text))
            {
                int hh;
                hh = cont.create(txtNumero.Text, txtNumeroe.Text);
                cont.create(textBox2.Text, hh, lista[cmbEmpresa.SelectedIndex].Id);
                MessageBox.Show("Se ha ingresado todo correctamente"); textBox2.Clear(); cmbEmpresa.SelectedIndex = 0;
                txtNumero.Clear(); txtNumeroe.Clear();
            }
            else
            {
                MessageBox.Show("No se cumple con el formato del numero");
            }
            con.closeConnection();
        }

        private void AsesorContactos_Load(object sender, EventArgs e)
        {
            combo();
        }

        private void btncontactos_MouseEnter(object sender, EventArgs e)
        {
            btncontactos.BackColor = Color.Black;
            pbxcontactos.BackColor = Color.Black;
        }
    }
}
