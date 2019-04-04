// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Reflection.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.PolygonCreator
{

    /// <summary>
    /// Class Reflection.
    /// </summary>
    public class Reflection
    {
        /// <summary>
        /// The gap
        /// </summary>
        private int gap = 10;
        /// <summary>
        /// The height
        /// </summary>
        private int height = 100;
        /// <summary>
        /// The start alpha
        /// </summary>
        private float startAlpha = 60f;
        /// <summary>
        /// The end alpha
        /// </summary>
        private int endAlpha = 255;

        /// <summary>
        /// Gets or sets the gap.
        /// </summary>
        /// <value>The gap.</value>
        public int Gap { get => gap; set => gap = value; }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get => height; set => height = value; }
        /// <summary>
        /// Gets or sets the start alpha.
        /// </summary>
        /// <value>The start alpha.</value>
        public float StartAlpha { get => startAlpha; set => startAlpha = value; }
        /// <summary>
        /// Gets or sets the end alpha.
        /// </summary>
        /// <value>The end alpha.</value>
        public int EndAlpha { get => endAlpha; set => endAlpha = value; }
    }

}
