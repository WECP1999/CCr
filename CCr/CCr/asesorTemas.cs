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
    public partial class asesorTemas : AsesorTemplate
    {
        private int accion = 0;
        Class.Conexion con = new Class.Conexion();
        Class.Validaciones val = new Class.Validaciones();
        Class.Temas Subject = new Class.Temas();
        List<Class.Temas> SR = new List<Class.Temas>();
        private int edit_indice = -1;
        private void refresh()
        {
            dgvSubjects.DataSource = null;
            con.startConnection();
            SR = Subject.read(1);
            dgvSubjects.DataSource = SR;
            dgvSubjects.Columns["id"].Visible = false;
            dgvSubjects.Columns[1].HeaderText = "Tema";
            dgvSubjects.Columns[2].HeaderText = "Precio";
            con.closeConnection();
        }
        public asesorTemas()
        {
            InitializeComponent();
        }

        private void asesorTemas_Load(object sender, EventArgs e)
        {
            refresh();
            btnSubmit.BackColor = Color.FromArgb(175, 4, 4);
            label2.ForeColor = Color.FromArgb(175, 4, 4);
            label1.ForeColor = Color.FromArgb(175, 4, 4);
            txtprecio.BackColor = Color.FromArgb(246, 246, 246);
            txtdescripcion.BackColor = Color.FromArgb(246, 246, 246);
        }

        private void btntemas_MouseLeave(object sender, EventArgs e)
        {

            btntemas.BackColor = Color.FromArgb(37, 37, 37);
            pbxtemas.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btntemas_MouseEnter(object sender, EventArgs e)
        {

            btntemas.BackColor = Color.FromArgb(0, 0, 0);
            pbxtemas.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxtemas_MouseEnter(object sender, EventArgs e)
        {

            btntemas.BackColor = Color.FromArgb(0, 0, 0);
            pbxtemas.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxtemas_MouseLeave(object sender, EventArgs e)
        {

            btntemas.BackColor = Color.FromArgb(37, 37, 37);
            pbxtemas.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case 0:
                    if (txtdescripcion.Text != "")
                    {
                        Subject.Precio = Convert.ToDouble(txtprecio.Value);
                        Subject.Descripcion = txtdescripcion.Text;
                        con.startConnection();
                        Subject.create(Subject.Descripcion, Subject.Precio);
                        con.closeConnection();
                        txtdescripcion.Clear();
                        txtprecio.Value = 0;
                        refresh();
                        accion = 0;
                    }
                    else
                    {
                        MessageBox.Show("Falta el tema de la capacitacion");
                    }
                    break;
                case 1:
                    if (txtdescripcion.Text != "")
                    {
                        Subject.Precio = Convert.ToDouble(txtprecio.Value);
                        Subject.Descripcion = txtdescripcion.Text;
                        Subject.Id = Convert.ToInt32(lblAux.Text);
                        con.startConnection();
                        Subject.update(Subject.Descripcion, Subject.Precio, Subject.Id);
                        con.closeConnection();
                        txtdescripcion.Clear();
                        txtprecio.Value = 0;
                        btnSubmit.Text = "Ingresar";
                        refresh();
                        accion = 0;
                    }
                    else
                    {
                        MessageBox.Show("El tema de la capacitacion no puede ser nula");
                    }
                    break;
                default:
                    MessageBox.Show("Accion incorrecta");
                    break;
            }
        }

        private void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSubjects_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvSubjects.SelectedRows[0];
            int posicion = dgvSubjects.Rows.IndexOf(selected);
            edit_indice = posicion;
            Class.Temas auxS = SR[posicion];

            txtprecio.Value = Convert.ToDecimal(auxS.Precio);
            txtdescripcion.Text = auxS.Descripcion;
            lblAux.Text = Convert.ToString(auxS.Id);
            btnSubmit.Text = "Modificar"; accion = 1;
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
