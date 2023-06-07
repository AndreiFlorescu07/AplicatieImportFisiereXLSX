
namespace xTool.Forms
{
    partial class checkDBconnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(checkDBconnection));
            this.checkDBPanel = new System.Windows.Forms.Panel();
            this.button77 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CheckLabel = new System.Windows.Forms.Label();
            this.checkDBPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkDBPanel
            // 
            this.checkDBPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
            this.checkDBPanel.Controls.Add(this.CheckLabel);
            this.checkDBPanel.Controls.Add(this.pictureBox1);
            this.checkDBPanel.Controls.Add(this.button77);
            this.checkDBPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkDBPanel.Location = new System.Drawing.Point(0, 0);
            this.checkDBPanel.Name = "checkDBPanel";
            this.checkDBPanel.Size = new System.Drawing.Size(800, 450);
            this.checkDBPanel.TabIndex = 0;
            // 
            // button77
            // 
            this.button77.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.button77.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button77.Location = new System.Drawing.Point(518, 50);
            this.button77.Name = "button77";
            this.button77.Size = new System.Drawing.Size(177, 88);
            this.button77.TabIndex = 0;
            this.button77.Text = "Press me!";
            this.button77.UseVisualStyleBackColor = true;
            this.button77.Click += new System.EventHandler(this.button77_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CheckLabel
            // 
            this.CheckLabel.AutoSize = true;
            this.CheckLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.CheckLabel.ForeColor = System.Drawing.Color.White;
            this.CheckLabel.Location = new System.Drawing.Point(293, 83);
            this.CheckLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CheckLabel.Name = "CheckLabel";
            this.CheckLabel.Size = new System.Drawing.Size(208, 23);
            this.CheckLabel.TabIndex = 3;
            this.CheckLabel.Text = "Verifica conexiunea:";
            // 
            // checkDBconnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkDBPanel);
            this.Name = "checkDBconnection";
            this.Text = "DBcHECK";
            this.checkDBPanel.ResumeLayout(false);
            this.checkDBPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel checkDBPanel;
        private System.Windows.Forms.Button button77;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label CheckLabel;
    }
}