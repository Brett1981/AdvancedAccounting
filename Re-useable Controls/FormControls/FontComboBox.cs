using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Re_useable_Controls.FormControls
{
    public sealed class FontComboBox : ComboBox
    {
        #region Private Member Declarations

        private readonly Dictionary<string, Font> _fontCache;
        private int _itemHeight;
        private int _previewFontSize;
        private StringFormat _stringFormat;

        public FontComboBox()
        {
            _fontCache = new Dictionary<string, Font>();

            DrawMode = DrawMode.OwnerDrawVariable;
            Sorted = true;
            PreviewFontSize = 12;

            CalculateLayout();
            CreateStringFormat();
        }

        [Browsable(false), DesignerSerializationVisibility
            (DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Never)]
        private new DrawMode DrawMode
        {
            set { base.DrawMode = value; }
        }

        [Category("Appearance"), DefaultValue(12)]
        private int PreviewFontSize
        {
            get { return _previewFontSize; }
            set
            {
                _previewFontSize = value;

                if (EventArgs.Empty != null)
                {
                    OnPreviewFontSizeChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility
            (DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Never)]
        private new bool Sorted
        {
            set { base.Sorted = value; }
        }

        public event EventHandler PreviewFontSizeChanged;

        protected override void Dispose(bool disposing)
        {
            ClearFontCache();

            if (_stringFormat != null)
            {
                _stringFormat.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (e.Index > -1 && e.Index < Items.Count)
            {
                e.DrawBackground();

                if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                {
                    e.DrawFocusRectangle();
                }

                using (var textBrush = new SolidBrush(e.ForeColor))
                {
                    {
                        string fontFamilyName = Items[e.Index].ToString();
                        e.Graphics.DrawString
                            (
                                fontFamilyName,
                                GetFont(fontFamilyName),
                                textBrush,
                                e.Bounds,
                                _stringFormat);
                    }
                }
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            CalculateLayout();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            LoadFontFamilies();

            base.OnGotFocus(e);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            if (((e != null && (e.Index > -1 && e.Index < Items.Count))))
            {
                e.ItemHeight = _itemHeight;
            }
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);

            CreateStringFormat();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (Items.Count != 0)
            {
                return;
            }

            LoadFontFamilies();

            int selectedIndex = FindStringExact(Text);
            if (selectedIndex != -1)
            {
                SelectedIndex = selectedIndex;
            }
        }

        private static bool IsUsingRtl(Control control)
        {
            bool result = control != null && control.RightToLeft == RightToLeft.Yes ||
                          control != null && (control.RightToLeft == RightToLeft.Inherit && control.Parent != null) &&
                          IsUsingRtl(control.Parent);

            return result;
        }

        private void CalculateLayout()
        {
            ClearFontCache();
            if (PreviewFontSize <= 0)
            {
                return;
            }
            using (var font = new Font
                (
                Font.FontFamily,
                PreviewFontSize))
            {
                Size textSize = TextRenderer.MeasureText
                    (
                        "yY",
                        font);
                _itemHeight = textSize.Height + 2;
            }
        }

        private void ClearFontCache()
        {
            if (_fontCache == null)
            {
                return;
            }
            foreach (string key in _fontCache.Keys)
            {
                _fontCache[key].Dispose();
            }
            _fontCache.Clear();
        }

        private void CreateStringFormat()
        {
            if (_stringFormat != null)
            {
                _stringFormat.Dispose();
            }

            _stringFormat = new StringFormat(StringFormatFlags.NoWrap)
                            {
                                Trimming = StringTrimming.EllipsisCharacter,
                                HotkeyPrefix = HotkeyPrefix.None,
                                Alignment = StringAlignment.Near,
                                LineAlignment = StringAlignment.Center
                            };

            if (IsUsingRtl(this))
            {
                _stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
        }

        private Font GetFont(string fontFamilyName)
        {
            lock (_fontCache)
            {
                if (!_fontCache.ContainsKey(fontFamilyName))
                {
                    Font font = (((GetFont
                                       (
                                           fontFamilyName,
                                           FontStyle.Regular) ?? GetFont
                                                                     (
                                                                         fontFamilyName,
                                                                         FontStyle.Bold)) ??
                                  GetFont
                                      (
                                          fontFamilyName,
                                          FontStyle.Italic)) ??
                                 GetFont
                                     (
                                         fontFamilyName,
                                         FontStyle.Bold | FontStyle.Italic)) ?? (Font) Font.Clone();

                    _fontCache.Add
                        (
                            fontFamilyName,
                            font);
                }
            }

            return _fontCache[fontFamilyName];
        }

        private Font GetFont
            (
            string fontFamilyName,
            FontStyle fontStyle)
        {
            Font font;

            try
            {
                font = new Font
                    (
                    fontFamilyName,
                    PreviewFontSize,
                    fontStyle);
            }
            catch
            {
                font = null;
            }

            return font;
        }

        private void LoadFontFamilies()
        {
            if (Items.Count != 0)
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                Items.Add(fontFamily.Name);
            }

            Cursor.Current = Cursors.Default;
        }

        private void OnPreviewFontSizeChanged(EventArgs e)
        {
            if (PreviewFontSizeChanged != null)
            {
                PreviewFontSizeChanged
                    (
                        this,
                        e);
            }

            CalculateLayout();
        }

        #endregion Private Member Declarations

        #region Public Constructors

        #endregion Public Constructors

        #region Events

        #endregion Events

        #region Protected Overridden Methods

        #endregion Protected Overridden Methods

        #region Public Methods

        #endregion Public Methods

        #region Public Properties

        #endregion Public Properties

        #region Private Methods

        #endregion Private Methods

        #region Protected Methods

        #endregion Protected Methods
    }
}
