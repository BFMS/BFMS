using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GUI
{
    public class EditorPane : TabControl
    {
        [DefaultValue(true)]
        bool HasCloseButton { get; set; }

        [DefaultValue(13), Category("Action Buttons")]
        int ButtonWidth { get; set; }

        [DefaultValue(3), Category("Action Buttons")]
        int CrossOffset { get; set; }

        bool isDragging = false;
        System.Drawing.Rectangle dropRectangle = new System.Drawing.Rectangle();
        Brush brush = new SolidBrush(Color.Tomato);
        Brush closeButtonBrush = new SolidBrush(Color.OrangeRed);

        static FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
        Font font = new Font(fontFamily, 8);

        private static DataObject dummy = new DataObject();
        private int dragSource = -1;

        readonly StringFormat stringFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        public delegate void OnTabClosedDelegate(object sender, TabCloseEventArgs e);
        public event OnTabClosedDelegate OnTabClose;

        public EditorPane()
        {
            AllowDrop = true;
            DrawMode = TabDrawMode.OwnerDrawFixed;
            dropRectangle.Width = 3; // pretty good width to see the line

            ButtonWidth = 13;
            CrossOffset = 3;

            Padding = new Point(16, 0);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                brush.Dispose();
                fontFamily.Dispose();
                font.Dispose();
                stringFormat.Dispose();
                closeButtonBrush.Dispose();
            }
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
            isDragging = false;
            dropRectangle.X += 1; // force repainting
            Invalidate();
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            if (dragSource < 0) return;
            isDragging = true;
            Point p = PointToClient(new Point(e.X, e.Y));
            e.Effect = DragDropEffects.Move;
            UpdateDropRectangle(p.X, p.Y);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;

            dragSource = GetTabIndex(e.X, e.Y);
            Rectangle rect = GetTabRect(dragSource);
            rect = GetCloseButtonRect(rect, dragSource == SelectedIndex);
            Point pt = new Point(e.X, e.Y);

            if (rect.Contains(pt))
            {
                TabPage page = TabPages[dragSource];
                TabCloseEventArgs ea = new TabCloseEventArgs();
                ea.TabIndex = dragSource;
                ea.TabText = TabPages[dragSource].Text;
                ea.Accept = true;

                if (OnTabClose != null)
                    OnTabClose(page, ea);

                if (ea.Accept)
                    TabPages.RemoveAt(dragSource);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.Left) return;
            try
            {
                if (DoDragDrop(dummy, DragDropEffects.Move) != DragDropEffects.Move) return;
                Point p = PointToClient(Control.MousePosition);
                int newIndex = GetTabIndex(p.X, p.Y);

                if (dragSource == newIndex) return;

                TabPage page = TabPages[dragSource];
                TabPages.RemoveAt(dragSource);
                TabPages.Insert(newIndex, page);
                SelectedIndex = newIndex;

                isDragging = false;
                dropRectangle.X += 1; // force repainting
                Invalidate();
            }
            finally
            {
                dragSource = -1;
                Invalidate();
            }
        }

        private int GetTabIndex(int x, int y)
        {
            Point p = new Point(x, y);

            for (int i = 0; i < TabPages.Count; i++)
                if (GetTabRect(i).Contains(p))
                    return i;

            throw new Exception("cannot find tab!");
        }

        private void UpdateDropRectangle(int x, int y)
        {
            int index = GetTabIndex(x, y);
            Rectangle tabRect = GetTabRect(index);


            // get the x coordinate for tab middle to
            // decide whether to paint on right or left side
            int tabMiddle = tabRect.X + tabRect.Width / 2;

            int rectX;
            if (tabMiddle > x) // left
                rectX = tabRect.X;
            else // right
                rectX = tabRect.X + tabRect.Width;

            rectX -= 2; // we want to paint in the middle of the tab

            if (dropRectangle.X == rectX && dropRectangle.Y == tabRect.Y && dropRectangle.Height == tabRect.Height)
                return; // we do not need to repaint

            dropRectangle.X = rectX;
            dropRectangle.Y = tabRect.Y;
            dropRectangle.Height = tabRect.Height;
            Invalidate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (e.Index == TabPages.Count)
                return; // dont paint a non existing tab!

            String text = TabPages[e.Index].Text;
            Rectangle tabRect;
            VisualStyleRenderer renderer = null;
            Rectangle closeButtonRect;
            if (e.State == DrawItemState.Selected)
            {
                tabRect = e.Bounds;
                if (VisualStyleRenderer.IsSupported)
                    renderer = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Pressed);
                closeButtonRect = GetCloseButtonRect(tabRect, true);
            }
            else
            {
                tabRect = GetTabRect(e.Index);
                if (VisualStyleRenderer.IsSupported)
                    renderer = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
                closeButtonRect = GetCloseButtonRect(tabRect, false);
            }

            if (VisualStyleRenderer.IsSupported)
                renderer.DrawBackground(e.Graphics, tabRect);

            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(closeButtonBrush, closeButtonRect);
                e.Graphics.DrawRectangle(Pens.White, closeButtonRect);
                DrawCross(e, closeButtonRect, Color.White);
            }
            else
                DrawCross(e, closeButtonRect, Color.DarkGray);


            tabRect.X += 2;
            e.Graphics.DrawString(text, font, new SolidBrush(TabPages[e.Index].ForeColor), tabRect, stringFormat);

            if (isDragging)
                e.Graphics.FillRectangle(brush, dropRectangle);
        }

        private Rectangle GetCloseButtonRect(Rectangle tabRect, bool selected)
        {
            if (selected)
                return new Rectangle(tabRect.X + tabRect.Width - ButtonWidth - 4, (tabRect.Height - ButtonWidth) / 2, ButtonWidth, ButtonWidth);
            else
                return new Rectangle(tabRect.X + tabRect.Width - ButtonWidth - 4, (tabRect.Height - ButtonWidth + 4) / 2, ButtonWidth, ButtonWidth);
        }

        private void DrawCross(DrawItemEventArgs e, Rectangle buttonRect, Color color)
        {
            using (Pen pen = new Pen(color, 2))
            {
                float x1 = buttonRect.X + CrossOffset;
                float x2 = buttonRect.Right - CrossOffset;
                float y1 = buttonRect.Y + CrossOffset;
                float y2 = buttonRect.Bottom - CrossOffset;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                e.Graphics.DrawLine(pen, x1, y2, x2, y1);
            }
        }

    }
    public class TabCloseEventArgs : EventArgs
    {
        public int TabIndex { get; set; }
        public String TabText { get; set; }
        public bool Accept { get; set; }
    }

}
