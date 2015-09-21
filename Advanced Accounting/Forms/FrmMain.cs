using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Re_useable_Classes.Converters;
using Re_useable_Classes.Message_Helpers.Forms;
using Re_useable_Classes.Printing;
using Re_useable_Classes.SQL;

namespace Advanced_Accounting.Forms
{
    public partial class FrmMain : Form
    {
        private const int TimerInterval = 1;
        private Thread _msOThread;

        public FrmMain()
        {
            InitializeComponent();
           // GlobalSettings.aFrmEvents = new FrmEventDetails();
        }

        private void FrmMain_FormClosed
            (
            object sender,
            FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ultraToolbarsManager1_ToolClick
            (
            object sender,
            ToolClickEventArgs e)
        {
            var aFrmEventDetails = new FrmEventDetails();
            switch (e.Tool.Key)
            {
                case "AddEvent": // ButtonTool
                    ctrlCalendarScheduleMonth1.AddAppointment(aFrmEventDetails);
                    break;
                case "EditEvent": // ButtonTool
                    ctrlCalendarScheduleMonth1.EditAppointment(aFrmEventDetails);
                    break;
                case "RemoveEvent": // ButtonTool
                    ctrlCalendarScheduleMonth1.DeleteAppointments(aFrmEventDetails);
                    break;
                case "ViewDay": // ButtonTool

                    ctrlCalendarScheduleMonth1.ViewDay
                        (
                            this,
                            ctrlCalendarScheduleMonth1.ultraCalendarInfo1.ActiveDay);
                    break;
                case "LogBook": // ButtonTool
                    LoadForm();
                    break;
                case "ToExcel":
                    ExportToExcel(GlobalSettings.CalendarData);
                    break;
                case "PrintCalandar": // ButtonTool
                    ctrlCalendarScheduleMonth1.ultraSchedulePrintDocument1.Print();
                    break;
            }
        }

        private void ExportToExcel(DataTable calendarData)
        {
            if (calendarData != null)
            {
                var aprintdialog = new PrintDgv();
                try
                {
                    string currentLocation = AppDomain.CurrentDomain.BaseDirectory + "LogFileExports\\";
                    Directory.CreateDirectory(currentLocation);
                    string aFileLocation = DataTableToExcel.MyDataTableExtensions.ExportToExcel
                        (
                            calendarData,
                            currentLocation);

                    try
                    {
                        var afrmExcel = new FrmExcel();

                        afrmExcel.ctrlExcel1.RetrieveWorkbook
                            (
                                aFileLocation,
                                aprintdialog);
                        afrmExcel.Show();
                    }
                    catch (Exception e)
                    {
                        MessageDialog.Show
                            (
                                "ExportToExcel: Excel file could not be Opened!\n",
                                e.Message,
                                MessageDialog.MessageBoxButtons.Ok,
                                MessageDialog.MessageBoxIcon.Error,
                                e.Message + "\r\n\r\n" + e.StackTrace
                            );
                    }
                }
                catch (Exception e)
                {
                    MessageDialog.Show
                        (
                            "ExportToExcel: Excel file could not be Opened!\n",
                            e.Message,
                            MessageDialog.MessageBoxButtons.Ok,
                            MessageDialog.MessageBoxIcon.Error,
                            e.StackTrace
                        );
                }
            }
        }

        private void LoadForm()
        {
            var aRangePicker = new FrmDateRangePicker
                               {
                                   TopMost = true
                               };
            aRangePicker.Show();
        }
    }
}
