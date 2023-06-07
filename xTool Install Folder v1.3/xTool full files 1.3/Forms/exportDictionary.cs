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
    public partial class exportDictionary : Form
    {
        public exportDictionary()
        {
            InitializeComponent();
        }
        //le folosesc pt export
        private SqlCommand cmd = new SqlCommand();
        private DataTable drow = new DataTable();

        private void startExport_Click(object sender, EventArgs e)
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

                    string filePath = "C:\\temp\\" + currentDateTime + ".xlsx";

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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
