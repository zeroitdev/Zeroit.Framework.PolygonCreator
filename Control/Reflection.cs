// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Reflection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
