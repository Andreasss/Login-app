using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string dbName = "myAppDB.mdf";
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + dbName + "; Integrated Security=True;";

        public object Dashboard { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }
        
        private void applogin_click(object sender, EventArgs e)
        {

        }
         

        private void applogin_click(object sender, MouseEventArgs e)
        {
            string query = "SELECT * FROM users where username='" + textBox3.Text + "' and password = '" + textBox4.Text + "'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dbtable = new DataTable();
                adapter.Fill(dbtable);

                if(dbtable.Rows.Count == 1)
                {
                    AppView mainForm = new AppView();
                    mainForm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password. Please try again.", "Error");
                }
            }
        }
    }
}
