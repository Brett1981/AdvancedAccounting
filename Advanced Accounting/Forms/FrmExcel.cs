using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Re_useable_Classes.Converters;
using Re_useable_Classes.Message_Helpers.Forms;
using Re_useable_Classes.Printing;
using Re_useable_Classes.SQL;

namespace Advanced_Accounting.Forms
{
    public partial class FrmExcel : Form
    {
        public FrmExcel(string selectedFilePath)
        {
            InitializeComponent();
            var aprintdialog = new PrintDgv();
            ctrlExcel1.RetrieveWorkbook
                (
                    selectedFilePath,
                    aprintdialog);
        }

        public FrmExcel
            (
            bool showDateTime,
            PrintDgv aprintdialog)
        {
            InitializeComponent();
            string aGet =
                "SELECT '' ,`LWG_START` AS Date,  `LWG_CATEGORIES` AS Details, `LWG_INCOME` AS Income, `LWG_MILLEAGE` AS Mileage,  `LWG_MOT_EXPS` AS Mot_Exps, `LWG_PPSA` AS PPSA, `LWG_HP` AS HP, `LWG_TELEPHONE` AS Tel,  `LWG_PLH` AS PLH, `LWG_SUBS` AS Subs, `LWG_CLEANING` AS Cleaning, `LWG_MISC` AS Misc, `LWG_DRAWINGS` AS Drawings, `LWG_BIKE` AS Bike,`LWG_OTHER` AS Other, `LWG_ADD_INFO` AS Additional_Info FROM `LWG_DIARY`"
                +
                " WHERE (`LWG_START` BETWEEN '" + GlobalSettings.ADateFrom + "' AND '" + GlobalSettings.ADateTo + "')";
            var dgv = new DataGridView();
            dgv = MySqlConnec.GetSetUpdateQueryData
                (
                    MySqlConnec.ConDataBase,
                    aGet,
                    dgv);


            if ((((DataTable) (dgv.DataSource)).Rows.Count <= 0))
            {
                return;
            }
            try
            {
                string currentLocation = AppDomain.CurrentDomain.BaseDirectory + "LogFileExports\\";
                Directory.CreateDirectory(currentLocation);
                ((DataTable)(dgv.DataSource)).Columns[1].DataType = typeof(string);
                string aFileLocation = DataTableToExcel.MyDataTableExtensions.ExportToExcel
                    (
                        (DataTable) (dgv.DataSource),
                        currentLocation);

                try
                {
                    ctrlExcel1.RetrieveWorkbook
                        (
                            aFileLocation,
                            aprintdialog);
                    
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

        public FrmExcel()
        {
            InitializeComponent();
        }

        private void FrmExcel_FormClosed
            (
            object sender,
            FormClosedEventArgs e)
        {
            GlobalSettings.IsLoading = false;
        }
    }
}
