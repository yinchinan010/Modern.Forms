﻿using System;
using System.Drawing;

namespace Modern.Forms.Renderers
{
    public class ListViewRenderer : Renderer<ListView>
    {
        protected override void Render (ListView control, PaintEventArgs e)
        {
            foreach (var item in control.Items)
                RenderItem (control, item, e);
        }

        protected virtual void RenderItem (ListView control, ListViewItem item, PaintEventArgs e)
        {
            if (item.Selected)
                e.Canvas.FillRectangle (item.Bounds, Theme.RibbonItemHighlightColor);

            var image_size = e.LogicalToDeviceUnits (32);
            var image_area = new Rectangle (item.Bounds.Left, item.Bounds.Top, item.Bounds.Width, item.Bounds.Width);
            var image_bounds = DrawingExtensions.CenterSquare (image_area, image_size);
            image_bounds.Y = item.Bounds.Top + e.LogicalToDeviceUnits (3);

            if (item.Image != null)
                e.Canvas.DrawBitmap (item.Image, image_bounds);

            if (!string.IsNullOrWhiteSpace (item.Text)) {
                var font_size = e.LogicalToDeviceUnits (Theme.RibbonItemFontSize);

                e.Canvas.Save ();
                e.Canvas.Clip (item.Bounds);

                var text_bounds = new Rectangle (item.Bounds.Left, image_bounds.Bottom + e.LogicalToDeviceUnits (3), item.Bounds.Width, item.Bounds.Bottom - image_bounds.Bottom - e.LogicalToDeviceUnits (3));

                e.Canvas.DrawText (item.Text, Theme.UIFont, font_size, text_bounds, Theme.DarkTextColor, ContentAlignment.MiddleCenter);

                e.Canvas.Restore ();
            }
        }
    }
}
