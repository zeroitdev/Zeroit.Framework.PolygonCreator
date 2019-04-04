// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-17-2018
// ***********************************************************************
// <copyright file="ComboColorPickerDialog.Designer.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.PolygonCreator.Editors
{
    partial class ComboColorPickerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboColorPicker = new Zeroit.Framework.PolygonCreator.Editors.ComboColorPicker();
            this.SuspendLayout();
            // 
            // comboColorPicker
            // 
            this.comboColorPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.comboColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboColorPicker.Location = new System.Drawing.Point(0, 0);
            this.comboColorPicker.MinimumSize = new System.Drawing.Size(304, 338);
            this.comboColorPicker.Name = "comboColorPicker";
            this.comboColorPicker.Size = new System.Drawing.Size(324, 398);
            this.comboColorPicker.TabIndex = 0;
            this.comboColorPicker.ColorSelected += new Zeroit.Framework.PolygonCreator.Editors.BaseColorPicker.ColorSelectedEventHandler(this.comboColorPicker_ColorSelected);
            // 
            // ComboColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(324, 398);
            this.Controls.Add(this.comboColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(324, 398);
            this.Name = "ComboColorPickerDialog";
            this.Text = "Color Picker";
            this.ResumeLayout(false);

        }

        #endregion

        private ComboColorPicker comboColorPicker;
    }
}