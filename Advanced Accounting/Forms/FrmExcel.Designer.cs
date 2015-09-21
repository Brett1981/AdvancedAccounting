namespace Advanced_Accounting.Forms
{
    partial class FrmExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExcel));
            this.ctrlExcel1 = new Re_useable_Controls.FormControls.CtrlExcel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlExcel1
            // 
            this.ctrlExcel1.AutoSize = true;
            this.ctrlExcel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlExcel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlExcel1.Location = new System.Drawing.Point(0, 0);
            this.ctrlExcel1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlExcel1.Name = "ctrlExcel1";
            this.ctrlExcel1.Size = new System.Drawing.Size(1051, 541);
            this.ctrlExcel1.TabIndex = 0;
            // 
            // ultraPanel1
            // 
            this.ultraPanel1.AutoSize = true;
            this.ultraPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ctrlExcel1);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(1051, 541);
            this.ultraPanel1.TabIndex = 1;
            // 
            // FrmExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 541);
            this.Controls.Add(this.ultraPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmExcel";
            this.Text = "Excel Preview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmExcel_FormClosed);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Re_useable_Controls.FormControls.CtrlExcel ctrlExcel1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
    }
}