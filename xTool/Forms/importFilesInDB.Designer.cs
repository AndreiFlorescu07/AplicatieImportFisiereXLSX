
namespace xTool.Forms
{
    partial class importFilesInDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.startImport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(198, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(580, 20);
            this.textBox1.TabIndex = 0;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.PathLabel.ForeColor = System.Drawing.Color.White;
            this.PathLabel.Location = new System.Drawing.Point(195, 51);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(100, 18);
            this.PathLabel.TabIndex = 2;
            this.PathLabel.Text = "File Path ... ";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.button6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button6.Location = new System.Drawing.Point(10, 114);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(179, 29);
            this.button6.TabIndex = 13;
            this.button6.Text = "Verifica tabela:";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(198, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(579, 9);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.button1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button1.Location = new System.Drawing.Point(10, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "Alege fisierul:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // startImport
            // 
            this.startImport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.startImport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.startImport.Location = new System.Drawing.Point(10, 78);
            this.startImport.Name = "startImport";
            this.startImport.Size = new System.Drawing.Size(179, 29);
            this.startImport.TabIndex = 17;
            this.startImport.Text = "Efectueaza importul";
            this.startImport.UseVisualStyleBackColor = true;
            this.startImport.Click += new System.EventHandler(this.startImport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(10, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(839, 350);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // importFilesInDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
            this.ClientSize = new System.Drawing.Size(872, 511);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.startImport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.textBox1);
            this.Name = "importFilesInDB";
            this.Text = "ImportFiles";
            this.Load += new System.EventHandler(this.CheckConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button startImport;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}