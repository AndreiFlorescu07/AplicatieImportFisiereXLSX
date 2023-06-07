
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
            this.emagLounchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startExport
            // 
            this.startExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.startExport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.startExport.Location = new System.Drawing.Point(31, 84);
            this.startExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startExport.Name = "startExport";
            this.startExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startExport.Size = new System.Drawing.Size(303, 36);
            this.startExport.TabIndex = 19;
            this.startExport.Text = "Efectueaza exportul";
            this.startExport.UseVisualStyleBackColor = true;
            this.startExport.Click += new System.EventHandler(this.startExport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 127);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1020, 21);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // emagLounchButton
            // 
            this.emagLounchButton.Location = new System.Drawing.Point(138, 268);
            this.emagLounchButton.Name = "emagLounchButton";
            this.emagLounchButton.Size = new System.Drawing.Size(75, 23);
            this.emagLounchButton.TabIndex = 21;
            this.emagLounchButton.Text = "EMAG";
            this.emagLounchButton.UseVisualStyleBackColor = true;
            this.emagLounchButton.Click += new System.EventHandler(this.emagLounchButton_Click);
            // 
            // exportDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.emagLounchButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.startExport);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "exportDictionary";
            this.Text = "ExportDictionary";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startExport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button emagLounchButton;
    }
}