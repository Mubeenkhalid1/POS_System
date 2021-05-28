using POS_System.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("Login_Details", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());

                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if(sdr.Read())
                        {
                            this.Hide();
                            Mainmenu mn = new Mainmenu();
                            mn.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username and Password", "Login Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                    }

                }
            }
        }

        private bool IsValid()
        {
            if(textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Username is Required!", "Form Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password is Required!", "Form Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       

        
    }
}
