// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="RectangleInfo.cs" company="Zeroit Dev Technologies">
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
    /// Class RectangleInfo.
    /// </summary>
    public class RectangleInfo
    {
        /// <summary>
        /// The rounding
        /// </summary>
        private bool rounding = false;
        /// <summary>
        /// The upper left
        /// </summary>
        private int upperLeft = 10;
        /// <summary>
        /// The upper right
        /// </summary>
        private int upperRight = 10;
        /// <summary>
        /// Down left
        /// </summary>
        private int downLeft = 10;
        /// <summary>
        /// Down right
        /// </summary>
        private int downRight = 10;

        /// <summary>
        /// The curve
        /// </summary>
        private int curve = 10;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RectangleInfo"/> is rounding.
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        { get => rounding; set => rounding = value; }
        /// <summary>
        /// Gets or sets the upper left.
        /// </summary>
        /// <value>The upper left.</value>
        public int UpperLeft
        {
            get => upperLeft;
            set
            {
                if (value < 1) { value = 1; }
                upperLeft = value;
            }
        }
        /// <summary>
        /// Gets or sets the upper right.
        /// </summary>
        /// <value>The upper right.</value>
        public int UpperRight
        {
            get => upperRight;
            set
            {
                if (value < 1) { value = 1; }
                upperRight = value;
            }
        }
        /// <summary>
        /// Gets or sets down left.
        /// </summary>
        /// <value>Down left.</value>
        public int DownLeft
        {
            get => downLeft;
            set
            {
                if (value < 1) { value = 1; }
                downLeft = value;
            }
        }
        /// <summary>
        /// Gets or sets down right.
        /// </summary>
        /// <value>Down right.</value>
        public int DownRight
        {
            get => downRight;
            set
            {
                if (value < 1) { value = 1; }
                downRight = value;
            }
        }

        /// <summary>
        /// Gets or sets the curve.
        /// </summary>
        /// <value>The curve.</value>
        public int Curve
        {
            get { return curve; }
            set
            {
                if (value != null)
                {
                    upperLeft = value;
                    upperRight = value;
                    downLeft = value;
                    downRight = value;
                }

                if (value < 1)
                {
                    value = 1;
                }
                curve = value;

            }
        }
    }
}
