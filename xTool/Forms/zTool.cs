using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;       //Microsoft Excel 14 object in references-> COM tab


//using Excel Microsoft.Office.Interop.Excel;
//using System.Reflection;
using System.Runtime.InteropServices;
//pt deschiderea xml ului
using System.IO;
//#using dracia dracu;  <-- asta face tot codu, fara asta nu ar merge nimic


namespace WindowsFormsApp1
{
    public partial class zTool : Form
    {
        //BackgroundWorker worker = new BackgroundWorker();
        // private static object sharedStringTablePart;

        public zTool()
        {
            InitializeComponent();




        }
        //le folosesc pt export
        private SqlCommand cmd = new SqlCommand();
        private DataTable drow = new DataTable();


        //folosesc la redimensionarea ferestrei
        private FormWindowState previousWindowState; // variabila pentru a urmări starea anterioară a ferestrei



        private void ZTool_Resize(object sender, EventArgs e)
        {
            // Verifica dacă dimensiunea ferestrei a fost schimbată de la starea normală la starea maximizată
            
            if (previousWindowState == FormWindowState.Normal && WindowState == FormWindowState.Maximized)
            {
                MessageBox.Show("Fereastra a fost maximizată!");
            }
            // Verifica dacă dimensiunea ferestrei a fost schimbată de la starea maximizată la starea normală
            else if (previousWindowState == FormWindowState.Maximized && WindowState == FormWindowState.Normal)
            {
                MessageBox.Show("Fereastra a fost restaurată la dimensiunea normală!");
            }

            // Actualizează starea anterioară a ferestrei
            previousWindowState = WindowState;
        }






        private void button1_Click(object sender, EventArgs e)
        {//pick a file/ chose a file
            string filePath = OpenFilePicker();

            //pun calea intr-un string
            if (filePath != null) {
                //verific string ul sa nu fie null
                textBox1.Text = filePath;
                //completez casuta de path cu calea aleasa
            }
            else {
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
        private void button3_Click(object sender, EventArgs e)
        {//check db connection button 
            //ShowProgressBar();
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

        private void button2_Click(object sender, EventArgs e)
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


        private void button4_Click(object sender, EventArgs e)
        {
            // Connection string to  database
            string connectionString = "Data Source=192.168.180.15;Initial Catalog=Localize_Hercules;User ID=sa;Password=UniDB!Admin;";

            // Name of the table we want to delete data from
            string tableName = "DICTIONARYIMP";

            
            
            try
            {
                //we connect to the database;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command to delete all records from the table
                    string sql = "delete from " + tableName;
                    //execute the command
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    // Display a message indicating the data was deleted successfully
                    MessageBox.Show("Liniile din tabela DICTIONARYIMP au fost sterse!");
                }
            }
            catch (Exception ex)
            {
                // afisez mesajele de eroare;
                MessageBox.Show("Eroare stergere date: " + ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //function that export the dictionary table in excel;


            // Create a new Excel workbook and worksheet
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            string connectionString = "Data Source=192.168.180.15;Initial Catalog=Localize_Hercules;User ID=sa;Password=UniDB!Admin;";
            try
            {
                
                string currentDateTime = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss");

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand object and execute the query
                    cmd = new SqlCommand("select ID , RESTEXT, TRANS01, TRANS02  from DICTIONARY", connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int totalRows = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            totalRows++;
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = totalRows;
                    progressBar1.Value = 0;
                    reader.Close();
                    reader = cmd.ExecuteReader();




                    // Write the column headers to the worksheet
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        worksheet.Cells[1, i + 1] = reader.GetName(i);
                    }

                    // Write the data to the worksheet
                    int row = 2;
                    
                    while (reader.Read())
                    {

                       
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            worksheet.Cells[row, j + 1] = reader.GetValue(j).ToString();
                        }
                        row++;
                        // Actualizează valoarea progresului și afișează-o în ProgressBar
                        progressBar1.Value = row - 2;
                        progressBar1.Refresh();
                    }

                    reader.Close();

                    // Save the workbook and close it
                    
                    string filePath = "C:\\temp\\"+ currentDateTime+".xlsx";

                    //check if the folder path exist
                    string folderPath = @"C:\temp\";
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    workbook.SaveAs(filePath);
                    progressBar1.Value = progressBar1.Maximum;
                    progressBar1.Refresh();

                    MessageBox.Show("Exportul a fost finalizat!");
                }

            }
            catch (Exception ex)
            {
                // afisez mesajele de eroare;
                MessageBox.Show("Eroare export:" + ex.Message);
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
                Marshal.ReleaseComObject(worksheet);

                //close and release
                workbook.Close();
                Marshal.ReleaseComObject(workbook);

                //quit and release
                excel.Quit();
                Marshal.ReleaseComObject(excel);


                // Cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // Release COM objects
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excel);
            }


            
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
                            
                            if(dialogResult == DialogResult.Yes)
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



    }
}

/*
 
 ---> comentarii < ---

select id , count(*) from DICTIONARYIMP group by id having count (*) >1 
 

 */


