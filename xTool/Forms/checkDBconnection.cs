using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace xTool.Forms
{
    public partial class checkDBconnection : Form
    {
        public checkDBconnection()
        {
            InitializeComponent();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            // butonul asta lanseaza verificarea de conexiune cu baza de date;
            // this is the connection string , with this one we connect via sqlConnection property from below
            string connectionString = "Data Source=192.168.180.15;Initial Catalog=Localize_Hercules;User ID=sa;Password=UniDB!Admin;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connection successful!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: Conexiunea nu s-a putut realiza. Verifica VPN ul! Eroare la conectare: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
