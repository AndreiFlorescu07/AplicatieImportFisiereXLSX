
namespace xTool.Forms
{
    partial class updateWithImportData
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
            this.startUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkTheTableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // startUpdate
            // 
            this.startUpdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.startUpdate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.startUpdate.Location = new System.Drawing.Point(12, 43);
            this.startUpdate.Name = "startUpdate";
            this.startUpdate.Size = new System.Drawing.Size(227, 29);
            this.startUpdate.TabIndex = 18;
            this.startUpdate.Text = "Efectueaza update-ul";
            this.startUpdate.UseVisualStyleBackColor = true;
            this.startUpdate.Click += new System.EventHandler(this.startImport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(766, 344);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // checkTheTableButton
            // 
            this.checkTheTableButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.checkTheTableButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkTheTableButton.Location = new System.Drawing.Point(257, 43);
            this.checkTheTableButton.Name = "checkTheTableButton";
            this.checkTheTableButton.Size = new System.Drawing.Size(179, 29);
            this.checkTheTableButton.TabIndex = 20;
            this.checkTheTableButton.Text = "Verifica tabela:";
            this.checkTheTableButton.UseVisualStyleBackColor = true;
            this.checkTheTableButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // updateWithImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkTheTableButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.startUpdate);
            this.Name = "updateWithImportData";
            this.Text = "updateWithImportData";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button checkTheTableButton;
    }
}