using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;       //Microsoft Excel 14 object in references-> COM tab
//pt deschiderea xml ului
using System.IO;
using xTool.Forms;
//#using dracia dracu;  <-- asta face tot codu, fara asta nu ar merge nimic






namespace xTool
{
    public partial class Form1 : Form
    {
        //le folosesc pt export
        private SqlCommand cmd = new SqlCommand();
        private DataTable drow = new DataTable();

        //campuri//fields
        private IconButton currentBtn;
            private Panel leftBorderBtn;
            private Form currentChildForm;
        //constructor/constructors
        public Form1()
        { 
        
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //form 
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        //structs 
        private struct RGBColors
        {
          public static Color color1 = Color.FromArgb(  172, 126, 241);
          public static Color color2 = Color.FromArgb(  249, 138, 176);
          public static Color color3 = Color.FromArgb(  253, 138, 114);
          public static Color color4 = Color.FromArgb(  95,  77,  221);
          public static Color color5 = Color.FromArgb(  249, 88,  155);
          public static Color color6 = Color.FromArgb(  24,  161, 251);
        }  




        //metode/methods
         private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //butoane/buttons
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //icon current child form
                currentMenuIcon.IconChar = currentBtn.IconChar;
                currentMenuIcon.IconColor = color;
                //ChildFormTitle.Text = currentBtn.Text;
            }
        }
        private void DisableButton()
        {
            if(currentBtn != null)
            {
               
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                //open form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            ChildFormTitle.Text = childForm.Text;
        }




        private void iconButton1_Click(object sender, EventArgs e)
        { //check db connection menu 
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Forms.checkDBconnection());


        }

        private void iconButton2_Click(object sender, EventArgs e)
        { //butonul de selectat fisierul
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Forms.importFilesInDB());

        }
        
        private void iconButton3_Click(object sender, EventArgs e)
        {
            //butonul care deschide pagina de import
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new Forms.importFilesInDB());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {//butonul de stergere tabela dictionaryimp;
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Forms.importFilesInDB());

            //start delete de table things
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

        private void iconButton5_Click(object sender, EventArgs e)
        { //meniul care face update ul intre tabele
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new Forms.updateWithImportData());
           
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {//menu -  export the dictionary table in excel;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new Forms.exportDictionary());
            

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void zphoto_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void zphoto2_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            currentMenuIcon.IconChar = IconChar.Home;
            currentMenuIcon.IconColor = Color.White;
            ChildFormTitle.Text = "Home";
        }

        //drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            //minimize button;
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //maximize button
            if(WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            //close button
            Application.Exit();
        }
    }
}
