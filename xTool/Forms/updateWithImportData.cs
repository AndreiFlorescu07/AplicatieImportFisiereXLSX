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
using FontAwesome.Sharp;
using Excel = Microsoft.Office.Interop.Excel;       //Microsoft Excel 14 object in references-> COM tab
using System.Runtime.InteropServices;
using System.IO;

namespace xTool.Forms
{
    public partial class updateWithImportData : Form
    {
        public updateWithImportData()
        {
            InitializeComponent();
        }

        private void startImport_Click(object sender, EventArgs e)
        {

            int nrDeRanduriUpdatate = 0;
            string connectionString = "Data Source=192.168.180.15;Initial Catalog=Localize_Hercules;User ID=sa;Password=UniDB!Admin;";
            try
            {
                if (CheckForDuplicates())
                {
                    return;
                }


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE FD SET FD.TRANS02 = FI.TRANS02 FROM DICTIONARY FD INNER JOIN DICTIONARYIMP FI ON FD.ID = FI.ID AND FI.TRANS02 != 'NULL' AND FI.TRANS02 != '' AND FI.ID != ''";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        nrDeRanduriUpdatate += command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Au fost sincronizate liniile din DICTIONARYIMP cu cele din DICTIONARY! Nr linii updatate: " + nrDeRanduriUpdatate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare sincronizare date: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Connect to your database
            SqlConnection conn = new SqlConnection("Data Source = 192.168.180.15; Initial Catalog = Localize_Hercules; User ID = sa; Password = UniDB!Admin; ");

            // Create a SQL query to retrieve data
            string query = "SELECT * FROM DICTIONARY";

            // Create a SqlDataAdapter object to fill the DataGridView
            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            // Create a DataTable object to hold the data
            DataTable dt = new DataTable();

            // Fill the DataTable with the data from the database
            da.Fill(dt);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dt;
        }


        private bool CheckForDuplicates()
        {
            string connectionString = "Data Source=192.168.180.15;Initial Catalog=Localize_Hercules;User ID=sa;Password=UniDB!Admin;";
            string sql = "SELECT ID, COUNT(*) AS DUPLICATES FROM DICTIONARYIMP GROUP BY ID HAVING COUNT(*) > 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            string message = "Urmatoarele ID uri sunt duplicate in DICTIONARYIMP:\n";
                            while (reader.Read())
                            {
                                message += "ID: " + reader["ID"] + ", Duplicate: " + reader["DUPLICATES"] + "\n\n";
                            }

                            //MessageBox.Show(message); 
                            DialogResult dialogResult = MessageBox.Show(message + "Doriti sa continuati?", "Confirmare", MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // Se continuă cu update-ul 
                                return false;
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                // Se oprește update-ul
                                MessageBox.Show("Update ul a fost oprit de catre utilizator!");
                                return true;
                            }



                        }
                        else
                        {
                            MessageBox.Show("Randurile inserate in tabela DICTIONARYIMP au fost verificate cu succes, se va efectua update ul!");
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
