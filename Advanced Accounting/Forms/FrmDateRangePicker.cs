using System;
using System.Threading;
using System.Windows.Forms;
using Re_useable_Classes.Printing;
using Re_useable_Classes.SQL;
using Re_useable_Controls.FormControls;

namespace Advanced_Accounting.Forms
{
    public partial class FrmDateRangePicker : Form
    {
        private const int TimerInterval = 5000;
        private FrmExcel _aLogBookForm;
        private Thread _msOThread;

        public FrmDateRangePicker()
        {
            InitializeComponent();
            ctrlDate = new CtrlDateSelection();
        }

        private void btnOK_Click
            (
            object sender,
            EventArgs e)
        {
            GlobalSettings.ADateFrom = CtrlDateSelection.ADateFrom;
            GlobalSettings.ADateTo = CtrlDateSelection.ADateTo;

            GlobalSettings.DatesValid = true;
            if (!GlobalSettings.DatesValid)
            {
                return;
            }
            Close();
        }

        private void PrepareData()
        {
            _aLogBookForm = new FrmExcel
                (
                true,
                new PrintDgv())
                            {
                                TopMost = true,
                                StartPosition = FormStartPosition.CenterScreen
                            };

            
            _aLogBookForm.Show();

        }

        private void FrmDateRangePicker_FormClosed
            (
            object sender,
            FormClosedEventArgs e)
        {
            PrepareData();
        }
    }
}
