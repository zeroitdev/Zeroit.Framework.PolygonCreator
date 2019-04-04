﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Painter2Panel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
