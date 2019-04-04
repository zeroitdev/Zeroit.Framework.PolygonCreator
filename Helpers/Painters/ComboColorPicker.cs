// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ComboColorPicker.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.PolygonCreator.Editors
{
    /// <summary>
    /// 	Implements a color picker which combines the web, system, and custom color pickers.
    /// </summary>
    [ToolboxItem(false)]
    public partial class ComboColorPicker : BaseColorPicker // UserControl
    {
        /// <summary>
        /// 	Constructor with no starting color.
        /// </summary>
        public ComboColorPicker() : this(Color.Empty)
        {
        }

        /// <summary>
        /// 	Constructor with starting color.
        /// </summary>
        /// <param name="color">Starting color.</param>
		public ComboColorPicker(Color color)
		{
            InitializeComponent();
			SetColor(color);
		}

        /// <summary>
        /// 	Set current selected color.
        /// </summary>
        /// <param name="color">Current color.</param>
        /// <returns><c>True</c>.</returns>
		public override bool SetColor(Color color)
		{
			customColorPicker.SetColor(color);
			if (webColorPicker.SetColor(color))
			{
				tabControl.SelectedTab = tabPageWeb;
			}
			else if (systemColorPicker.SetColor(color))
			{
				tabControl.SelectedTab = tabPageSystem;
			}
			else
			{
				tabControl.SelectedTab = tabPageCustom;
			}
            return true;
		}

        private void tab_ColorSelected(object sender, ColorSelectedEventArgs args)
        {
			SelectColor(args);
        }
	}
}
