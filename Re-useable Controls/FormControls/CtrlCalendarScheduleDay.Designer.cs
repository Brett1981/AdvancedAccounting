namespace Re_useable_Controls.FormControls
{
    partial class CtrlCalendarScheduleDay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCalendarScheduleDay));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.btnMoveNextSlot = new Infragistics.Win.Misc.UltraButton();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraDayView1 = new Infragistics.Win.UltraWinSchedule.UltraDayView();
            this.ultraCalendarLook1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarLook();
            this.ultraMessageBoxManager1 = new Infragistics.Win.UltraMessageBox.UltraMessageBoxManager();
            this.ultraCalendarInfo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDayView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraPanel1
            // 
            this.ultraPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.btnMoveNextSlot);
            resources.ApplyResources(this.ultraPanel1, "ultraPanel1");
            this.ultraPanel1.Name = "ultraPanel1";
            // 
            // btnMoveNextSlot
            // 
            resources.ApplyResources(this.btnMoveNextSlot, "btnMoveNextSlot");
            this.btnMoveNextSlot.Name = "btnMoveNextSlot";
            this.btnMoveNextSlot.Click += new System.EventHandler(this.btnMoveNextSlot_Click);
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraPanel4);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraPanel3);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraPanel1);
            resources.ApplyResources(this.ultraPanel2, "ultraPanel2");
            this.ultraPanel2.Name = "ultraPanel2";
            // 
            // ultraPanel4
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ultraPanel4.Appearance = appearance1;
            this.ultraPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            // 
            // ultraPanel4.ClientArea
            // 
            this.ultraPanel4.ClientArea.Controls.Add(this.btnClose);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel1);
            resources.ApplyResources(this.ultraPanel4, "ultraPanel4");
            this.ultraPanel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ultraPanel4.Name = "ultraPanel4";
            // 
            // btnClose
            // 
            appearance2.BorderColor = System.Drawing.Color.Transparent;
            appearance2.BorderColor2 = System.Drawing.Color.Transparent;
            appearance2.BorderColor3DBase = System.Drawing.Color.Transparent;
            appearance2.Image = global::Re_useable_Controls.Properties.Resources.Cross;
            this.btnClose.Appearance = appearance2;
            this.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ultraLabel1
            // 
            appearance3.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(appearance3, "appearance3");
            this.ultraLabel1.Appearance = appearance3;
            resources.ApplyResources(this.ultraLabel1, "ultraLabel1");
            this.ultraLabel1.Name = "ultraLabel1";
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraDayView1);
            resources.ApplyResources(this.ultraPanel3, "ultraPanel3");
            this.ultraPanel3.Name = "ultraPanel3";
            // 
            // ultraDayView1
            // 
            this.ultraDayView1.BorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            resources.ApplyResources(this.ultraDayView1, "ultraDayView1");
            this.ultraDayView1.Name = "ultraDayView1";
            // 
            // ultraMessageBoxManager1
            // 
            this.ultraMessageBoxManager1.ContainingControl = this;
            // 
            // ultraCalendarInfo1
            // 
            this.ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            this.ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            // 
            // CtrlCalendarScheduleDay
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.ultraPanel2);
            this.Name = "CtrlCalendarScheduleDay";
            this.Load += new System.EventHandler(this.CtrlCalendarScheduleDay_Load);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ResumeLayout(false);
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDayView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.UltraWinSchedule.UltraDayView ultraDayView1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraButton btnMoveNextSlot;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarInfo ultraCalendarInfo1;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarLook ultraCalendarLook1;
        private Infragistics.Win.UltraMessageBox.UltraMessageBoxManager ultraMessageBoxManager1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel4;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}
