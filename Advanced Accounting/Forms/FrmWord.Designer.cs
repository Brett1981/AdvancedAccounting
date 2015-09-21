namespace Advanced_Accounting.Forms
{
    partial class FrmWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWord));
            this.ctrlWord1 = new Re_useable_Controls.FormControls.CtrlWord();
            this.SuspendLayout();
            // 
            // ctrlWord1
            // 
            this.ctrlWord1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWord1.Location = new System.Drawing.Point(0, 0);
            this.ctrlWord1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlWord1.Name = "ctrlWord1";
            this.ctrlWord1.Size = new System.Drawing.Size(880, 553);
            this.ctrlWord1.TabIndex = 0;
            // 
            // FrmWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 553);
            this.Controls.Add(this.ctrlWord1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmWord";
            this.Text = "Word Previewer";
            this.ResumeLayout(false);

        }

        #endregion

        private Re_useable_Controls.FormControls.CtrlWord ctrlWord1;
    }
}