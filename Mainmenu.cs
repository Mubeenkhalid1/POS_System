using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Mainmenu : MetroFramework.Forms.MetroForm
    {
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order odr = new Order();
            odr.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
