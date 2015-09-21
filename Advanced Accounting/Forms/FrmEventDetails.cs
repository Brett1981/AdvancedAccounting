using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Infragistics.Win;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.UltraWinMaskedEdit;
using Microsoft.Office.Interop.Outlook;
using Microsoft.VisualBasic;
using Re_useable_Classes.Converters;
using Re_useable_Classes.Functions;
using Re_useable_Classes.Message_Helpers.Forms;
using Re_useable_Classes.SQL;
using Appearance = Infragistics.Win.Appearance;
using DataFormats = System.Windows.Forms.DataFormats;
using DataObject = System.Windows.Forms.DataObject;
using DragAction = System.Windows.Forms.DragAction;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using Exception = System.Exception;
using ImageConverter = Re_useable_Classes.Converters.ImageConverter;
using Point = System.Drawing.Point;
using QueryContinueDragEventArgs = System.Windows.Forms.QueryContinueDragEventArgs;
using Size = System.Drawing.Size;

namespace Advanced_Accounting.Forms
{
    public partial class FrmEventDetails : Form
    {
        private const int OrigWidth = 424;
        private const int ExpWidth = 815;
        private const int TimerInterval = 50;
        public Dictionary<string, Color> Categories;
        public string EntryId;
        private bool _alreadyFocused;
        private object _data;
        private UltraListViewItem _dragItem;
        private UltraListViewItem _dropItem;
        private bool _isLoading;
        private Point? _lastMouseDown;
        private bool _msFrmSplash;
        private Bitmap bmp;
        private bool isFormClosing;
        private bool isRunning;


        [UIPermission(SecurityAction.Demand, Clipboard = UIPermissionClipboard.OwnClipboard)]
        public FrmEventDetails()
        {
            InitializeComponent();
            _isLoading = true;
            lvAttachments.Items.Clear();
        }

        public static Stream ToStream
            (
            Image image,
            ImageFormat formaw)
        {
            var stream = new MemoryStream();
            image.Save
                (
                    stream,
                    formaw);
            stream.Position = 0;
            return stream;
        }

        public static string[] Split
            (
            string s,
            string separator)
        {
            return s.Split
                (
                    new[]
                    {
                        separator
                    },
                    StringSplitOptions.None);
        }

        private void GetCurrentDetails()
        {
            string aGet =
                "SELECT LWG_ATTACHMENTS, LWG_CATEGORIES, LWG_INCOME, LWG_MOT_EXPS, LWG_PPSA, LWG_HP, LWG_TELEPHONE, LWG_OTHER, LWG_PLH, LWG_SUBS, LWG_CLEANING, "
                +
                " LWG_MISC, LWG_DRAWINGS, LWG_BIKE, LWG_ADD_INFO, LWG_MILLEAGE FROM `LWG_DIARY` " +
                "WHERE LWG_ENTRY_ID = '" + EntryId + "'";
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
                var msOThread = new Thread(CreateAttachements(dgv))
                                {
                                    IsBackground = true
                                };
                msOThread.SetApartmentState(ApartmentState.STA);
                msOThread.Start();
                while (!isRunning)
                {
                    Thread.Sleep(TimerInterval);
                }
            }
            catch (Exception e)
            {
                //do nothing
            }

            try
            {
                cmbCategories.Text = (((DataTable) (dgv.DataSource)).Rows[0][1].ToString());
                txtIncome.Text = (((DataTable) (dgv.DataSource)).Rows[0][2].ToString());
                txtMOTExp.Text = (((DataTable) (dgv.DataSource)).Rows[0][3].ToString());
                txtPPSA.Text = (((DataTable) (dgv.DataSource)).Rows[0][4].ToString());
                txtHP.Text = (((DataTable) (dgv.DataSource)).Rows[0][5].ToString());
                txtTelephone.Text = (((DataTable) (dgv.DataSource)).Rows[0][6].ToString());
                txtOther.Text = (((DataTable) (dgv.DataSource)).Rows[0][7].ToString());
                txtPLH.Text = (((DataTable) (dgv.DataSource)).Rows[0][8].ToString());
                txtSubs.Text = (((DataTable) (dgv.DataSource)).Rows[0][9].ToString());
                txtCleaning.Text = (((DataTable) (dgv.DataSource)).Rows[0][10].ToString());
                txtMisc.Text = (((DataTable) (dgv.DataSource)).Rows[0][11].ToString());
                txtDrawings.Text = (((DataTable) (dgv.DataSource)).Rows[0][12].ToString());
                txtBike.Text = (((DataTable) (dgv.DataSource)).Rows[0][13].ToString());
                txtAdditionalInfo.Text = (((DataTable) (dgv.DataSource)).Rows[0][14].ToString());
                txtMiliage.Text = (((DataTable) (dgv.DataSource)).Rows[0][15].ToString());
            }
            catch (Exception)
            {
                //Do Nothing
            }
        }

        private ThreadStart CreateAttachements(DataGridView dgv)
        {
            isRunning = true;
            //var astring = ImageConverter.GetString((byte[]) ((DataTable)(dgv.DataSource)).Rows[0][0]);
            string test = ImageConverter.ByteArrayToString((byte[]) ((DataTable) (dgv.DataSource)).Rows[0][0]);
            string[] astringlist = Split
                (
                    test,
                    "7b4e45577d");
            foreach (Image aimage in astringlist.Select(ImageConverter.ConvertHexToBytes)
                                                .Select
                (abytearray => ImageConverter.Base64ToImage(Convert.ToBase64String(abytearray))))
            {
                try
                {
                    lvAttachments_DragDrop
                        (
                            lvAttachments,
                            new DragEventArgs
                                (
                                new DataObject(aimage),
                                0,
                                385,
                                662,
                                DragDropEffects.Copy,
                                DragDropEffects.Copy));
                }
                catch (Exception e)
                {
                    MessageDialog.Show
                        (
                            "Unable to Load Attachments",
                            e.Message,
                            MessageDialog.MessageBoxButtons.Ok,
                            MessageDialog.MessageBoxIcon.Error,
                            e.StackTrace,
                            this);
                }
            }
            isRunning = false;
            return null;
        }

        private void lvAttachments_MouseDown
            (
            object sender,
            MouseEventArgs e)
        {
            //  Record the cursor location
            if (e.Button == MouseButtons.Left)
            {
                _lastMouseDown = e.Location;
            }
            else
            {
                _lastMouseDown = null;
            }
        }

        private void lvAttachments_MouseMove
            (
            object sender,
            MouseEventArgs e)
        {
            var listView = sender as UltraListView;


            //  If the mouse has moved outside the area in which it was pressed,
            //  start a drag operation
            if (!_lastMouseDown.HasValue)
            {
                return;
            }
            Size dragSize = SystemInformation.DragSize;
            var dragRect = new Rectangle
                (
                _lastMouseDown.Value,
                dragSize);
            dragRect.X -= dragSize.Width/2;
            dragRect.Y -= dragSize.Height/2;

            if (!dragRect.Contains(e.Location))
            {
                return;
            }
            if (listView == null)
            {
                return;
            }
            UltraListViewItem itemAtPoint = listView.ItemFromPoint(e.Location);

            if (itemAtPoint == null)
            {
                return;
            }
            _lastMouseDown = null;
            _dragItem = itemAtPoint;
            listView.DoDragDrop
                (
                    _dragItem,
                    DragDropEffects.Move);
        }

        private void lvAttachments_DragDrop
            (
            object sender,
            DragEventArgs e)
        {
            _data = new object();
            _data = e.Data.GetData(DataFormats.FileDrop) ?? e.Data.GetData(DataFormats.Bitmap);
            BitmapSource bmpsrc = GetImageSourceFromDropData(e);
            if (bmpsrc != null)
            {
                bmp = CreateBitmap(bmpsrc);
            }
            var listView = sender as UltraListView;
            OnDragEnd
                (
                    listView,
                    false);
        }

        private void OnDragEnd
            (
            UltraListView listView,
            bool canceled)
        {
            if (isFormClosing)
            {
                return;
            }
            if (canceled == false && _data != null)
            {
                listView.BeginUpdate();

                // listView.Items.Remove((UltraListViewItem) data);
                int index = 0;
                if (listView.Items.Count > 0)
                {
                    index = listView.Items.Count;
                }
                //Create Unique GUID From Filename
                string myUniqueFileName = "";
                try
                {
                    myUniqueFileName = string.Format
                        (
                            ((string[]) (_data))[0],
                            Guid.NewGuid());
                }
                catch (Exception)
                {
                    myUniqueFileName = string.Format
                        (
                            "Image " + DateTime.Now,
                            Guid.NewGuid());
                }


                try
                {
                    using (var item = new UltraListViewItem(_data.ToString())
                                      {
                                          Tag = ((string[]) (_data))[0],
                                          Key = myUniqueFileName
                                      })
                    {
                        const int thumbSize = 256;
                        Bitmap thumbnail = WindowsThumbnailProvider.GetThumbnail
                            (
                                ((string[]) (_data))[0],
                                thumbSize,
                                thumbSize,
                                ThumbnailOptions.BiggerSizeOk);
                        if (bmp != null)
                        {
                            item.Appearance.ImageBackground = bmp;
                            item.Appearance.Image = bmp;
                        }
                        else
                        {
                            item.Appearance.ImageBackground = thumbnail;
                            item.Appearance.Image = thumbnail;
                        }
                        if (!listView.Items.Contains(myUniqueFileName))
                        {
                            listView.Items.Insert
                                (
                                    index,
                                    item);
                        }
                    }
                }
                catch (Exception)
                {
                    var b = new Bitmap((Bitmap) _data);
                    var i = (Image) b;
                    try
                    {
                        string result = ImageConverter.GetString
                            (
                                ImageConverter.ImageToBase64Byte
                                    (
                                        i,
                                        ImageFormat.Bmp));
                        try
                        {
                            listView.Items.Insert
                                (
                                    index,
                                    new UltraListViewItem(myUniqueFileName)
                                    {
                                        Tag = result
                                    });
                        }
                        catch (Exception)
                        {
                            listView.Items.Add
                                (
                                    new UltraListViewItem(myUniqueFileName)
                                    {
                                        Tag = result
                                    });
                        }

                        UltraListViewItem selected = listView.Items[index];
                        selected.Appearance.ImageBackground = i;
                        selected.Appearance.Image = b;
                    }
                    catch (Exception e)
                    {
                        //Do Nothing
                    }
                }


                listView.EndUpdate();
            }

            _dragItem = _dropItem = null;
            _lastMouseDown = null;
        }

        private void lvAttachments_DragOver
            (
            object sender,
            DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            var listView = sender as UltraListView;
            if (listView == null)
            {
                return;
            }
            Point clientPos = listView.PointToClient
                (
                    new Point
                        (
                        e.X,
                        e.Y));

            if (_dragItem != null)
            {
                _dropItem = listView.ItemFromPoint(clientPos);

                e.Effect = _dropItem != null && _dropItem != _dragItem
                               ? DragDropEffects.Move
                               : DragDropEffects.None;
            }

            //  TODO: This could be improved with a hover timer

            //  If the cursor is within {dragScrollAreaHeight} pixels
            //  of the top or bottom edges of the control, scroll
            const int dragScrollAreaHeight = 8;

            Rectangle displayRect = listView.DisplayRectangle;
            Rectangle topScrollArea = displayRect;
            topScrollArea.Height = (dragScrollAreaHeight*2);

            Rectangle bottomScrollArea = displayRect;
            bottomScrollArea.Y = bottomScrollArea.Bottom - dragScrollAreaHeight;
            bottomScrollArea.Height = dragScrollAreaHeight;

            ISelectionManager selectionManager = listView;
            if (topScrollArea.Contains(clientPos) || bottomScrollArea.Contains(clientPos))
            {
                selectionManager.DoDragScrollVertical(0);
            }
        }

        private void lvAttachments_QueryContinueDrag
            (
            object sender,
            QueryContinueDragEventArgs e)
        {
            var listView = sender as UltraListView;

            //  Cancel the drag operation if the escape key was pressed
            if (!e.EscapePressed)
            {
                return;
            }
            OnDragEnd
                (
                    listView,
                    true);
            e.Action = DragAction.Cancel;
        }

        private void FrmEventDetails_Load
            (
            object sender,
            EventArgs e)
        {
            EntryId = GlobalSettings.AEntryId;
            if (!string.IsNullOrEmpty(EntryId))
            {
                GetCurrentDetails();
            }
            Width = OrigWidth;
            Categories = AddACategory();
            int i = GetNextCatPrimary();
            txtPrimary.Text = i.ToString(CultureInfo.InvariantCulture);

            cmbCategories.DataSource = Categories.Keys;
            ultraComboEditor1_BeforeDropDown
                (
                    this,
                    null);
            //cmbCategories.DataBind();
            _isLoading = false;
        }

        private void FrmEventDetails_FormClosed
            (
            object sender,
            FormClosedEventArgs e)
        {
            Close();
        }

        private static Dictionary<string, Color> AddACategory()
        {
            const string aGet = "SELECT NCAT_NAME, NCAT_DRCR_TYPE FROM `NL_CATEGORIES`";
            var dgv = new DataGridView();
            dgv = MySqlConnec.GetSetUpdateQueryData
                (
                    MySqlConnec.ConDataBase,
                    aGet,
                    dgv);

            var dictionary = new Dictionary<string, Color>();
            if (dgv.DataSource == null)
            {
                return dictionary;
            }
            foreach (DataRow s in ((DataTable) (dgv.DataSource)).Rows)
            {
                Color clColor = Color.FromName(s[1].ToString());
                if (!clColor.IsKnownColor)
                {
                    clColor = Color.Black;
                }

                if (!string.IsNullOrEmpty(s[0].ToString()) && !dictionary.ContainsKey(s[0].ToString()))
                {
                    dictionary.Add
                        (
                            s[0].ToString(),
                            clColor);
                }
            }
            return dictionary;
        }

        private void cmbCategories_BeforeDropDown
            (
            object sender,
            CancelEventArgs e)
        {
            Categories = AddACategory();

            cmbCategories.DataSource = Categories;
        }

        private void btnCatAdd_Click
            (
            object sender,
            EventArgs e)
        {
            if (Width == OrigWidth)
            {
                Width = ExpWidth;
                pnlLeft.Enabled = false;
                pnlRight.Enabled = true;
            }
            else
            {
                Width = OrigWidth;
                pnlRight.Enabled = false;
                pnlLeft.Enabled = true;
            }
        }

        private void cmbExistingCat_ValueChanged
            (
            object sender,
            EventArgs e)
        {
            if (cmbExistingCat.Text != @"<Add New>")
            {
                txtCatName.Enabled = false;
                GetDefaultCategory(cmbExistingCat.Text);
            }
            else
            {
                txtCatName.Enabled = true;
                int i = GetNextCatPrimary();
                txtPrimary.Text = i.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void GetDefaultCategory(string text)
        {
            string aGet =
                "SELECT NCAT_PRIMARY, NCAT_CODE, NCAT_NAME, NCAT_SHORTNAME, NCAT_NUMBER, NCAT_USED, NCAT_DRCR_TYPE FROM `NL_CATEGORIES` "
                +
                "WHERE NCAT_NAME = '" + text + "'";
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
            txtPrimary.Text = (((DataTable) (dgv.DataSource)).Rows[0][0].ToString());
            txtCatCode.Text = (((DataTable) (dgv.DataSource)).Rows[0][1].ToString());
            txtCatName.Text = (((DataTable) (dgv.DataSource)).Rows[0][2].ToString());
            txtCatShortName.Text = (((DataTable) (dgv.DataSource)).Rows[0][3].ToString());

            // Attempt to find passed in string.
            int index = cmbCategoryColor.FindString((((DataTable) (dgv.DataSource)).Rows[0][6].ToString()));

            if (index == -1)
            {
                return;
            }
            // String has been found, highlight it. First restore appearance on non
            // highlighted items
            for (int i = 0;
                 i < cmbCategoryColor.Items.Count;
                 i++)
            {
                if (i != index)
                {
                    cmbCategoryColor.Items[i].Appearance.FontData.Reset();
                    cmbCategoryColor.Items[i].Appearance.ResetBackColor();
                }
            }

            // Highlight the found item in the list
            ValueListItem item = cmbCategoryColor.Items[index];

            item.Appearance.BackColor = Color.Yellow;
            item.Appearance.ForeColor = Color.FromName((((DataTable) (dgv.DataSource)).Rows[0][6].ToString()));
            item.Appearance.FontData.Bold = DefaultableBoolean.True;

            // Set the selected item
            cmbCategoryColor.SelectedItem = item;
        }

        private void cmbExistingCat_BeforeDropDown
            (
            object sender,
            CancelEventArgs e)
        {
            Categories = AddACategory();
            Categories.Add
                (
                    "<Add New>",
                    Color.Black);


            cmbExistingCat.DataSource = Categories;
        }

        private void btnCatOK_Click
            (
            object sender,
            EventArgs e)
        {
            Width = OrigWidth;
            pnlLeft.Enabled = true;
            pnlRight.Enabled = false;

            if (cmbExistingCat.Text != @"<Add New>")
            {
                cmbCategories.Text = cmbExistingCat.Text;
            }

            SaveCategory();
        }

        private static int GetNextCatPrimary()
        {
            const string aSet = "SELECT ISNULL(MAX(NCAT_PRIMARY))+1 FROM `NL_CATEGORIES`";
            var dgv = new DataGridView();
            dgv = MySqlConnec.GetSetUpdateQueryData
                (
                    MySqlConnec.ConDataBase,
                    aSet,
                    dgv);

            return (((DataTable) (dgv.DataSource)).Rows.Count > 0)
                       ? Convert.ToInt32((((DataTable) (dgv.DataSource)).Rows[0][0].ToString()))
                       : 0;
        }

        private static int GetNextCatNumber()
        {
            const string aSet = "SELECT ISNULL(MAX(NCAT_NUMBER))+1 FROM `NL_CATEGORIES`";
            var dgv = new DataGridView();
            dgv = MySqlConnec.GetSetUpdateQueryData
                (
                    MySqlConnec.ConDataBase,
                    aSet,
                    dgv);

            return (((DataTable) (dgv.DataSource)).Rows.Count > 0)
                       ? Convert.ToInt32((((DataTable) (dgv.DataSource)).Rows[0][0].ToString()))
                       : 0;
        }

        private bool SaveCategory()
        {
            //Get Information To Save

            int i = GetNextCatPrimary();


            int catNumber = GetNextCatNumber();

            if (cmbExistingCat.Text != @"<Add New>")
            {
                string aSet = @"UPDATE `NL_CATEGORIES`  
                            SET NCAT_CODE = '" + txtCatCode.Text.ToUpper() + "'" +
                              @",NCAT_NAME = '" + txtCatName.Text + "'" +
                              @",NCAT_SHORTNAME = '" + txtCatShortName.Text.ToUpper() + "'" +
                              @",NCAT_NUMBER = " + catNumber +
                              @",NCAT_USED = 1" +
                              @",NCAT_DRCR_TYPE = '" + cmbCategoryColor.Text + "'" +
                              @"WHERE NCAT_PRIMARY = " + txtPrimary.Text;
                List<string> aList = MySqlConnec.GetSetUpdateQueryDataList
                    (
                        MySqlConnec.ConDataBase,
                        aSet);
                return aList != null;
            }
            else
            {
                string aSet =
                    @"INSERT INTO `NL_CATEGORIES`(`NCAT_PRIMARY`, `NCAT_CODE`, `NCAT_NAME`, `NCAT_SHORTNAME`, `NCAT_NUMBER`, `NCAT_USED`, `NCAT_DRCR_TYPE`)  
                            VALUES (" + i +
                    @",'" + txtCatCode.Text.ToUpper() + "'" +
                    @",'" + txtCatName.Text + "'" +
                    @",'" + txtCatShortName.Text.ToUpper() + "'" +
                    @"," + catNumber +
                    @",0" +
                    @",'" + cmbCategoryColor.Text + "')";
                List<string> aList = MySqlConnec.GetSetUpdateQueryDataList
                    (
                        MySqlConnec.ConDataBase,
                        aSet);
                return aList != null;
            }
        }


        private void ultraComboEditor1_BeforeDropDown
            (
            object sender,
            CancelEventArgs e)
        {
            if (_isLoading)
            {
                return;
            }
            cmbCategoryColor.Items.Clear();
            cmbCategoryColor.AlwaysInEditMode = false;

            foreach (
                ValueListItem valueListItem1 in from OlCategoryColor color in Enum.GetValues(typeof (OlCategoryColor))
                                                select color.ToString()
                                                            .Substring
                                                    (
                                                        15,
                                                        color.ToString()
                                                             .Length - 15)
                                                into a
                                                select a.Replace
                                                    (
                                                        "'",
                                                        "")
                                                into a
                                                where a != "None"
                                                select Color.FromName(a)
                                                into clColor
                                                where clColor.IsKnownColor
                                                let appearance = new Appearance
                                                                 {
                                                                     BackColor = clColor,
                                                                     BorderColor = clColor,
                                                                     BorderColor3DBase = clColor,
                                                                     BorderColor2 = clColor,
                                                                     BackColorDisabled = clColor,
                                                                     ForeColor = clColor,
                                                                     ForeColorDisabled = clColor
                                                                 }
                                                select new ValueListItem(clColor)
                                                       {
                                                           Appearance = appearance
                                                       })
            {
                cmbCategoryColor.Items.Add(valueListItem1);
            }
            cmbCategoryColor.Appearance.FontData.Bold = DefaultableBoolean.True;
        }

        private void txtCatName_ValueChanged
            (
            object sender,
            EventArgs e)
        {
            if (cmbExistingCat.Text != @"<Add New>")
            {
                return;
            }
            var catCode = new string
                (
                txtCatName.Text.Take(6)
                          .ToArray());
            var shortName = new string
                (
                txtCatName.Text.Take(10)
                          .ToArray());
            txtCatCode.Text = catCode.ToUpper();
            txtCatShortName.Text = shortName.ToUpper();
        }

        private void txtIncome_MouseUp
            (
            object sender,
            MouseEventArgs e)
        {
            if (_isLoading)
            {
                return;
            }
            // Web browsers like Google Chrome select the text on mouse up.
            // They only do it if the textbox isn't already focused,
            // and if the user hasn't selected all text.
            var aTextBox = (UltraMaskedEdit) sender;
            if (_alreadyFocused || aTextBox.SelectionLength != 0)
            {
                return;
            }
            _alreadyFocused = true;
            aTextBox.SelectAll();
        }

        private void txtIncome_Leave
            (
            object sender,
            EventArgs e)
        {
            if (_isLoading)
            {
                return;
            }
            _alreadyFocused = false;
        }

        private void txtIncome_Enter
            (
            object sender,
            EventArgs e)
        {
            if (_isLoading)
            {
                return;
            }
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            switch (MouseButtons)
            {
                case MouseButtons.None:
                {
                    var aTextBox = (UltraMaskedEdit) sender;
                    aTextBox.SelectAll();
                    _alreadyFocused = true;
                }
                    break;
            }
        }

        private void btnOk_Click
            (
            object sender,
            EventArgs e)
        {
            List<byte[]> aListByteArray = GetAttachments(lvAttachments);
            byte[] aConcatAttachment;
            if (aListByteArray.Count > 1)
            {
                aConcatAttachment = CombineByteArrayWithSeperator.ArrayJoin
                    (
                        "{NEW}",
                        aListByteArray);
            }
            else
            {
                aConcatAttachment = aListByteArray.Count > 0
                                        ? aListByteArray[0]
                                        : null;
            }

            string aSet = @"UPDATE `LWG_DIARY`  
                            SET `LWG_ATTACHMENTS` = ?p1 " +
                          @", `LWG_CATEGORIES` = '" + cmbCategories.Text + "'" +
                          @", `LWG_INCOME` = '" + txtIncome.Text.ToUpper() + "'" +
                          @", `LWG_MOT_EXPS` = '" + txtMOTExp.Text + "'" +
                          @", `LWG_MILLEAGE` = '" + txtMiliage.Text + "'" +
                          @", `LWG_PPSA` = '" + txtPPSA.Text + "'" +
                          @", `LWG_HP` = '" + txtHP.Text + "'" +
                          @", `LWG_TELEPHONE` = '" + txtTelephone.Text + "'" +
                          @", `LWG_OTHER` = '" + txtOther.Text + "'" +
                          @", `LWG_PLH` = '" + txtPLH.Text + "'" +
                          @", `LWG_SUBS` = '" + txtSubs.Text + "'" +
                          @", `LWG_CLEANING` = '" + txtCleaning.Text + "'" +
                          @", `LWG_MISC` = '" + txtMisc.Text + "'" +
                          @", `LWG_DRAWINGS` = '" + txtDrawings.Text + "'" +
                          @", `LWG_BIKE` = '" + txtBike.Text + "'" +
                          @", `LWG_ADD_INFO` = '" + txtAdditionalInfo.Text + "'" +
                          @" WHERE `LWG_ENTRY_ID` = '" + EntryId + "'";
            List<string> aList = MySqlConnec.GetSetUpdateQueryDataList
                (
                    MySqlConnec.ConDataBase,
                    aSet,
                    aConcatAttachment);
            Close();
        }

        private static List<byte[]> GetAttachments(UltraListView ultraListView)
        {
            var aList = new List<byte[]>();
            foreach (UltraListViewItem item in ultraListView.Items)
            {
                try
                {
                    aList.Add(File.ReadAllBytes(item.Key));
                }
                catch (Exception)
                {
                    aList.Add(ImageConverter.GetBytes(item.Tag.ToString()));
                }
            }
            return aList;
        }

        private void lvAttachments_ItemDoubleClick
            (
            object sender,
            ItemDoubleClickEventArgs e)
        {
            if (lvAttachments.SelectedItems.Count <= 0)
            {
                return;
            }
            UltraListViewItem selected = lvAttachments.SelectedItems[0];
            try
            {
                string selectedFilePath = selected.Tag.ToString();
                string extension = Strings.Replace
                    (
                        Path.GetExtension(selectedFilePath),
                        ".",
                        "");
                GetSetFileType
                    (
                        extension,
                        selectedFilePath);
            }
            catch (Exception)
            {
                if (sender.GetType() == typeof (UltraListView))
                {
                    var aPricture = new FrmPricture((UltraListView) sender);
                    aPricture.Show();
                }
            }
        }


        private void GetSetFileType
            (
            string extension,
            string selectedFilePath)
        {
            if (!IsImageFile.IsRecognisedImageFile(selectedFilePath))
            {
                FrmExcel aFrmExcel;
                FrmWord aFrmWord;
                switch (extension)
                {
                    case "xlsx":
                        aFrmExcel = new FrmExcel(selectedFilePath);
                        aFrmExcel.Show();
                        break;
                    case "xla":
                        aFrmExcel = new FrmExcel(selectedFilePath);
                        aFrmExcel.Show();
                        break;
                    case "xls":
                        aFrmExcel = new FrmExcel(selectedFilePath);
                        aFrmExcel.Show();
                        break;
                    case "xlam":
                        aFrmExcel = new FrmExcel(selectedFilePath);
                        aFrmExcel.Show();
                        break;
                    case "doc":
                        aFrmWord = new FrmWord(selectedFilePath);
                        aFrmWord.Show();
                        break;
                    case "docx":
                        aFrmWord = new FrmWord(selectedFilePath);
                        aFrmWord.Show();
                        break;
                    case "txt":
                        aFrmWord = new FrmWord(selectedFilePath);
                        aFrmWord.Show();
                        break;
                    case "rtf":
                        aFrmWord = new FrmWord(selectedFilePath);
                        aFrmWord.Show();
                        break;
                }
            }
            else
            {
                var aPricture = new FrmPricture(selectedFilePath);
                aPricture.Show();
            }
        }

        private static BitmapSource GetImageSourceFromDropData(DragEventArgs e)
        {
            if (e.Data.GetDataPresent
                (
                    DataFormats.Bitmap,
                    true))
            {
                object bm = e.Data.GetData
                    (
                        DataFormats.Bitmap,
                        true);

                var interopBitmap = bm as InteropBitmap;
                if (interopBitmap != null)
                {
                    return interopBitmap;
                }

                var bitmap = bm as Bitmap;
                if (bitmap != null)
                {
                    return CreateBitmapSource(bitmap);
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[]) e.Data.GetData
                                               (
                                                   DataFormats.FileDrop,
                                                   true);
                var bmp = new BitmapImage
                    (
                    new Uri
                        (
                        "file:///" + fileNames[0].Replace
                                         (
                                             "\\",
                                             "/")));
                return bmp;
            }
            return null;
        }


        private static Bitmap CreateBitmap(BitmapSource source)
        {
            using (var memoryStream = new MemoryStream())
            {
                var bitmapEncoder = new BmpBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(source));
                bitmapEncoder.Save(memoryStream);
                memoryStream.Position = 0;
                return new Bitmap(memoryStream);
            }
        }

        private static BitmapSource CreateBitmapSource(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSource bmpSrc = Imaging.CreateBitmapSourceFromHBitmap
                (
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            return bmpSrc;
        }

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        private void FrmEventDetails_FormClosing
            (
            object sender,
            FormClosingEventArgs e)
        {
            isFormClosing = true;
        }
    }
}
