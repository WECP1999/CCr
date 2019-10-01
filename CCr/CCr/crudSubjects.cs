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
    public partial class crudSubjects : AdminTemplate
    {
        private int accion = 0;
        Class.Connection con = new Class.Connection();
        Class.Validations val = new Class.Validations();
        Class.Subjects Subject = new Class.Subjects();
        List<Class.Subjects> SR = new List<Class.Subjects>();
        private int edit_indice = -1;
        private void refresh()
        {
            dgvSubjects.DataSource = null;
            con.startConnection();
            SR = Subject.read();
            dgvSubjects.DataSource = SR;
            con.closeConnection();
        }
        public crudSubjects()
        {
            InitializeComponent();
        }

        private void crudSubjects_Load(object sender, EventArgs e)
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

        private void pbxtemas_MouseLeave(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(37,37,37);
            pbxtemas.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxtemas_MouseEnter(object sender, EventArgs e)
        {
            btntemas.BackColor = Color.FromArgb(0, 0, 0);
            pbxtemas.BackColor = Color.FromArgb(0, 0, 0);
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case 0:
                    if (txtdescripcion.Text != "")
                    {
                        Subject.Price = Convert.ToDouble(txtprecio.Value);
                        Subject.Description = txtdescripcion.Text;
                        con.startConnection();
                        Subject.create(Subject.Description, Subject.Price);
                        con.closeConnection();
                        txtdescripcion.Clear();
                        txtprecio.Value = 0;
                        refresh();
                    }
                    break;
                case 1:
                    if (txtdescripcion.Text != "")
                    {
                        Subject.Price = Convert.ToDouble(txtprecio.Value);
                        Subject.Description = txtdescripcion.Text;
                        Subject.Id = Convert.ToInt32(lblAux.Text);
                        con.startConnection();
                        Subject.update(Subject.Description, Subject.Price, Subject.Id);
                        con.closeConnection();
                        txtdescripcion.Clear();
                        txtprecio.Value = 0;
                        btnSubmit.Text = "Crear";
                        refresh();
                    }
                    break;
                default:
                    MessageBox.Show("Accion incorrecta");
                    break;
            }
        }
        //ERRORES
        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e) { }

        private void dgvSubjects_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvSubjects.SelectedRows[0];
            int posicion = dgvSubjects.Rows.IndexOf(selected);
            edit_indice = posicion;
            Class.Subjects auxS = SR[posicion];

            txtprecio.Value = Convert.ToDecimal(auxS.Price);
            txtdescripcion.Text = auxS.Description;
            lblAux.Text = Convert.ToString(auxS.Id);
            btnSubmit.Text = "Modificar"; accion = 1;
        }
        private void dgvSubjects_Click(object sender, EventArgs e){}
    }
}
