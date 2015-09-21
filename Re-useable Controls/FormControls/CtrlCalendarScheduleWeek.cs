using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinSchedule;
using Day = Infragistics.Win.UltraWinSchedule.Day;

namespace Re_useable_Controls.FormControls
{
    public partial class CtrlCalendarScheduleWeek : UserControl
    {
        #region Private Members

        private DataSet ds;

        #endregion

        #region Constructor

        public CtrlCalendarScheduleWeek()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        #region Form Load Event

        private void CtrlCalendarScheduleWeek_Load
            (
            object sender,
            EventArgs e)
        {
            ds = new DataSet();
            // Read the Schedule xml file into the DataSet
            ds.ReadXml("../../Data/Schedule.xml");

            // Set the BindingContextControl so the component will use the same context that other controls on the form use.
            ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            // Set the BindingContextControl so the component will use the same context  that other controls on the form use.
            ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;


            // TODO:1. Set the DataSource and DataMember for binding appointments using the SetDataBinding method
            // this.ultraCalendarInfo1.DataBindingsForAppointments.SetDataBinding(ds, "Appointment");
            // this.ultraCalendarInfo1.DataBindingsForOwners.SetDataBinding(ds, "Owner");


            // TODO:2. Set the properties for AppointmentsDataBinding and OwnersDataBinding objects
            // this.ultraCalendarInfo1.DataBindingsForAppointments.StartDateTimeMember = "StartTime";
            // this.ultraCalendarInfo1.DataBindingsForAppointments.EndDateTimeMember = "EndTime";
            // this.ultraCalendarInfo1.DataBindingsForAppointments.SubjectMember = "Subject";
            // this.ultraCalendarInfo1.DataBindingsForAppointments.OwnerKeyMember = "OwnerKey";
            // this.ultraCalendarInfo1.DataBindingsForOwners.KeyMember = "OwnerKey";
            // this.ultraCalendarInfo1.DataBindingsForOwners.NameMember = "Name";

            // TODO:3. Assign UltraCalendarInfo component to the CalendarInfo property of UltraWeekView control.
            // this.ultraWeekView1.CalendarInfo = this.ultraCalendarInfo1;


            // Show July 2nd 2010 as the active day in UltraWeekView
            var datetimeToShow = new DateTime
                (
                2010,
                7,
                2);
            Day activeDate;
            activeDate = ultraCalendarInfo1.GetDay
                (
                    datetimeToShow,
                    true);
            ultraCalendarInfo1.ActiveDay = activeDate;

            // Hide the Unassigned Owner from view.
            ultraCalendarInfo1.Owners.UnassignedOwner.Visible = false;
            ultraWeekView1.OwnerDisplayStyle = OwnerDisplayStyle.Separate;
            // A DropDown button is visible on the right corner of the control's Owner header. 
            // Click the drop down to see the list of Owners and to navigate through them.
            ultraWeekView1.OwnerNavigationStyle = OwnerNavigationStyle.DropDown;

            // TODO: Set the ViewStyle for UltraCalendarLook and assign it to UltraWeekView
            // Styling through AppStylist is a better way of styling the controls.
            // See Program.cs file for AppStyling code.
            // this.ultraCalendarLook1.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.Office2007;
            // this.ultraWeekView1.CalendarLook = this.ultraCalendarLook1;
        }

        #endregion

        #region Appointments Dragging Event

        private void ultraWeekView1_AppointmentsDragging
            (
            object sender,
            AppointmentsDraggingEventArgs e)
        {
            var control = sender as ControlWithActivityBase;
            //Get WinSchedule control name
            Console.WriteLine(control.Name);
            // Write whether the drag operation is in beginning, progress or ending phase to the output window.
            Console.WriteLine(e.Phase.ToString());
            Console.WriteLine(e.InitialOwner.ToString());

            //Date Time of the appointment
            Console.WriteLine(e.InitialDateTime.ToString());

            //New Date Time to which the appointment has moved
            Console.WriteLine(e.NewDateTime.ToString());

            //Prevent dragging appointment from one Owner to another
            e.AllowOwnerChange = false;
        }

        #endregion

        #region Activities DragComplete Event

        private void ultraWeekView1_ActivitiesDragComplete
            (
            object sender,
            ActivitiesDragCompleteEventArgs e)
        {
            Console.WriteLine("The Appointments that were dragged are: ");
            foreach (Appointment selectedAppt in ultraCalendarInfo1.SelectedAppointments)
            {
                // TODO: At run time drag an appointment.View the dragged appointment names in the output window.
                // Console.WriteLine("\n"+selectedAppt);
            }
        }

        #endregion

        private void btnAddNewAppoint_Click
            (
            object sender,
            EventArgs e)
        {
            // TODO: Call the PerformAction method to add a new appointment.
            // this.ultraWeekView1.PerformAction(Infragistics.Win.UltraWinSchedule.WeekView.UltraWeekViewAction.AddNewAppointment,false,false);
            // TODO: Browse through the other enum values for various other actions that you can perform
            // There are many more actions that you can choose to perform.
        }

        #endregion
    }
}
