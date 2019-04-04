// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-24-2018
// ***********************************************************************
// <copyright file="PieInfo.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.PolygonCreator
{
    /// <summary>
    /// Class Pie.
    /// </summary>
    public class Pie
    {
        /// <summary>
        /// The start angle
        /// </summary>
        private float startAngle = 90f;
        /// <summary>
        /// The sweep angle
        /// </summary>
        private float sweepAngle = 90f;

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public float StartAngle { get => startAngle; set => startAngle = value; }
        /// <summary>
        /// Gets or sets the sweep angle.
        /// </summary>
        /// <value>The sweep angle.</value>
        public float SweepAngle { get => sweepAngle; set => sweepAngle = value; }
    }

}
