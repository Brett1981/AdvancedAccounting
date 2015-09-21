using System.Windows.Forms;

namespace Advanced_Accounting.Forms
{
    public partial class FrmWord : Form
    {
        public FrmWord(string aWordFile)
        {
            InitializeComponent();
            ctrlWord1.RetrieveDocument(aWordFile);
        }
    }
}
