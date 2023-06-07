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
    public partial class importFilesInDB : Form
    {
        public importFilesInDB()
        {
            InitializeComponent();
        }


        private void CheckConnection_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Connect to your database
            SqlConnection conn = new SqlConnection("Data Source = 192.168.180.15; Initial Catalog = Localize_Hercules; User ID = sa; Password = UniDB!Admin; ");

            // Create a SQL query to retrieve data
            string query = "SELECT * FROM DICTIONARYIMP";

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

        

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //de pe butonul asta se completeaza calea catre fisier;
          
            //pick a file/ chose a file
                string filePath = OpenFilePicker();

                //pun calea intr-un string
                if (filePath != null)
                {
                    //verific string ul sa nu fie null
                    textBox1.Text = filePath;
                    //completez casuta de path cu calea aleasa
                }
                else
                {
                    MessageBox.Show("Alege un fisier de import!");
                    //afisez mesaj de eroare in caz ca butonul a fost apasat insa nu a fost ales nici un fisier';
                }
            
            
        }
        public string OpenFilePicker()
        {//deschide fereastra de selectie document;

            OpenFileDialog filePicker = new OpenFileDialog();
            filePicker.Title = "Select a File";
            filePicker.Filter = "All files (*.*)|*.*";

            if (filePicker.ShowDialog() == DialogResult.OK)
            {
                return filePicker.FileName;
            }
            else
            {
                return null;
            }
        }

        private void startImport_Click(object sender, EventArgs e)
        {
            string connectionString2 = "Data Source=192.168.180.15;Initial Catalog=Localize_Hercules;User ID=sa;Password=UniDB!Admin;";
            ImportExcelFile(textBox1.Text, connectionString2);
        }
        public void ImportExcelFile(string filePath, string connectionString)
        {
            try
            {

                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@filePath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int nrDeRanduriInserate = 0;
                int rowCount = xlRange.Rows.Count;
                //  int colCount = xlRange.Columns.Count;
                int totalRowCount = rowCount - 1;
                // Initialize progress bar
                progressBar1.Maximum = totalRowCount;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                try
                {
                    for (int i = 2; i <= rowCount; i++)
                    {
                        // for (int j = 1; j <= colCount; j++)
                        // {
                        //
                        //
                        //     //write the value to the console
                        //     if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        //         Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                        //
                        //     //add useful things here!   
                        // }

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string sql = "INSERT INTO DICTIONARYIMP (ID,RESTEXT,TRANS01,TRANS02) VALUES (@Value1, @Value2, @Value3, @Value4)";
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                                    command.Parameters.AddWithValue("@Value1", xlRange.Cells[i, 1].Value2.ToString());
                                else
                                    command.Parameters.AddWithValue("@Value1", DBNull.Value);
                                //MessageBox.Show(cellValues[0]);
                                if (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null)
                                    command.Parameters.AddWithValue("@Value2", xlRange.Cells[i, 2].Value2.ToString());
                                else
                                    command.Parameters.AddWithValue("@Value2", DBNull.Value);
                                // MessageBox.Show(cellValues[1]);
                                //aici crapa;
                                if (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null)
                                    command.Parameters.AddWithValue("@Value3", xlRange.Cells[i, 3].Value2.ToString());
                                else
                                    command.Parameters.AddWithValue("@Value3", DBNull.Value);
                                // MessageBox.Show(cellValues[2]);
                                //
                                if (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 4].Value2 != null)
                                    command.Parameters.AddWithValue("@Value4", xlRange.Cells[i, 4].Value2.ToString());
                                else
                                    command.Parameters.AddWithValue("@Value4", DBNull.Value);
                                //MessageBox.Show(cellValues[3]);
                                nrDeRanduriInserate += command.ExecuteNonQuery();


                                // Update progress bar

                                progressBar1.PerformStep();

                            }
                        }
                    }
                    // Call the button6_Click method
                    button6_Click(this, new EventArgs());
                    MessageBox.Show(nrDeRanduriInserate + " randuri au fost inserate cu succes!");

                }

                catch (Exception ex)
                {
                    // 
                    MessageBox.Show("Importul a fost efectuat! " + "S-au importat " + nrDeRanduriInserate.ToString() + " linii! " + "Cod eroare de confirmare: " + ex.Message);
                    //de verificat de ce nu scap de string or bynary data pentru ultimul rand;
                }
                finally
                {
                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);

                    //close and release
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);

                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                }

                MessageBox.Show("Importul a fost efectuat! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Importul nu am fost efectuat! " + "Cod eroare de confirmare: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
