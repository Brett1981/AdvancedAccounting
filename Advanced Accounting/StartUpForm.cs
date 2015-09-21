using System;
using System.Drawing;
using System.Windows.Forms;
using Advanced_Accounting.Forms;
using Advanced_Accounting.Properties;
using Re_useable_Classes.Converters;
using Re_useable_Classes.Forms;
using Re_useable_Classes.SplashScreen;

namespace Advanced_Accounting
{
    public sealed partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
            AFrmIcon = BitmaptoIcon.PngIconFromImage(Resources.percent);
            Cursor = Cursors.WaitCursor;
            SplashScreen.ShowSplashScreen();

            AFrmLogin = new FrmLoginMySql
                (
                "Advanced Accounting",
                AFrmIcon);
            AFrmLogin.btnLogin.Click += btnLogin_Click;
            AFrmLogin.Show();
            SplashScreen.CloseForm();
            Hide();
            ShowInTaskbar = false;
            Cursor = Cursors.Default;
        }

        private FrmMain AFrmMain { get; set; }
        private FrmLoginMySql AFrmLogin { get; set; }
        private Icon AFrmIcon { get; set; }

        private void btnLogin_Click
            (
            object sender,
            EventArgs e)
        {
            var aFrm = (FrmLoginMySql) ((Control) sender).FindForm();
            if (aFrm == null || !aFrm.AConnectionIsOpen)
            {
                return;
            }
            AFrmMain = new FrmMain();
            AFrmMain.Show();
            aFrm.Hide();
        }
    }
}
