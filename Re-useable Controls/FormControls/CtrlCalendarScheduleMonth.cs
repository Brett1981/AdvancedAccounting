using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Infragistics.Win.UltraWinSchedule;
using Infragistics.Win.UltraWinSchedule.MonthViewSingle;
using Microsoft.Office.Interop.Outlook;
using Re_useable_Classes.Functions;
using Re_useable_Classes.Message_Helpers.Forms;
using Re_useable_Classes.Office;
using Re_useable_Classes.SQL;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Day = Infragistics.Win.UltraWinSchedule.Day;
using Exception = System.Exception;

namespace Re_useable_Controls.FormControls
{
    public partial class CtrlCalendarScheduleMonth : UserControl
    {
        public static Categories ACats;
        private bool IsClossing;
        //private Categories _oCats = oSes.DefaultStore.Categories;
        private Inspector _aInspector;
        private DataSet _ds;
        //using Microsoft.Office.Interop.Outlook
        //private static readonly Application oApp = new Application();
        //private static readonly NameSpace oSes = oApp.Session;
        private string _mapiId;
        private Form frmevents;

        #region Constructor

        public CtrlCalendarScheduleMonth()
        {
            InitializeComponent();
        }

        #endregion

        public AppointmentItem AnAppointment { get; set; }
        private DataTable ATable { get; set; }

        #region Private Members

        #endregion

        #region Event Handlers

        #region Form Load Event

        private void CtrlCalendarScheduleMonth_Load
            (
            object sender,
            EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            ultraCalendarInfo1.SaveSettings = false;
            _ds = new DataSet();
            var aOutlookClass = new OutlookClass();
            ATable = aOutlookClass.GetAllCalendarItems();
            _ds.Tables.Add(ATable);
            // Set the BindingContextControl so the component will use the same context that other controls on the form use.
            ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            // Set the BindingContextControl so the component will use the same context that other controls on the form use.
            ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            if (ATable != null)
            {
                GlobalSettings.CalendarData = ATable;
                foreach (DataRow row in _ds.Tables[0].Rows)
                {
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


            ultraCalendarInfo1.DataBindingsForAppointments.StartDateTimeMember = "StartDate";
            ultraCalendarInfo1.DataBindingsForAppointments.EndDateTimeMember = "EndDate";
            ultraCalendarInfo1.DataBindingsForAppointments.SubjectMember = "Subject";

            ultraMonthViewSingle1.CalendarInfo = ultraCalendarInfo1;

            DateTime datetimeToShow = DateTime.Now;
            Day activeDate = ultraCalendarInfo1.GetDay
                (
                    datetimeToShow,
                    true);
            ultraCalendarInfo1.ActiveDay = activeDate;

            // // Click the drop down button visible on the right corner of the control's Owner header for the list of Owners.
            //// ultraMonthViewSingle1.OwnerNavigationStyle = OwnerNavigationStyle.DropDown;

            // // TODO: Set the ViewStyle for UltraCalendarLook and assign it to ultraMonthViewSingle
            // // Styling through AppStylist is a better way of styling the controls.
            // // See Program.cs file for AppStyling code
            // // this.ultraCalendarLook1.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.Office2007;
            ultraMonthViewSingle1.CalendarLook = ultraCalendarLook1;
            Cursor = Cursors.Default;
        }

        #endregion

        #region Before Appointment Edit Event

        private void ultraMonthViewSingle1_BeforeAppointmentEdit
            (
            object sender,
            BeforeAppointmentEditEventArgs e)
        {
            //AddAppointment(e.Appointment);
            //if (e.Appointment.StartDateTime.Date != e.Appointment.EndDateTime.Date)
            //{
            //    // For a multi-day appointment inform the user that they do not have permission to edit the appointment.
            //    // TODO: Set the Cancel property to true to cancel editing of multi-day appointments.
            //    // You will be prompted with the message box which informs you that you cannot edit and cancels the edit.
            //    // You will still be able to resize and move the appointment.
            //    // MessageBox.Show("You do not have the appropriate permissions to edit this Appointment.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    // e.Cancel = true;
            //    // return;
            //}
        }

        #endregion Before Appointment Edit Event

        #region Before Perform Action Event

        private void ultraMonthViewSingle1_BeforePerformAction
            (
            object sender,
            BeforeMonthViewSinglePerformActionEventArgs e)
        {
            // Cancel the event if the action is "PreviousDay', to prevent the end user from navigating to the previous day via keyboard.
            if (e.Action == UltraMonthViewSingleAction.PreviousDay)
            {
                // TODO: Set the Cancel property to true to cancel navigating to the previous day via keyboard. 
                // e.Cancel = true;
                // MessageBox.Show("Cannot navigate to the previous day.");
            }
        }

        #endregion

        private void ultraCalendarInfo1_ValidateAppointment
            (
            object sender,
            ValidateAppointmentEventArgs e)
        {
            //	The CloseDialog property can be used to keep the dialog
            //	open until the state of the Appointment object meets
            //	certain requirements
            if (string.IsNullOrEmpty(e.Appointment.Description))
            {
                MessageBox.Show
                    (
                        @"You must enter a Description for this Appointment.",
                        @"ValidateAppointment",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                e.CloseDialog = false;
                return;
            }

            //	The OriginalAppointment property can be used to determine what changes,
            //	if any, were made to the appointment object
            string info = string.Empty;
            if (e.OriginalAppointment != null && e.OriginalAppointment.StartDateTime != e.Appointment.StartDateTime)
            {
                info += "The appointment's StartDateTime has changed." + "\n";
            }

            if (e.OriginalAppointment != null && e.OriginalAppointment.EndDateTime != e.Appointment.EndDateTime)
            {
                info += "The appointment's EndDateTime has changed." + "\n";
            }

            if (e.OriginalAppointment != null && e.OriginalAppointment.Subject != e.Appointment.Subject)
            {
                info += "The appointment's Subject has changed." + "\n";
            }

            if (e.OriginalAppointment != null && e.OriginalAppointment.Location != e.Appointment.Location)
            {
                info += "The appointment's Location has changed." + "\n";
            }

            if (e.OriginalAppointment != null && e.OriginalAppointment.Description != e.Appointment.Description)
            {
                info += "The appointment's Description has changed." + "\n";
            }

            //	If any of the properties we are concerned with changed, notify the end user
            if (info.Length > 0)
            {
                //MessageBox.Show(info, @"ValidateAppointment", MessageBoxButtons.OK);
            }
            else
            {
                AddAppointment(e.Appointment);
                e.SaveChanges = true;
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
                    _mapiId = app.EntryID;
                    GlobalSettings.AEntryId = _mapiId;
                    DeleteSQL(GlobalSettings.AEntryId);
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
                _mapiId = app.EntryID;
                //ACats = AddACategory();

                LoadEventDetails();
                IsClossing = true;
                return;
                // app.Display(true);
            }
        }

        private void OnNewInspector(Inspector inspector)
        {
            _aInspector = inspector;
            if ((inspector.CurrentItem) is AppointmentItem)
            {
                ((AppointmentItem) inspector.CurrentItem).Write += appointmentItem_Write;
            }
        }

        private void appointmentItem_Write(ref bool cancel)
        {
            AnAppointment = (AppointmentItem) _aInspector.CurrentItem;
            //ACats = AddACategory();

            var t = new Thread(LoadEventDetails);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            //  AnAppointment.Categories = acat.Count.ToString();
        }

        private void LoadEventDetails()
        {
            frmevents = AEventDetailsForm(ACats);

            if (frmevents == null)
            {
                return;
            }
            GlobalSettings.AEntryId = _mapiId;
            frmevents.ShowDialog();
        }

        private Form AEventDetailsForm(Categories acat)
        {
            ACats = acat;
            return frmevents;
        }

        //private static Categories AddACategory()
        //{
        //    const string aGet = "SELECT NCAT_NAME FROM `NL_CATEGORIES`";
        //    var aList = MySqlConnec.GetSetUpdateQueryData(MySqlConnec.ConDataBase, aGet);
        //    //dictionary to hold my categories
        //    var dCats = new Dictionary<string, OlCategoryColor>();
        //    foreach (var s in aList)
        //    {
        //        if (!string.IsNullOrEmpty(s))
        //        {
        //            dCats.Add(s, OlCategoryColor.olCategoryColorDarkPeach);
        //        }
        //    }

        //    var app = new Application();
        //    var categories = app.Session.Categories;
        //    foreach (var line in dCats)
        //    {
        //        var cid = line.Key;


        //        //Add categories
        //        if (CategoryExists(cid, app) == false)
        //        {
        //            categories.Add(cid, line.Value);
        //        }
        //    }
        //    return categories;
        //}

        //private static bool CategoryExists(string categoryName, Application app)
        //{
        //    try
        //    {
        //        var category =
        //            app.Session.Categories[categoryName];
        //        return category != null;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}


        private void AddAppointment(Appointment appointment)
        {
            var aOutlook = new ApplicationClass();
            try
            {
                var newAppointment =
                    (AppointmentItem)
                    aOutlook.Application.CreateItem(OlItemType.olAppointmentItem);
                OnNewInspector(newAppointment.GetInspector);

//                newAppointment.Display(true);
                newAppointment.Start = appointment.Start;
                newAppointment.End = appointment.End;
                newAppointment.Location = appointment.Location;
                newAppointment.Body =
                    appointment.Description;
                newAppointment.AllDayEvent = false;
                newAppointment.Subject = appointment.Subject;
                newAppointment.Save();
                newAppointment.Categories = AnAppointment.Categories;
                _mapiId = newAppointment.EntryID;
                int i = newAppointment.AllDayEvent
                            ? 1
                            : 0;
                //newAppointment.Display(false);
                if (string.IsNullOrEmpty(newAppointment.Subject))
                {
                    return;
                }
                string aInsert =
                    "INSERT INTO `LWG_DIARY`(`LWG_PRIMARY`, `LWG_TYPE`, `LWG_START`, `LWG_END`, `LWG_LOCATION`, `LWG_BODY`, "
                    +
                    "`LWG_ALLDAY`, `LWG_SUBJECT`, `LWG_ATTACHMENTS`, `LWG_CATEGORIES`, `LWG_DURATION`, `LWG_ISRECURRING`, "
                    +
                    "`LWG_MILLEAGE`, `LWG_ENTRY_ID`, `LWG_USER1`, `LWG_USER2`, `LWG_USER3`, `LWG_USER4`, `LWG_USER5`) "
                    +
                    "VALUES (0" + //LWG_PRIMARY always 0
                    ",1" + //LWG_TYPE 1 = Event
                    ",'" + newAppointment.Start + //LWG_START Start Date and Time Format '24/04/2015 00:00:00'
                    "','" + newAppointment.End + //LWG_END End Date and Time Format '24/04/2015 00:00:00'
                    "','" + newAppointment.Location + //LWG_LOCATION 
                    "','" + newAppointment.Body + //LWG_BODY Description
                    "'," + i + //LWG_ALLDAY 1= Allday 0 = Not All day
                    ",'" + newAppointment.Subject + //LWG_SUBJECT
                    "',''" + //LWG_ATTACHMENTS Binary Field 
                    ",''" + //LWG_CATEGORIES Code To assign to i.e. Nominal
                    ",'" + TimeDateChecker.GetTimeBetweenDates
                               (
                                   newAppointment.Start,
                                   newAppointment.End) + "'" +
                    //LWG_DURATION = difference between LWG_START and LWG_END
                    ",0" + //LWG_ISRECURRING 1= yes 0 =No
                    ",''" + //LWG_MILLEAGE
                    ",'" + _mapiId + "'" + //LWG_ENTRY_ID = Unique Diary Entry ID
                    ",''" + //LWG_USER1 - Custom Field
                    ",''" + //LWG_USER2 - Custom Field
                    ",''" + //LWG_USER3 - Custom Field
                    ",''" + //LWG_USER4 - Custom Field
                    ",''" + //LWG_USER5 - Custom Field
                    ")";
                GlobalSettings.AEntryId = _mapiId;
                MySqlConnec.GetSetUpdateQueryDataList
                    (
                        MySqlConnec.ConDataBase,
                        aInsert);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"The following error occurred: " + ex.Message);
            }
        }


        private void ultraMonthViewSingle1_MoreActivityIndicatorClicked
            (
            object sender,
            MoreActivityIndicatorClickedEventArgs e)
        {
            var aDayView = new CtrlCalendarScheduleDay(e.Day);
            Form aFrm = ((Control) sender).FindForm();
            aDayView.Parent = aFrm;
            aDayView.Show();
            aDayView.BringToFront();
        }

        #region GetCalendarEvents

        #endregion

        #region PublicEvents

        public void AddAppointment(Form aFrmEventDetails)
        {
            //Show the appointment dialog so user can add a new appointment
            //The appointment dialog should display initially using the current
            //ActiveDay
            Categories a = null;
            frmevents = aFrmEventDetails;

            ultraCalendarInfo1.DisplayAppointmentDialog
                (
                    ultraCalendarInfo1.ActiveDay.Date,
                    ultraCalendarInfo1.ActiveDay.Date,
                    false);
        }

        public void EditAppointment(Form aFrmEventDetails)
        {
            Categories a = null;
            frmevents = aFrmEventDetails;
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

        public void DeleteAppointments(Form aFrmEventDetails)
        {
            Categories a = null;
            frmevents = aFrmEventDetails;
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

        public void ViewDay
            (
            object sender,
            Day e)
        {
            var aDayView = new CtrlCalendarScheduleDay(e);
            //{ultraDayView1 = {CalendarInfo = ultraCalendarInfo1}};
            Form aFrm = ((Control) sender).FindForm();
            aDayView.Parent = aFrm;
            aDayView.Show();
            aDayView.BringToFront();
        }

        private void ultraCalendarInfo1_AfterCloseAppointmentDialog
            (
            object sender,
            AppointmentEventArgs e)
        {
            if (!IsClossing)
            {
                EditAppointments(ultraCalendarInfo1.SelectedAppointments[0]);
            }
            else
            {
                IsClossing = false;
            }
        }

        #endregion

        #endregion
    }
}
