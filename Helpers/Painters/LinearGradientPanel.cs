// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="LinearGradientPanel.cs" company="Zeroit Dev Technologies">
//    This program is for creating a Polygon control with an Editor.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.PolygonCreator.Editors
{
    /// <summary>
    ///     Represents a control for displaying a linear color gradient.
    /// </summary>
    [ToolboxItem(false)]
    public partial class LinearGradientPanel : UserControl
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public LinearGradientPanel()
        {
            InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
						  ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.ResizeRedraw |
						  ControlStyles.UserPaint, true);

			this.UpdateStyles();
        }

		private ColorBlend blend;
        /// <summary>
        ///     Gets or sets color blend.
        /// </summary>
        /// <value>
        ///     Color blend.
        /// </value>
		public ColorBlend Blend
		{
			get { return blend; }
			set
			{
				blend = value;
				Redraw();
			}
		}

		private LinearGradientMode mode = LinearGradientMode.Horizontal;
        /// <summary>
        ///     Gets or sets linear gradient mode.
        /// </summary>
        /// <value>
        ///     Linear gradient mode.
        /// </value>
		public LinearGradientMode Mode
		{
			get { return mode; }
			set
			{
				mode = value;
				Redraw();
			}
		}

        private LinearGradientBrush2 br = null;

        private void Redraw()
        {
            if (br != null)
            {
                br.Dispose();
                br = null;
            }
            Invalidate(true);
        }

        private void this_Paint(object sender, PaintEventArgs e)
        {
			if (blend != null)
			{
				if (br == null)
				{
					br = new LinearGradientBrush2(this.ClientRectangle, blend, mode);
				}
	            br.FillRectangle(e.Graphics, this.ClientRectangle, SystemBrushes.Window);
			}
        }
    }
}
