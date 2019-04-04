// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="UltraControl.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Zeroit.Framework.PolygonCreator.Editors.Brushes;
using Zeroit.Framework.PolygonCreator.Editors.PenPainter;
using static Zeroit.Framework.PolygonCreator.PolygonInput;

namespace Zeroit.Framework.PolygonCreator
{

    /// <summary>
    /// Class ZeroitUltraControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitUltraControlDesigner))]
    public class ZeroitUltraControl : Control
    {

        #region Enum

        /// <summary>
        /// Enum Shapes
        /// </summary>
        public enum Shapes
        {
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle,
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
            /// <summary>
            /// The pie
            /// </summary>
            Pie,
            /// <summary>
            /// The polygon
            /// </summary>
            Polygon
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// The fill
        /// </summary>
        private BrushPainter fill = new BrushPainter(90f, Color.AliceBlue, Color.Lime);

        /// <summary>
        /// The border
        /// </summary>
        private PenPainter border = new PenPainter(Color.White, 1f);

        /// <summary>
        /// The reflection
        /// </summary>
        private Reflection reflection = new Reflection();

        /// <summary>
        /// The pie
        /// </summary>
        private Pie pie = new Pie();

        /// <summary>
        /// The rectangle information
        /// </summary>
        private RectangleInfo rectangleInfo = new RectangleInfo();

        /// <summary>
        /// The polygon input
        /// </summary>
        private Zeroit.Framework.PolygonCreator.PolygonInput polygonInput = new Zeroit.Framework.PolygonCreator.PolygonInput(
            new List<List<Point>>()
            {
                new List<Point>()
                {
                    new Point(0, 0),
                    new Point(50, 50),
                    new Point(100, 0),
                    new Point(0, 0)
                }
            }, PolygonInput.FillModes.Both, PolygonInput.ShapeTypes.Polygon
        );

        /// <summary>
        /// The shape
        /// </summary>
        private Shapes shape = Shapes.Circle;

        /// <summary>
        /// The show reflection
        /// </summary>
        private bool showReflection = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the fill mode.
        /// </summary>
        /// <value>The fill mode.</value>
        public FillModes FillMode
        {
            get { return PolygonInput.FillMode; }
            set
            {
                PolygonInput.FillMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public Shapes Shape
        {
            get { return shape; }
            set
            {
                shape = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the polygon input.
        /// </summary>
        /// <value>The polygon input.</value>
        public PolygonInput PolygonInput
        {
            get { return polygonInput; }
            set
            {
                polygonInput = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the fill.
        /// </summary>
        /// <value>The fill.</value>
        public BrushPainter Fill
        {
            get { return fill; }
            set
            {
                fill = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public PenPainter Border
        {
            get { return border; }
            set
            {
                border = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the reflection.
        /// </summary>
        /// <value>The reflection.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Reflection Reflection
        {
            get { return reflection; }
            set
            {
                reflection = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pie.
        /// </summary>
        /// <value>The pie.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Pie Pie
        {
            get { return pie; }
            set
            {
                pie = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rectangle information.
        /// </summary>
        /// <value>The rectangle information.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public RectangleInfo RectangleInfo
        {
            get { return rectangleInfo; }
            set
            {
                rectangleInfo = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show reflection].
        /// </summary>
        /// <value><c>true</c> if [show reflection]; otherwise, <c>false</c>.</value>
        public bool ShowReflection
        {
            get { return showReflection; }
            set
            {
                showReflection = value;
                Invalidate();
            }
        }


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                if(value == SmoothingMode.Invalid)
                {
                    value = SmoothingMode.Default;
                }
                smoothing = value;
                Invalidate();
            }
        }

        #endregion


        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAliasGridFit;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }

        #endregion

        #region Compositing Quality

        /// <summary>
        /// The composite quality
        /// </summary>
        private CompositingQuality compositeQuality = CompositingQuality.HighQuality;

        /// <summary>
        /// Gets or sets the compositing quality.
        /// </summary>
        /// <value>The compositing quality.</value>
        public CompositingQuality CompositingQuality
        {
            get { return compositeQuality; }
            set
            {
                compositeQuality = value;
                Invalidate();
            }
        }

        #endregion

        #region Interpolation Mode
        /// <summary>
        /// The interpolation mode
        /// </summary>
        private InterpolationMode interpolationMode = InterpolationMode.Default;
        /// <summary>
        /// Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        public InterpolationMode InterpolationMode
        {
            get { return interpolationMode; }
            set
            {
                interpolationMode = value;
                Invalidate();
            }
        }

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltraControl"/> class.
        /// </summary>
        public ZeroitUltraControl()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            DoubleBuffered = true;
            locate = new Point(Location.X, Location.Y);
            ClickTimer.Interval = 1;
            ClickTimer.Tick += ClickTimer_Tick;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltraControl"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ZeroitUltraControl(IContainer container) : base()
        {
            container.Add(this);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
            DoubleBuffered = true;
            locate = new Point(Location.X, Location.Y);
            ClickTimer.Tick += ClickTimer_Tick;
        }
        #endregion

        #region Paint and Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Rectangle reflection = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height / 2);
            Rectangle bounds = this.ClientRectangle;
            bounds.Inflate(-2, -2);

            GraphicsPath shape = RoundRect(bounds, RectangleInfo.UpperLeft, RectangleInfo.UpperRight, RectangleInfo.DownLeft, RectangleInfo.DownRight);

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
                       
            G.SmoothingMode = Smoothing;
            G.TextRenderingHint = TextRendering;
            G.CompositingQuality = CompositingQuality;
            G.InterpolationMode = InterpolationMode;

            if (EnableHatchAnimation)
            {
                G.RenderingOrigin = new Point(reactorOFS, 0);
            }

            if (AllowTransparency)
            {
                MakeTransparent(this, G);
            }


            switch (Shape)
            {
                case Shapes.Rectangle:
                    if(RectangleInfo.Rounding)
                    {
                        switch (FillMode)
                        {
                            case PolygonInput.FillModes.Fill:
                                G.FillPath(Fill.GetBrush(bounds), shape);
                                break;
                            case PolygonInput.FillModes.Border:
                                G.DrawPath(Border.GetPen(), shape);
                                break;
                            case PolygonInput.FillModes.Both:
                                G.FillPath(Fill.GetBrush(bounds), shape);
                                G.DrawPath(Border.GetPen(), shape);
                                break;
                            default:
                                break;
                        }
                        
                    }
                    else
                    {
                        switch (FillMode)
                        {
                            case PolygonInput.FillModes.Fill:
                                G.FillRectangle(Fill.GetBrush(bounds), bounds);
                                break;
                            case PolygonInput.FillModes.Border:
                                G.DrawRectangle(Border.GetPen(), bounds);
                                break;
                            case PolygonInput.FillModes.Both:
                                G.FillRectangle(Fill.GetBrush(bounds), bounds);
                                G.DrawRectangle(Border.GetPen(), bounds);
                                break;
                            default:
                                break;
                        }
                        
                    }
                    
                    break;
                case Shapes.Circle:
                    switch (FillMode)
                    {
                        case PolygonInput.FillModes.Fill:
                            G.FillEllipse(Fill.GetBrush(bounds), bounds);
                            break;
                        case PolygonInput.FillModes.Border:
                            G.DrawEllipse(Border.GetPen(), bounds);
                            break;
                        case PolygonInput.FillModes.Both:
                            G.FillEllipse(Fill.GetBrush(bounds), bounds);
                            G.DrawEllipse(Border.GetPen(), bounds);
                            break;
                        default:
                            break;
                    }
                    
                    break;
                case Shapes.Pie:
                    switch (FillMode)
                    {
                        case PolygonInput.FillModes.Fill:
                            G.FillPie(Fill.GetBrush(bounds), bounds, Pie.StartAngle, Pie.SweepAngle);
                            break;
                        case PolygonInput.FillModes.Border:
                            G.DrawPie(Border.GetPen(), bounds, Pie.StartAngle, Pie.SweepAngle);

                            break;
                        case PolygonInput.FillModes.Both:
                            G.FillPie(Fill.GetBrush(bounds), bounds, Pie.StartAngle, Pie.SweepAngle);
                            G.DrawPie(Border.GetPen(), bounds, Pie.StartAngle, Pie.SweepAngle);

                            break;
                        default:
                            break;
                    }
                    break;
                case Shapes.Polygon:

                    PolygonInput.DrawShape(G, Fill.GetBrush(ClientRectangle), Border.GetPen());
                    if (ShowReflection)
                    {
                        e.Graphics.DrawReflection(B, reflection, Reflection.Gap, Reflection.Height, Reflection.StartAlpha, Reflection.EndAlpha);

                    }

                    break;
                default:
                    break;
            }

            //this.CreateDropShadow();

            DrawImage(G, bounds);
            e.Graphics.DrawImage(B, 0, 0);
            
            G.Dispose();
            B.Dispose();
            if (!DesignMode)
            {
                GC.Collect();
            }
        }

        #endregion

        #region Click Animation
        //--------------------------------Include in Constructor---------------------------//
        //locate = new Point(Location.X, Location.Y);
        //AnimationTimer.Tick += new EventHandler(AnimationTick);
        //ClickTimer.Tick += ClickTimer_Tick;
        //--------------------------------Include in Constructor---------------------------//

        #region Fields
        /// <summary>
        /// The xx
        /// </summary>
        int xx;
        /// <summary>
        /// The yy
        /// </summary>
        int yy;
        /// <summary>
        /// The clicked
        /// </summary>
        private bool clicked = false;
        /// <summary>
        /// The locate
        /// </summary>
        private Point locate;
        /// <summary>
        /// The click timer
        /// </summary>
        Timer ClickTimer = new Timer();
        /// <summary>
        /// The allow click animation
        /// </summary>
        private bool allowClickAnimation = true;
        /// <summary>
        /// The clickinterval
        /// </summary>
        private int clickinterval = 1;
        /// <summary>
        /// The click limit
        /// </summary>
        private int clickLimit = 10;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the c lick limit.
        /// </summary>
        /// <value>The c lick limit.</value>
        public int CLickLimit
        {
            get { return clickLimit; }
            set
            {
                clickLimit = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the click speed.
        /// </summary>
        /// <value>The click speed.</value>
        public int ClickSpeed
        {
            get { return ClickTimer.Interval; }
            set
            {
                ClickTimer.Interval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow click animation].
        /// </summary>
        /// <value><c>true</c> if [allow click animation]; otherwise, <c>false</c>.</value>
        public bool AllowClickAnimation
        {
            get { return allowClickAnimation; }
            set
            {
                allowClickAnimation = value;
                Invalidate();
            }
        }
        #endregion

        #region Events


        /// <summary>
        /// Handles the Tick event of the ClickTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ClickTimer_Tick(object sender, EventArgs e)
        {

            if (clicked)
            {
                this.Location = new Point(Location.X, Location.Y + 1);
                //this.Location = new Point(Location.X, Location.Y - 10);
            }
            else
            {
                this.Location = locate;
            }

            if (Location.Y > locate.Y + CLickLimit)
            {
                this.Location = locate;
                ClickTimer.Stop();
            }

            Invalidate();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            locate = new Point(Location.X, Location.Y);
            clicked = true;

            xx = e.X;
            yy = e.Y;
            //Focus = true;
            //AnimationTimer.Start();

            ClickTimer.Start();

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            clicked = false;

            //Focus = false;
            //AnimationTimer.Start();
            if (allowClickAnimation)
            {
                ClickTimer.Start();
            }

            Invalidate();
        }

        #endregion

        #endregion

        #region Hatch Animation

        /// <summary>
        /// The enable hatch animation
        /// </summary>
        private bool enableHatchAnimation = true;

        /// <summary>
        /// Gets or sets a value indicating whether [enable hatch animation].
        /// </summary>
        /// <value><c>true</c> if [enable hatch animation]; otherwise, <c>false</c>.</value>
        public bool EnableHatchAnimation
        {
            get { return enableHatchAnimation; }
            set
            {
                enableHatchAnimation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hatch speed.
        /// </summary>
        /// <value>The hatch speed.</value>
        public int HatchSpeed
        {
            get { return hatchSpeed; }
            set
            {
                hatchSpeed = value;
                Invalidate();
            }
        }



        //---------------------------Include in Paint--------------------//
        //                                                               //
        //        G.RenderingOrigin = new Point(reactorOFS, 0);          //
        //                                                               //
        //---------------------------Include in Paint--------------------//

        /// <summary>
        /// The reactor ofs
        /// </summary>
        private int reactorOFS = 20;
        /// <summary>
        /// The hatch speed
        /// </summary>
        private int hatchSpeed = 50;

        /// <summary>
        /// Reactors the create handle.
        /// </summary>
        private void ReactorCreateHandle()
        {

            if (EnableHatchAnimation)
            {
                // Dim tmr As New Timer With {.Interval = hatchSpeed}
                // AddHandler tmr.Tick, AddressOf ReactorAnimate
                // tmr.Start()
                System.Threading.Thread T = new System.Threading.Thread(ReactorAnimate);
                T.IsBackground = true;
                T.Start();
            }

        }

        /// <summary>
        /// Reactors the animate.
        /// </summary>
        public void ReactorAnimate()
        {
            while (true)
            {
                if (reactorOFS <= Width)
                {
                    reactorOFS += 1;
                }
                else
                {
                    reactorOFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(hatchSpeed);
            }
        }

        /// <summary>
        /// Creates a handle for the control.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();

            ReactorCreateHandle();
        }

        #endregion

        #region Dispose
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
                ClickTimer.Stop();
                ClickTimer.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #endregion

        #region Private Methods

        #region Rounded Rectangle

        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="Rectangle">Set Rectangle</param>
        /// <param name="UpperLeftCurve">Set Upper Left Curve</param>
        /// <param name="UpperRightCurve">Set Upper Right Curve</param>
        /// <param name="DownLeftCurve">Set Down Left Curve</param>
        /// <param name="DownRightCurve">Set Down Right Curve</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath RoundRect(Rectangle Rectangle, int UpperLeftCurve, int UpperRightCurve, int DownLeftCurve, int DownRightCurve)
        {
            GraphicsPath P = new GraphicsPath();

            int UpperLeftCorner = UpperLeftCurve * 2;
            int UpperRightCorner = UpperRightCurve * 2;
            int DownLeftCorner = DownLeftCurve * 2;
            int DownRightCorner = DownRightCurve * 2;

            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, UpperLeftCorner, UpperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - UpperRightCorner + Rectangle.X, Rectangle.Y, UpperRightCorner, UpperRightCorner), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - DownRightCorner + Rectangle.X, Rectangle.Height - DownRightCorner + Rectangle.Y, DownRightCorner, DownRightCorner), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - DownLeftCorner + Rectangle.Y, DownLeftCorner, DownLeftCorner), 90, 90);

            P.CloseAllFigures();
            return P;
        }


        #endregion

        #region Transparent Code

        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion

        #endregion

        #endregion

        #region Image Designer

        #region Include in paint method

        ///////////////////////////////////////////////////////////////////////////////////////////////// 
        //                                                                                             //                                                                     
        //         ------------------------Add this to the Paint Method ------------------------       //
        //                                                                                             //
        // Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
        //                                                                                             //
        // PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
        //                                                                                             //
        // if ((Image == null))                                                                        //
        //     {                                                                                       //
        //         G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        // else                                                                                        //
        //      {                                                                                      //
        //         G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
        //          G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        //                                                                                             //
        /////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;
        /// <summary>
        /// The show text
        /// </summary>
        private bool showText = true;
        #endregion

        #region Include in Public Properties
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show text].
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return showText; }
            set
            {
                showText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public StringAlignment TextAlign
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }


        #endregion

        #region Include in Private Methods
        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <param name="_ContentAlignment">The content alignment.</param>
        /// <returns>StringFormat.</returns>
        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="R1">The r1.</param>
        private void DrawImage(Graphics G, Rectangle R1)
        {
            //Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          
            G.SmoothingMode = Smoothing;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            if ((Image == null))
            {
                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center

                    });
            }
            else
            {
                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);

                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
            }

        }


        #endregion
        #endregion
        

    }

    
    
}
