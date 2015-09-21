namespace Re_useable_Controls.FormControls
{
    partial class CtrlCalendarScheduleMonth
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
            this.components = new System.ComponentModel.Container();
            this.ultraMonthViewSingle1 = new Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle();
            this.ultraCalendarInfo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(this.components);
            this.ultraCalendarLook1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarLook(this.components);
            this.ultraSchedulePrintDocument1 = new Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewSingle1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraMonthViewSingle1
            // 
            this.ultraMonthViewSingle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraMonthViewSingle1.Location = new System.Drawing.Point(0, 0);
            this.ultraMonthViewSingle1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ultraMonthViewSingle1.Name = "ultraMonthViewSingle1";
            this.ultraMonthViewSingle1.Size = new System.Drawing.Size(786, 452);
            this.ultraMonthViewSingle1.TabIndex = 0;
            this.ultraMonthViewSingle1.BeforePerformAction += new Infragistics.Win.UltraWinSchedule.BeforeMonthViewSinglePerformActionEventHandler(this.ultraMonthViewSingle1_BeforePerformAction);
            this.ultraMonthViewSingle1.BeforeAppointmentEdit += new Infragistics.Win.UltraWinSchedule.BeforeAppointmentEditEventHandler(this.ultraMonthViewSingle1_BeforeAppointmentEdit);
            this.ultraMonthViewSingle1.MoreActivityIndicatorClicked += new Infragistics.Win.UltraWinSchedule.MoreActivityIndicatorClickedEventHandler(this.ultraMonthViewSingle1_MoreActivityIndicatorClicked);
            // 
            // ultraCalendarInfo1
            // 
            this.ultraCalendarInfo1.AlternateSelectTypeDay = Infragistics.Win.UltraWinSchedule.SelectType.ExtendedAutoDrag;
            this.ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            this.ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            this.ultraCalendarInfo1.FirstDayOfWeek = Infragistics.Win.UltraWinSchedule.FirstDayOfWeek.Monday;
            this.ultraCalendarInfo1.SaveSettings = true;
            this.ultraCalendarInfo1.SaveSettingsCategories = ((Infragistics.Win.UltraWinSchedule.CalendarInfoCategories)((Infragistics.Win.UltraWinSchedule.CalendarInfoCategories.Appointments | Infragistics.Win.UltraWinSchedule.CalendarInfoCategories.Holidays)));
            this.ultraCalendarInfo1.SaveSettingsFormat = Infragistics.Win.SaveSettingsFormat.Xml;
            this.ultraCalendarInfo1.SelectTypeDay = Infragistics.Win.UltraWinSchedule.SelectType.ExtendedAutoDrag;
            this.ultraCalendarInfo1.SettingsKey = "CtrlCalendarScheduleMonth.ultraCalendarInfo1";
            this.ultraCalendarInfo1.ValidateAppointment += new Infragistics.Win.UltraWinSchedule.ValidateAppointmentEventHandler(this.ultraCalendarInfo1_ValidateAppointment);
            // 
            // ultraSchedulePrintDocument1
            // 
            this.ultraSchedulePrintDocument1.CalendarInfo = this.ultraCalendarInfo1;
            this.ultraSchedulePrintDocument1.CalendarLook = this.ultraCalendarLook1;
            this.ultraSchedulePrintDocument1.PrintStyle = Infragistics.Win.UltraWinSchedule.SchedulePrintStyle.Monthly;
            // 
            // CtrlCalendarScheduleMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraMonthViewSingle1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CtrlCalendarScheduleMonth";
            this.Size = new System.Drawing.Size(786, 452);
            this.Load += new System.EventHandler(this.CtrlCalendarScheduleMonth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewSingle1)).EndInit();
            ((System.Configuration.IPersistComponentSettings)(this.ultraCalendarInfo1)).LoadComponentSettings();
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.UltraWinSchedule.UltraCalendarInfo ultraCalendarInfo1;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarLook ultraCalendarLook1;
        public Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle ultraMonthViewSingle1;
        public Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument ultraSchedulePrintDocument1;
    }
}
