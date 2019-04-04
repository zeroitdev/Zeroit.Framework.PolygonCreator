// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="WebColorPickerDialog.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.PolygonCreator.Editors
{
    /// <summary>
    ///     Represents a dialog that enabled the user to select a web color.
    /// </summary>
    public partial class WebColorPickerDialog : System.Windows.Forms.Form
    {
        /// <summary>
        ///     Default constructor (no starting color and default window position).
        /// </summary>
        public WebColorPickerDialog() : this(Color.Empty)
        {
		}

        /// <summary>
        ///     Constructor with starting color and default window position.
        /// </summary>
        /// <param name="color">Starting color.</param>
        public WebColorPickerDialog(Color color)
        {
            InitializeComponent();
			webColorPicker.SetColor(color);
        }

        /// <summary>
        ///     Constructor with no starting color and starting position beneath specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public WebColorPickerDialog(Control c) : this(Color.Empty, c)
		{
		}

        /// <summary>
        ///     Constructor with starting color and starting position beneath specified control.
        /// </summary>
        /// <param name="color">Starting color.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public WebColorPickerDialog(Color color, Control c)
		{
            InitializeComponent();
			Utils.SetStartPositionBelowControl(this, c);
			webColorPicker.SetColor(color);
		}

        /// <summary>
        ///     Consructor with no starting color and starting position.
        /// </summary>
        /// <param name="p">Starting position.</param>
		public WebColorPickerDialog(Point p) : this(Color.Empty, p)
		{
		}

        /// <summary>
        ///     Constructor with starting color and starting position.
        /// </summary>
        /// <param name="color">Starting color.</param>
        /// <param name="p">Starting position.</param>
		public WebColorPickerDialog(Color color, Point p)
		{
            InitializeComponent();
			Utils.SetStartPosition(this, p);
			webColorPicker.SetColor(color);
		}

		private Color color;
		/// <summary>
		///     Gets or sets selected color.
		/// </summary>
		/// <value>
		///     Selected color.
		/// </value>
		public Color Color
		{
			get { return color; }
			set	{ webColorPicker.SetColor(value); }
		}

		private string colorName;
		/// <summary>
		///     Gets name of selected color.
		/// </summary>
		/// <value>
		///     Name of selected color.
		/// </value>
		public string ColorName
		{
			get { return colorName; }
		}

        /// <summary>
        ///     Override to capture Esc key.
        /// </summary>
        /// <param name="keyCode">Key.</param>
        /// <returns><c>True</c> if key handled, <c>false</c> otherwise.</returns>
		protected override bool ProcessDialogKey(Keys keyCode)
		{
			if (keyCode == Keys.Escape)
			{
				DialogResult = DialogResult.Cancel;
                return true;
			}
            return false;
		}

        private void webColorPicker_ColorSelected(object sender, Zeroit.Framework.PolygonCreator.Editors.ColorSelectedEventArgs args)
        {
            color = args.Color;
			colorName = args.ColorName;
            DialogResult = DialogResult.OK;
        }
    }
}
