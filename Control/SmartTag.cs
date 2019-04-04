// ***********************************************************************
// Assembly         : Zeroit.Framework.PolygonCreator
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="SmartTag.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using Zeroit.Framework.PolygonCreator.Editors.Brushes;
using Zeroit.Framework.PolygonCreator.Editors.PenPainter;
using static Zeroit.Framework.PolygonCreator.PolygonInput;
using static Zeroit.Framework.PolygonCreator.ZeroitUltraControl;

namespace Zeroit.Framework.PolygonCreator
{


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitUltraControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitUltraControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitUltraControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitUltraControlSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitUltraControlSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitUltraControlSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitUltraControl colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltraControlSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitUltraControlSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitUltraControl;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the click speed.
        /// </summary>
        /// <value>The click speed.</value>
        public int ClickSpeed
        {
            get
            {
                return colUserControl.ClickSpeed;
            }
            set
            {
                GetPropertyByName("ClickSpeed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow click animation].
        /// </summary>
        /// <value><c>true</c> if [allow click animation]; otherwise, <c>false</c>.</value>
        public bool AllowClickAnimation
        {
            get
            {
                return colUserControl.AllowClickAnimation;
            }
            set
            {
                GetPropertyByName("AllowClickAnimation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the fill mode.
        /// </summary>
        /// <value>The fill mode.</value>
        public FillModes FillMode
        {
            get
            {
                return colUserControl.FillMode;
            }
            set
            {
                GetPropertyByName("FillMode").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public Shapes Shape
        {
            get
            {
                return colUserControl.Shape;
            }
            set
            {
                GetPropertyByName("Shape").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the polygon input.
        /// </summary>
        /// <value>The polygon input.</value>
        public PolygonInput PolygonInput
        {
            get
            {
                return colUserControl.PolygonInput;
            }
            set
            {
                GetPropertyByName("PolygonInput").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the fill.
        /// </summary>
        /// <value>The fill.</value>
        public BrushPainter Fill
        {
            get
            {
                return colUserControl.Fill;
            }
            set
            {
                GetPropertyByName("Fill").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public PenPainter Border
        {
            get
            {
                return colUserControl.Border;
            }
            set
            {
                GetPropertyByName("Border").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return colUserControl.TextRendering; }
            set
            {
                colUserControl.TextRendering = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return colUserControl.AllowTransparency; }
            set
            {
                colUserControl.AllowTransparency = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable hatch animation].
        /// </summary>
        /// <value><c>true</c> if [enable hatch animation]; otherwise, <c>false</c>.</value>
        public bool EnableHatchAnimation
        {
            get { return colUserControl.EnableHatchAnimation; }
            set
            {
                colUserControl.EnableHatchAnimation = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show reflection].
        /// </summary>
        /// <value><c>true</c> if [show reflection]; otherwise, <c>false</c>.</value>
        public bool ShowReflection
        {
            get { return colUserControl.ShowReflection; }
            set
            {
                colUserControl.ShowReflection = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show text].
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return colUserControl.ShowText; }
            set
            {
                colUserControl.ShowText = value;
            }
        }


        //Pie
        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public float StartAngle
        {
            get { return colUserControl.Pie.StartAngle; }
            set
            {
                colUserControl.Pie.StartAngle = value;
            }
        }

        /// <summary>
        /// Gets or sets the sweep angle.
        /// </summary>
        /// <value>The sweep angle.</value>
        public float SweepAngle
        {
            get { return colUserControl.Pie.SweepAngle; }
            set
            {
                colUserControl.Pie.SweepAngle = value;
            }
        }

        //Rectangle Info
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitUltraControlSmartTagActionList"/> is rounding.
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        {
            get { return colUserControl.RectangleInfo.Rounding; }
            set
            {
                colUserControl.RectangleInfo.Rounding = value;
            }
        }

        /// <summary>
        /// Gets or sets the curve.
        /// </summary>
        /// <value>The curve.</value>
        public int Curve
        {
            get { return colUserControl.RectangleInfo.Curve; }
            set
            {
                colUserControl.RectangleInfo.Curve = value;
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Behaviour"));


            items.Add(new DesignerActionPropertyItem("AllowClickAnimation",
                "Allow Click Animation", "Behaviour",
                "Set to allow animation when clicked."));

            items.Add(new DesignerActionPropertyItem("AllowTransparency",
                "Allow Transparency", "Behaviour",
                "Set to allow transparency."));

            items.Add(new DesignerActionPropertyItem("EnableHatchAnimation",
                "Hatch Animation", "Behaviour",
                "Set to enable hatch animation."));

            items.Add(new DesignerActionPropertyItem("ShowReflection",
                "Show Reflection", "Behaviour",
                "Set to show the control's reflection. (Applies to Polygon)"));

            items.Add(new DesignerActionPropertyItem("ShowText",
                "Show Text", "Behaviour",
                "Set to show the control's text."));

            
            items.Add(new DesignerActionHeaderItem("Appearance"));


            //items.Add(new DesignerActionPropertyItem("BackColor",
            //                     "Back Color", "Appearance",
            //                     "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Sets the text color."));

            items.Add(new DesignerActionPropertyItem("Shape",
                "Shape", "Appearance",
                "Sets the type of shape to use."));

            items.Add(new DesignerActionPropertyItem("PolygonInput",
                "Customize Polygon", "Appearance",
                "Use this to customize the default triangle."));


            items.Add(new DesignerActionPropertyItem("FillMode",
                "Fill Mode", "Appearance",
                "Sets how the control should appear to the user."));


            items.Add(new DesignerActionPropertyItem("Fill",
                "Fill", "Appearance",
                "Sets the solid color state for the control."));


            items.Add(new DesignerActionPropertyItem("Border",
                "Border", "Appearance",
                "Sets the border."));

            items.Add(new DesignerActionPropertyItem("TextRendering",
                "Text Rendering", "Appearance",
                "Sets how the text should be rendered."));

            items.Add(new DesignerActionPropertyItem("ClickSpeed",
                                 "Click Speed", "Appearance",
                                 "Sets the click speed."));
            

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Rectangle"));


            items.Add(new DesignerActionPropertyItem("Rounding",
                "Rounding", "Rectangle",
                "Set to enable the rectangle to have a rounded corner."));

            items.Add(new DesignerActionPropertyItem("Curve",
                "Curve", "Rectangle",
                "Sets the rounding curve value."));


            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Pie"));


            items.Add(new DesignerActionPropertyItem("StartAngle",
                "Start Angle", "Pie",
                "Set the angle to start the control from."));

            items.Add(new DesignerActionPropertyItem("SweepAngle",
                "Angle", "Pie",
                "Set the actual angle."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


}
