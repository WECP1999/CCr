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
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }
        private int time;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            FirstMenu frm = new FirstMenu();
            if (time == 5)
            {
                this.Hide();
                frm.Show();
            }
        }
    }
}
