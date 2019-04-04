// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="LinePanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.PolygonCreator.Editors.PenPainter
{
    /// <summary>
    /// 	Represents a control for displaying a line.
    /// </summary>
    [ToolboxItem(false)]
    public partial class PenPainterPanel : UserControl
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public PenPainterPanel()
        {
            InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
						  ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.ResizeRedraw |
						  ControlStyles.UserPaint, true);

			this.UpdateStyles();

			line = new PenPainter();
        }

		private PenPainter line;
		/// <summary>
		///     Get line displayed in panel.
		/// </summary>
		/// <value>
		///     PenPainter displayed in panel.
		/// </value>
		public PenPainter PenPainter
		{
			get { return line; }
			set
			{
				line = value;
				Invalidate();
			}
		}

		private Orientation orient;
		/// <summary>
		///     Get display orientation of line.
		/// </summary>
		/// <value>
		///     Display orientation of line.
		/// </value>
		public Orientation Orientation
		{
			get { return orient; }
			set 
			{
				orient = value;
				Invalidate();
			}
		}

        private void PenPainterPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = line.GetPen();
			if (orient == Orientation.Horizontal)
			{
	            int y = ClientSize.Height / 2;
    	        e.Graphics.DrawLine(pen, 0, y, ClientSize.Width - 1, y);
			}
			else
			{
				int x = ClientSize.Width / 2;
				e.Graphics.DrawLine(pen, x, 0, x, ClientSize.Height - 1);
			}
        }
    }
}
