// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="PainterPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.PolygonCreator.Editors.Brushes
{
    /// <summary>
    /// 	Represents a control for displaying a <c>BrushPainter</c> value.
    /// </summary>
    [ToolboxItem(false)]
    public partial class BrushPainterPanel : UserControl
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public BrushPainterPanel()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);

            this.UpdateStyles();
        }

        private BrushPainter filler = new BrushPainter();
        /// <summary>
        ///     Gets or sets the simple filler.
        /// </summary>
        /// <value>
        ///     The simple filler.
        /// </value>
        public BrushPainter BrushPainter
        {
            get { return filler; }
            set
            {
                filler = value;
                Invalidate();
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void this_Paint(object sender, PaintEventArgs e)
        {
            if (filler != null)
            {
                Brush brush = filler.GetBrush(ClientRectangle);
                if (brush != null)
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                    brush.Dispose();
                }
            }
        }
    }
}
