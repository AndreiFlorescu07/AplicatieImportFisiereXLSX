
namespace xTool.Forms
{
    partial class exportDictionary
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
            this.startExport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // startExport
            // 
            this.startExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.startExport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.startExport.Location = new System.Drawing.Point(23, 68);
            this.startExport.Name = "startExport";
            this.startExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startExport.Size = new System.Drawing.Size(227, 29);
            this.startExport.TabIndex = 19;
            this.startExport.Text = "Efectueaza exportul";
            this.startExport.UseVisualStyleBackColor = true;
            this.startExport.Click += new System.EventHandler(this.startExport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 103);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(765, 17);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // exportDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.startExport);
            this.Name = "exportDictionary";
            this.Text = "ExportDictionary";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startExport;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}