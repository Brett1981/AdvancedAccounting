using System;
using System.Windows.Forms;
using Re_useable_Classes.Message_Helpers.Forms;

namespace Re_useable_Controls.FormControls
{
    public partial class CtrlDateSelection : UserControl
    {
        public static DateTime ADateFrom;
        public static DateTime ADateTo;

        public CtrlDateSelection()
        {
            InitializeComponent();
            //13/06/2015 00:00:00
            dtpFrom.CustomFormat = @"dd'/'MM'/'yyyy hh':'mm':'ss";
            dtpTo.CustomFormat = @"dd'/'MM'/'yyyy hh':'mm':'ss";
        }

        private void dtpTo_ValueChanged
            (
            object sender,
            EventArgs e)
        {
            DateTime dateTimeFrom = Convert.ToDateTime(dtpFrom.Text);
            DateTime datetimeto = Convert.ToDateTime(dtpTo.Text);
            if (dateTimeFrom > DateTime.Now)
            {
                MessageDialog.Show
                    (
                        "Your Selected From Date can not be greater than the current DateTime!",
                        "Error With Selected Date"
                    );
            }
            if (dateTimeFrom > datetimeto)
            {
                MessageDialog.Show
                    (
                        "Your Selected To Date can not be greater than the From DateTime!",
                        "Error With Selected Date"
                    );
            }
            else
            {
                //Date OK

                ADateTo = datetimeto;
            }
        }

        private void dtpFrom_ValueChanged
            (
            object sender,
            EventArgs e)
        {
            DateTime dateTimeFrom = Convert.ToDateTime(dtpFrom.Text);
            DateTime datetimeto = Convert.ToDateTime(dtpTo.Text);
            if (dateTimeFrom > DateTime.Now)
            {
                MessageDialog.Show
                    (
                        "Your Selected From Date can not be greater than the current DateTime!",
                        "Error With Selected Date"
                    );
            }
            if (dateTimeFrom > datetimeto)
            {
                MessageDialog.Show
                    (
                        "Your Selected To Date can not be greater than the From DateTime!",
                        "Error With Selected Date"
                    );
            }
            else
            {
                //Date OK
                ADateFrom = dateTimeFrom;
            }
        }

        private void CtrlDateSelection_Validated
            (
            object sender,
            EventArgs e)
        {
            //Set the following in case no changes are made
            ADateTo = Convert.ToDateTime(dtpTo.Text);
        }
    }
}
