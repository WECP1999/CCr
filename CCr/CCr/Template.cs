﻿using System;
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
    public partial class Template : Form
    {
        public Template()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnclose_MouseEnter(object sender, EventArgs e)
        {
            btnclose.ForeColor = Color.White;
            btnclose.BackColor = Color.Red;
        }

        private void btnclose_MouseLeave(object sender, EventArgs e)
        {
            btnclose.ForeColor = Color.Black;
            btnclose.BackColor = Color.Transparent;
        }

        private void btnminimyze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Template_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Template_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(246, 246, 246);
        }
    }
}
