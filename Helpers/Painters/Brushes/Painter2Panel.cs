// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Painter2Panel.cs" company="Zeroit Dev Technologies">
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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.PolygonCreator.Editors.Brushes
{
    /// <summary>
    /// 	Represents a control for displaying a <c>BrushPainter2</c> value.
    /// </summary>
    [ToolboxItem(false)]
    public partial class BrushPainter2Panel : UserControl
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public BrushPainter2Panel()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);

            this.UpdateStyles();
        }

        private BrushPainter2 filler = new BrushPainter2();
        /// <summary>
        ///     Gets or sets the simple filler.
        /// </summary>
        /// <value>
        ///     The simple filler.
        /// </value>
        public BrushPainter2 BrushPainter
        {
            get { return filler; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("BrushPainter");
                }
                filler = value;
                Invalidate();
            }
        }

        private void this_Paint(object sender, PaintEventArgs e)
        {
            Brush br = filler.GetBrush(ClientRectangle);
            if (br != null)
            {
                e.Graphics.FillRectangle(br, ClientRectangle);
                br.Dispose();
            }
        }
    }
}
