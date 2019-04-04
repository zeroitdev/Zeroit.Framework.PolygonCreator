// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="LineEditorDialog.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Design;
using System.Windows.Forms;

namespace Zeroit.Framework.PolygonCreator.Editors
{
    /// <summary>
    ///     Implements a dialog which allows design and editing of a <c>Line</c> object.
    /// 	May be used in designer.
    /// </summary>
    public partial class LineEditorDialog : System.Windows.Forms.Form
    {
        /// <summary>
        ///     Initializes a new instance of <c>LineEditorDialog</c> with a default <c>Line</c>
        ///     and default window position.
        /// </summary>
        public LineEditorDialog() : this((Line)null)
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of <c>LineEditorDialog</c> using an existing <c>Line</c>
        ///     and default window position.
        /// </summary>
        /// <param name="line">Existing <c>Line</c>.</param>
        public LineEditorDialog(Line line)
        {
            InitializeComponent();
			SetLine(line);
            ShowLine();
        }

        /// <summary>
        ///     Initializes a new instance of <c>LineEditorDialog</c> with a default <c>Line</c>
        ///     and starting beneath a specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public LineEditorDialog(Control c) : this(null, c)
		{
		}

        /// <summary>
        ///     Initializes a new instance of <c>LineEditorDialog</c> using an existing <c>Line</c>
        ///     and starting beneath a specified control.
        /// </summary>
        /// <param name="line">Existing <c>Line</c>.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public LineEditorDialog(Line line, Control c)
		{
            InitializeComponent();
			Utils.SetStartPositionBelowControl(this, c);
			SetLine(line);
		}

		private void SetLine(Line line)
		{
			if (line == null)
			{
				line = new Line();
			}
			colorLabel.BackColor = Color.FromArgb(255, line.Color);
			alphaNud.Value = (decimal)line.Color.A;
			dashStyleComboBox.SelectedDashStyle = line.DashStyle;
			widthNud.Value = (decimal)line.Width;
            ShowLine();
		}

        /// <summary>
        ///     Gets the line selected by the user.
        /// </summary>
		/// <value>
		/// 	The line selected by the user.
		/// </value>
		public Line Line
		{
			get { return new Line(Color.FromArgb((int)alphaNud.Value, colorLabel.BackColor),
								  (float)widthNud.Value,
								  dashStyleComboBox.SelectedDashStyle); }
		}

		private void ShowLine()
		{
			Line line = Line;
			linePanel1.Line = line;
			linePanel2.Line = line;
		}

        private void okButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.OK;
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(colorLabel.BackColor, colorButton);
            if (d.ShowDialog() == DialogResult.OK)
            {
                colorLabel.BackColor = d.Color;
				ShowLine();
            }
        }

        private void dashStyleComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
			ShowLine();
        }

        private void widthNud_ValueChanged(object sender, EventArgs e)
        {
			ShowLine();
        }

        private void alphaNud_ValueChanged(object sender, EventArgs e)
        {
            ShowLine();
        }

        private void colorButton_MouseEnter(object sender, EventArgs e)
        {
            colorButton.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
        }

        private void colorButton_MouseLeave(object sender, EventArgs e)
        {
            colorButton.FlatAppearance.BorderColor = Color.FromArgb(56,56,56);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    ///     The <c>UITypeEditor</c> derived class which indicates how a <c>Line</c>
    ///     object can be edited directly from Visual Studio Designer.
    /// </summary>
    /// <remarks>
    ///     Note that this class is <b>NOT</b> meant to be invoked directly
    /// </remarks>
	public class LineEditor : System.Drawing.Design.UITypeEditor
	{
	    /// <summary>
	    ///     Gets the editor style used by the <c>EditValue</c> method.
	    /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
	    /// <returns><c>UITypeEditorEditStyle.Modal</c></returns>
		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

        /// <summary>
        ///     Creates and displays a <c>LineEditorDialog</c> dialog if <c>value</c> is a <c>Line</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>Line</c> being edited.</param>
        /// <returns>The new value of the <c>Line</c> being edited.</returns>
		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
										 System.IServiceProvider provider,
										 object value)
		{
			if (value is Line)
			{
				LineEditorDialog dialog = new LineEditorDialog((Line)value);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					return dialog.Line;
				}
			}
			return value;
		}

        /// <summary>
        ///     Indicates that painting is supported.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>true</c>.</returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

        /// <summary>
        ///     Paint a representation of the line (usually in designer).
        /// </summary>
        /// <param name="e">A <c>PaintValueEventArgs</c> that indicates what to paint and where to paint it.</param>
		public override void PaintValue(PaintValueEventArgs e)
		{   
			if (e.Value is Line)
			{
				int y = e.Bounds.Height / 2;
				Pen pen = ((Line)e.Value).GetPen();
				if (pen != null)
				{
					e.Graphics.DrawLine(pen, e.Bounds.X, y, e.Bounds.X + e.Bounds.Width - 1, y);
				}
			}
		}
	}
}
