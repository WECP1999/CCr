using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCr
{
    public partial class AdminUsers : CCr.AdminForm
    {
        public AdminUsers()
        {
            InitializeComponent();
        }

        private void btnhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(163, 3, 3);
            pbxhome.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btnhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(115, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxhome_MouseEnter(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(140, 3, 3);
            pbxhome.BackColor = Color.FromArgb(140, 3, 3);
        }

        private void pbxhome_MouseLeave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(163, 3, 3);
            pbxhome.BackColor = Color.FromArgb(163, 3, 3);
        }

        private void btnusuarios_MouseLeave(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(37, 37, 37);
            pbxusuarios.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void btnusuarios_MouseEnter(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(0, 0, 0);
            pbxusuarios.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pbxusuarios_MouseLeave(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(37, 37, 37);
            pbxusuarios.BackColor = Color.FromArgb(37, 37, 37);
        }

        private void pbxusuarios_MouseEnter(object sender, EventArgs e)
        {
            btnusuarios.BackColor = Color.FromArgb(0, 0, 0);
            pbxusuarios.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {

        }

        private void AdminUsers_Load(object sender, EventArgs e)
        {
            cmbtipo.SelectedIndex = 0;
        }

        private void cmbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtipo.SelectedIndex == 2)
            {
                label5.Visible = true;
                label6.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                txtnombre.Visible = true;
                txtapellido.Visible = true;

                groupBox1.Height = 372;

                btningresar.Location = new Point(337,315);
            }
            else
            {
                label5.Visible = false;
                label6.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                txtnombre.Visible = false;
                txtapellido.Visible = false;

                groupBox1.Height = 310;

                btningresar.Location = new Point(337, 254);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Black;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Black;
        }

        private void txtVerify_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtVerify_Leave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Black;
        }

        private void txtnombre_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(175, 4, 4);
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Black;
        }

        private void txtapellido_Click(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(175, 4, 4);
        }
    }
}
