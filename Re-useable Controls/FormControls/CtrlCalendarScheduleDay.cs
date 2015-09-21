using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraMessageBox;
using Infragistics.Win.UltraWinSchedule;
using Microsoft.Office.Interop.Outlook;
using Re_useable_Classes.Message_Helpers.Forms;
using Re_useable_Classes.Office;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Application2 = System.Windows.Forms.Application;
using Day = Infragistics.Win.UltraWinSchedule.Day;
using Exception = System.Exception;


namespace Re_useable_Controls.FormControls
{
    public partial class CtrlCalendarScheduleDay : UserControl
    {
        #region Constructor

        public CtrlCalendarScheduleDay(Day day)
        {
            InitializeComponent();
            Aday = day;
        }

        #endregion

        public void AddAppointment()
        {
            //Show the appointment dialog so user can add a new appointment
            //The appointment dialog should display initially using the current
            //ActiveDay
            ultraCalendarInfo1.DisplayAppointmentDialog
                (
                    ultraCalendarInfo1.ActiveDay.Date,
                    ultraCalendarInfo1.ActiveDay.Date,
                    false);
        }

        public void EditAppointment()
        {
            //Check to see how many appointment are selected
            switch (ultraCalendarInfo1.SelectedAppointments.Count)
            {
                case 1: //One appointment selected
                    //Display the Appointment dialog to edit the appointment
                    ultraCalendarInfo1.AfterCloseAppointmentDialog += ultraCalendarInfo1_AfterCloseAppointmentDialog;
                    ultraCalendarInfo1.DisplayAppointmentDialog(ultraCalendarInfo1.SelectedAppointments[0]);


                    break;
                case 0: //No appointment selected
                    //Can't edit nothing
                    MessageDialog.Show
                        (
                            "Please Select An Event Before Selecting Edit Event",
                            "Can't Edit Nothing",
                            MessageDialog.MessageBoxButtons.Ok,
                            MessageDialog.MessageBoxIcon.Error);
                    break;
                default: //More than one appointment is selected. 
                    //Can't edit more than one at a time.
                    MessageDialog.Show
                        (
                            "You Have Multiple Events Selected. \r\nPlease Select A 'Single' Event Before Selecting Edit Event",
                            "Can't Edit More Than One At A Time",
                            MessageDialog.MessageBoxButtons.Ok,
                            MessageDialog.MessageBoxIcon.Error);
                    break;
            }
        }

        private void ultraCalendarInfo1_AfterCloseAppointmentDialog
            (
            object sender,
            AppointmentEventArgs e)
        {
            EditAppointments(ultraCalendarInfo1.SelectedAppointments[0]);
        }

        public void DeleteAppointments()
        {
            ////Confirm the deletion of all selected appointments
            ////If the user chooses No on the confirmation, then exit sub
            switch (MessageDialog.Show
                (
                    "Please Confirm The Deletion Of All Selected Events",
                    "Are You Sure?",
                    MessageDialog.MessageBoxButtons.YesNo,
                    MessageDialog.MessageBoxIcon.Question))
            {
                case MessageDialog.MessageBoxResult.No:

                    break;
                default:
                    object[] appts = ultraCalendarInfo1.SelectedAppointments.All;

                    ////Remove all selected appointments
                    foreach (Appointment aAppointment in appts)
                    {
                        DeleteAppointment(aAppointment);
                        ultraCalendarInfo1.Appointments.Remove(aAppointment);
                    }
                    break;
            }
        }

        private void DeleteAppointment(Appointment appointment)
        {
            var olApp = new Application();
            NameSpace olNamspace = olApp.GetNamespace("MAPI");
            MAPIFolder appointmentFolder = olNamspace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            appointmentFolder.Items.IncludeRecurrences = true;

            foreach (AppointmentItem app in appointmentFolder.Items)
            {
                if (app.Subject != appointment.Subject)
                {
                    continue;
                }
                if (app.Start.Date == appointment.Start.Date)
                {
                    app.Delete();
                }
            }
        }

        private void EditAppointments(Appointment appointment)
        {
            var olApp = new Application();
            NameSpace olNamspace = olApp.GetNamespace("MAPI");
            MAPIFolder appointmentFolder = olNamspace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            appointmentFolder.Items.IncludeRecurrences = true;

            foreach (AppointmentItem app in appointmentFolder.Items)
            {
                if (app.Subject != appointment.Subject)
                {
                    continue;
                }
                if (app.Start.Date != appointment.Start.Date)
                {
                    continue;
                }
                app.Start = appointment.Start;
                app.End = appointment.End;
                app.Location = appointment.Location;
                app.Body =
                    appointment.Description;
                app.AllDayEvent = false;
                app.Subject = appointment.Subject;
                app.Save();
                // app.Display(true);
            }
        }

        private void AddAppointment(Appointment appointment)
        {
            var aOutlook = new ApplicationClass();
            try
            {
                var newAppointment =
                    (AppointmentItem)
                    aOutlook.Application.CreateItem(OlItemType.olAppointmentItem);
                newAppointment.Start = appointment.Start;
                newAppointment.End = appointment.End;
                newAppointment.Location = appointment.Location;
                newAppointment.Body =
                    appointment.Description;
                newAppointment.AllDayEvent = false;
                newAppointment.Subject = appointment.Subject;
                newAppointment.Save();
                //newAppointment.Display(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"The following error occurred: " + ex.Message);
            }
        }

        #region Private Members

        // Declare a DataSet object
        private DataSet _ds;
        // Declare an UltraMessageBoxInfo object to hold inforamtion displayed on the messagebox.
        private UltraMessageBoxInfo _msgInfo;
        private Day Aday { get; set; }

        #endregion //Private Members

        #region Event Handlers

        #region Form Load Event

        private void CtrlCalendarScheduleDay_Load
            (
            object sender,
            EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ultraCalendarInfo1.Appointments.Clear();
            ultraCalendarInfo1.SaveSettings = false;
            _ds = new DataSet();
            var aOutlookClass = new OutlookClass();
            DataTable aTable = aOutlookClass.GetAllCalendarItems();
            _ds.Tables.Add(aTable);
            // Set the BindingContextControl so the component will use the same context that other controls on the form use.
            ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            // Set the BindingContextControl so the component will use the same context that other controls on the form use.
            ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            if (aTable != null)
            {
                foreach (DataRow row in _ds.Tables[0].Rows)
                {
                    if ((DateTime) row["StartDate"] != Aday.Date)
                    {
                        continue;
                    }
                    var startTime = (DateTime) row["StartTime"];
                    var endTime = (DateTime) row["Endtime"];
                    var startDateTime = (DateTime) row["StartDate"];
                    startDateTime = startDateTime.AddHours(startTime.Hour);
                    startDateTime = startDateTime.AddMinutes(startTime.Minute);
                    var endtDateTime = (DateTime) row["EndDate"];
                    endtDateTime = endtDateTime.AddHours(endTime.Hour);
                    endtDateTime = endtDateTime.AddMinutes(endTime.Minute);

                    var appointment = new Appointment
                        (
                        (DateTime) row["StartDate"],
                        (DateTime) row["EndDate"])
                                      {
                                          StartDateTime = startDateTime,
                                          EndDateTime = endtDateTime,
                                          Subject = row["Subject"].ToString(),
                                          AllDayEvent = (bool) row["AllDayEvent"],
                                          Location = row["Location"].ToString(),
                                          Description = row["Body"].ToString()
                                      };

                    ultraCalendarInfo1.Appointments.Add(appointment);
                }
            }
            //ultraCalendarInfo1.DataBindingsForAppointments.DataSource = ultraCalendarInfo1.Appointments;
            // TODO:2. Set the properties for AppointmentsDataBinding and OwnersDataBinding objects
            ultraCalendarInfo1.DataBindingsForAppointments.StartDateTimeMember = "StartTime";
            ultraCalendarInfo1.DataBindingsForAppointments.EndDateTimeMember = "EndTime";
            ultraCalendarInfo1.DataBindingsForAppointments.SubjectMember = "Subject";
            ultraCalendarInfo1.DataBindingsForAppointments.OwnerKeyMember = "OwnerKey";
            ultraCalendarInfo1.DataBindingsForOwners.KeyMember = "OwnerKey";
            ultraCalendarInfo1.DataBindingsForOwners.NameMember = "Name";
            //Ensure Day Selected Is Day Shown
            ultraCalendarInfo1.ActiveDay = Aday;
            ultraDayView1.CalendarInfo = ultraCalendarInfo1;
            Cursor = Cursors.Default;


            //// Show July 2nd 2010 as the active day in UltraDayView
            //var activeday = Aday;
            //this.ultraCalendarInfo1.ActiveDay = activeday;

            #region Grouping

            // TODO: You can change the grouping style to see the alternative grouping style.
            ultraDayView1.GroupingStyle = DayViewGroupingStyle.DateWithinOwner;

            #endregion

            #region Styling UltraDayView

            // TODO: Set the ViewStyle for UltraCalendarLook and assign it to UltraDayView
            // Styling through AppStylist is a better way of styling the controls.
            // See Program.cs file for AppStyling code.
            // this.ultraCalendarLook1.ViewStyle = ViewStyle.Office2007;
            // this.ultraDayView1.CalendarLook = this.ultraCalendarLook1;

            #endregion
        }

        #endregion //Form Load Event

        #region Appointment Resizing Event

        private void ultraDayView1_AppointmentResizing
            (
            object sender,
            AppointmentResizingEventArgs e)
        {
            _msgInfo = new UltraMessageBoxInfo();
            if (e.Phase == AppointmentResizePhase.Moving && e.NewDateTime > e.InitialDateTime.AddMinutes(60))
            {
                _msgInfo.Buttons = MessageBoxButtons.OKCancel;

                if (e.ResizeType == AppointmentResizeType.AdjustStartDateTime)
                {
                    _msgInfo.Text = "The start date time for the appointment '" + e.Appointment.Subject +
                                    "' varies by an hour from the initial start date time" + e.InitialDateTime +
                                    ". Do you want to continue re-sizing?";
                }
                else if (e.ResizeType == AppointmentResizeType.AdjustEndDateTime)
                {
                    _msgInfo.Text = "The end date time  for the appointment '" + e.Appointment.Subject +
                                    "' varies by an hour from the initial end date time" + e.InitialDateTime +
                                    ". Do you want to continue re-sizing?";
                }

                DialogResult result;
                result = ultraMessageBoxManager1.ShowMessageBox(_msgInfo);
                if (result == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region After Appointment Resized Event

        private void ultraDayView1_AfterAppointmentResized
            (
            object sender,
            AppointmentEventArgs e)
        {
            Console.WriteLine
                (
                    "The Appointment '" + e.Appointment.Subject +
                    "'s' Start date time or end date time has been re-sized.");
        }

        #endregion // After Appointment Resized Event

        #region After Appoitment Edited Event

        // This event will be fired when any of the Appointment property is modified.
        private void ultraDayView1_AfterAppointmentEdited
            (
            object sender,
            AppointmentEventArgs e)
        {
            Console.WriteLine("The Appointment '" + e.Appointment.Subject + "' has been modified.");
        }

        #endregion //After Appoitment Edited Event

        #region After Appointments Moved Event

        private void ultraDayView1_AfterAppointmentsMoved
            (
            object sender,
            AfterAppointmentsMovedEventArgs e)
        {
            foreach (Appointment appointment in e.Appointments)
            {
                Console.WriteLine
                    (
                        "Appointment '" + appointment.Subject +
                        "' has been moved. Its new Start time and End time are: " + appointment.StartDateTime +
                        " - " + appointment.EndDateTime);
            }
        }

        #endregion // After Appointments Moved Event

        # region Button click Event for Perform Action

        private void btnMoveNextSlot_Click
            (
            object sender,
            EventArgs e)
        {
            // TODO: Call the PerformAction method on UltraDayView control to simulate user interaction.
            // TODO:   1. Run the application and select a timeslot.
            // TODO:   2. Click the Button "Move to Next TimeSlot".
            ultraDayView1.PerformAction(UltraDayViewAction.NextTimeSlot);

            ultraCalendarInfo1.ActiveDay = Aday;
            ultraDayView1.CalendarInfo = ultraCalendarInfo1;
            // TODO: Browse through the following enum values for various other actions that you can perform
            // There are many more actions that you can choose to perform
            // For these actions to perform you may need to add additonal code that is related to each of the action.
            // this.ultraDayView1.PerformAction(UltraDayViewAction.CreateAppointmentAndEnterEditMode);
            // this.ultraDayView1.PerformAction(UltraDayViewAction.EndCurrentEditSaveChanges);
            // this.ultraDayView1.PerformAction(UltraDayViewAction.LastWorkingHourTimeSlot);
            // this.ultraDayView1.PerformAction(UltraDayViewAction.NextVisibleDay);
        }

        #endregion

        private void btnClose_Click
            (
            object sender,
            EventArgs e)
        {
            Dispose();
        }

        #endregion //Event Handlers
    }
}
