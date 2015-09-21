using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Infragistics.Win.AppStyling;

namespace Advanced_Accounting
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Stream s =
                (Assembly.GetExecutingAssembly()).GetManifestResourceStream
                    (
                        "Advanced_Accounting.Resources.Office2007Blue2.isl");
            if (s != null)
            {
                StyleManager.Load(s);
            }
            Application.Run(new StartUpForm());
        }
    }
}
