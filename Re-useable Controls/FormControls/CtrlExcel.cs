using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Re_useable_Classes.Printing;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace Re_useable_Controls.FormControls
{
    public partial class CtrlExcel : UserControl
    {
        // Contains the path to the workbook file
        private static string _mExcelFileName = "";
        // Contains a reference to the hosting application
        // Contains a reference to the active workbook
        private Workbook _mWorkbook;
        private Application _mXlApplication;
        private PrintDgv aPrintdial;
        private object arrColumnLefts;
        private StringFormat strFormat;

        public CtrlExcel()
        {
            InitializeComponent();
        }

        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable
            (
            uint reserved,
            out IRunningObjectTable pprot);

        [DllImport("ole32.dll")]
        private static extern int CreateBindCtx
            (
            uint reserved,
            out IBindCtx pctx);

        public void OpenFile(string filename)
        {
            // Check the file exists
            if (!File.Exists(filename))
            {
                throw new Exception();
            }
            _mExcelFileName = filename;
            // Load the workbook in the WebBrowser control
            //webBrowser2.Navigate
            //    (
            //        filename,
            //        false);
        }

        public DataTable Data(string xlfile)
        {

            {
                var excelApp = new Application();
                Workbook workbook = excelApp.Workbooks.Open(xlfile);
                var worksheet = (Worksheet) workbook.Sheets["Sheet1"];

                int column = 0;
                int row = 0;

                Range range = worksheet.UsedRange;
                var dt = new DataTable();
                dt.Columns.Add(" ");
                dt.Columns.Add("Date");
                dt.Columns.Add("Details");
                dt.Columns.Add("Income");
                dt.Columns.Add("Mileage");
                dt.Columns.Add("Mot_Exps");
                dt.Columns.Add("PPSA");
                dt.Columns.Add("HP");
                dt.Columns.Add("Tel");
                dt.Columns.Add("PLH");
                dt.Columns.Add("Subs");
                dt.Columns.Add("Cleaning");
                dt.Columns.Add("Misc");
                dt.Columns.Add("Drawings");
                dt.Columns.Add("Bike");
                dt.Columns.Add("Other");
                dt.Columns.Add("Additional_Info");
                for (row = 2;
                     row <= range.Rows.Count;
                     row++)
                {
                    DataRow dr = dt.NewRow();
                    for (column = 1;
                         column <= range.Columns.Count;
                         column++)
                    {
                        dynamic range1 = range.Columns.Value2[row,
                            column];
                        if (range1 != null)
                        {
                            dr[column - 1] = range1;
                        }
                    }

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

                workbook.Close
                    (
                        true,
                        Missing.Value,
                        Missing.Value);
                excelApp.Quit();
                return dt;
            }
        }

        public void RetrieveWorkbook
            (
            string xlfile,
            PrintDgv aprintdialog)
        {
            aPrintdial = aprintdialog;
            dataGridView1.DataSource = Data(xlfile);
            var dgvstyle = new DataGridViewCellStyle
                           {
                               Format = "dd/MM/yyyy"
                           };
            dataGridView1.Columns[1].DefaultCellStyle = dgvstyle;
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[0].Visible = false;
            }
        }


        protected void OnClosed
            (
            object sender,
            EventArgs e)
        {
            try
            {
                // Quit Excel and clean up.
                if (_mWorkbook != null)
                {
                    _mWorkbook.Close
                        (
                            true,
                            Missing.Value,
                            Missing.Value);
                    Marshal.ReleaseComObject
                        (_mWorkbook);
                    _mWorkbook = null;
                }
                if (_mXlApplication == null)
                {
                    return;
                }
                _mXlApplication.Quit();
                Marshal.ReleaseComObject
                    (_mXlApplication);
                _mXlApplication = null;
                GC.Collect();
            }
            catch
            {
                MessageBox.Show(@"Failed to close the application");
            }
        }


        public Workbook RetrieveWorkbook(_Worksheet aWorksheet)
        {
            if (aWorksheet != null)
            {
                return null;
            }
            var aWorkbook = new Workbook();
            aWorksheet = (Worksheet) aWorkbook.Worksheets.Add();
            return aWorkbook;
        }


        private void toolStrip1_Click
            (
            object sender,
            EventArgs e)
        {
            //Calling DataGridView Printing
            PrintDgv.Print_DataGridView(dataGridView1);
        }
    }
}
