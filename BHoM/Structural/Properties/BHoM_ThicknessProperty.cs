using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    public enum PanelDirection
    {
        X = 0,
        Y
    }
    public enum ThicknessType
    {
        Constant,
        Variable,
        Ribbed,
        Waffle,
        Drop
    }

    public enum ThicknessModifier
    {
        //In plane axial stiffness in the local X direction
        f11 = 0,
        //In plane axial stiffness in the local XY direction
        f12,
        //In plane axial stiffness in the local Y direction
        f22,
        //In plane flexural stiffness in the local X direction
        m11,
        //In plane flexural stiffness in the local XY direction
        m12,
        //In plane flexural stiffness in the local Y direction
        m22,
        //Shear stiffness in the X - normal direction
        v13,
        //Shear stiffness in the Y - normal direction
        v23,
        //Mass modifier
        Mass,
        //weight modifier
        Weight
    }

    /// <summary>
    /// Thickness Property
    /// </summary>
    public abstract class ThicknessProperty : BHoMObject
    {
        public double[] Modifiers { get; set; }
        public ThicknessType Type { get; set; }
        public double Thickness { get; set; }
        internal ThicknessProperty()
        {
            Modifiers = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        public ThicknessProperty(string name) : this()
        {
            Name = name;
        } 

        public bool HasModifiers()
        {
            for (int i =0; i < Modifiers.Length; i++)
            {
                if (Modifiers[i] != 1) return true;
            }
            return false;
        }
    }

    public class ConstantThickness : ThicknessProperty
    {
        internal ConstantThickness() { }
        public ConstantThickness(string name) : base(name) { Type = ThicknessType.Constant; }
        public ConstantThickness(string name, double thickness) : this(name) { Thickness = thickness; }
    }


    public class WaffleThickness : ThicknessProperty
    {
        public double TotalDepthX { get; set; }
        public double TotalDepthY { get; set; }
        public double StemWidthX { get; set; }
        public double StemWidthY { get; set; }
        public double SpacingX { get; set; }
        public double SpacingY { get; set; }

        internal WaffleThickness() { }

        public WaffleThickness(string name) : base (name) { Type = ThicknessType.Waffle; }

        public WaffleThickness(string name, double slabThickness, double depthX, double depthY, double stemWidthX, double stemWidthY, double spacingX, double spacingY) : this(name)
        {
            TotalDepthX = depthX;
            TotalDepthY = depthY;
            StemWidthX = stemWidthX;
            StemWidthY = stemWidthY;
            SpacingX = spacingX;
            SpacingY = spacingY;
        }
    }

    public class RibbedThickness : ThicknessProperty
    {
        public PanelDirection Direction { get; set; }
        public double TotalDepth { get; set; }
        public double StemWidth { get; set; }
        public double Spacing { get; set; }

        internal RibbedThickness() { }
        public RibbedThickness(string name) : base(name) { Type = ThicknessType.Ribbed; }

        public RibbedThickness(string name, double slabThickness, double depth, double stemWidth, double spacing, PanelDirection direction) : this(name)
        {
            TotalDepth = depth;
            StemWidth = stemWidth;
            Spacing = spacing;
            Direction = direction;
        }
    }
}
