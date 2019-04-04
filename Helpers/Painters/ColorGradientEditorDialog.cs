// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ColorGradientEditorDialog.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.PolygonCreator.Editors
{
    /// <summary>
    ///     Represents a dialog that enables the user to design and edit a color gradient.
    /// </summary>
    public partial class ColorGradientEditorDialog : System.Windows.Forms.Form
    {
        /// <summary>
        ///     Constructor with no starting color blend and default window position.
        /// </summary>
        public ColorGradientEditorDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Constructor with starting color blend and default window position.
        /// </summary>
        /// <param name="blend">Starting color blend.</param>
        public ColorGradientEditorDialog(ColorBlend blend)
        {
            InitializeComponent();
			colorGradientEditor.Blend = blend;
        }

        /// <summary>
        ///     Constructor with no starting color gradient and starting position beneath specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public ColorGradientEditorDialog(Control c)
		{
            InitializeComponent();
			Utils.SetStartPositionBelowControl(this, c);
		}

        /// <summary>
        ///     Constructor with starting color blend and starting position beneath specified control.
        /// </summary>
        /// <param name="blend">Starting color blend.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public ColorGradientEditorDialog(ColorBlend blend, Control c)
        {
            InitializeComponent();
			colorGradientEditor.Blend = blend;
			Utils.SetStartPositionBelowControl(this, c);
        }

        /// <summary>
        ///     Consructor with no starting color blend and starting position.
        /// </summary>
        /// <param name="p">Starting position.</param>
		public ColorGradientEditorDialog(Point p)
		{
            InitializeComponent();
			Utils.SetStartPosition(this, p);
		}

        /// <summary>
        ///     Constructor with starting color blend and starting position.
        /// </summary>
        /// <param name="blend">Starting color blend.</param>
        /// <param name="p">Starting position.</param>
        public ColorGradientEditorDialog(ColorBlend blend, Point p)
        {
            InitializeComponent();
			colorGradientEditor.Blend = blend;
			Utils.SetStartPosition(this, p);
        }

		/// <summary>
		///     Gets or sets current color blend.
		/// </summary>
		/// <value>
		///     Current color blend.
		/// </value>
		public ColorBlend Blend
		{
			get { return colorGradientEditor.Blend; }
			set { colorGradientEditor.Blend = value; }
		}

        private void cancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.OK;
        }

        private void colorGradientEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
