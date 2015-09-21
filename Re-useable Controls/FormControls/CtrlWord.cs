using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;

namespace Re_useable_Controls.FormControls
{
    public partial class CtrlWord : UserControl
    {
        // Contains the path to the workbook file
        private static string _mWordFileName = "";
        // Contains a reference to the hosting application
        private Application _mWordApplication;
        // Contains a reference to the active workbook
        private Document _mWorkbook;

        public CtrlWord()
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
            _mWordFileName = filename;
            // Load the WorkBook in the WebBrowser control
            webBrowser1.Navigate
                (
                    filename,
                    false);
        }

        public Document RetrieveDocument(string wordfile)
        {
            _mWordFileName = wordfile;
            IRunningObjectTable prot = null;
            IEnumMoniker pmonkenum = null;
            try
            {
                IntPtr pfetched = IntPtr.Zero;
                // Query the running object table (ROT)
                if (GetRunningObjectTable
                        (
                            0,
                            out prot) != 0 || prot == null)
                {
                    return null;
                }
                prot.EnumRunning(out pmonkenum);
                pmonkenum.Reset();
                var monikers = new IMoniker[1];
                while (pmonkenum.Next
                           (
                               1,
                               monikers,
                               pfetched) == 0)
                {
                    IBindCtx pctx;
                    string filepathname;
                    CreateBindCtx
                        (
                            0,
                            out pctx);
                    // Get the name of the file
                    monikers[0].GetDisplayName
                        (
                            pctx,
                            null,
                            out filepathname);
                    // Clean up
                    Marshal.ReleaseComObject(pctx);
                    // Search for the Document
                    if (filepathname.IndexOf(wordfile) != -1)
                    {
                        object roval;
                        // Get a handle on the workbook
                        prot.GetObject
                            (
                                monikers[0],
                                out roval);
                        return roval as Document;
                    }
                }
                // Load the Document in the WebBrowser control
                webBrowser1.Navigate
                    (
                        _mWordFileName,
                        false);
            }
            catch
            {
                return null;
            }
            finally
            {
                // Clean up
                if (prot != null)
                {
                    Marshal.ReleaseComObject(prot);
                }
                if (pmonkenum != null)
                {
                    Marshal.ReleaseComObject(pmonkenum);
                }
            }
            return null;
        }

        protected void OnClosed
            (
            object sender,
            EventArgs e)
        {
            try
            {
                // Quit Word and clean up.
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
                if (_mWordApplication == null)
                {
                    return;
                }
                _mWordApplication.Quit();
                Marshal.ReleaseComObject
                    (_mWordApplication);
                _mWordApplication = null;
                GC.Collect();
            }
            catch
            {
                MessageBox.Show(@"Failed to close the application");
            }
        }

        private void webBrowser1_Navigated
            (
            object sender,
            WebBrowserNavigatedEventArgs e)
        {
            // Creation of the workbook object
            if ((_mWorkbook = RetrieveDocument(_mWordFileName)) == null)
            {
                return;
            }
            // Create the Excel.Application
            _mWordApplication = _mWorkbook.Application;
        }
    }
}
