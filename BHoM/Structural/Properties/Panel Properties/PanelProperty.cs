using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public enum PanelDirection
    {
        X = 0,
        Y
    }
    public enum PanelType
    {
        Undefined,
        Slab,
        Wall,
        PileCap,
        DropPanel,
    }

    public enum PanelModifier
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
    /// Panel Property
    /// </summary>
    public abstract class PanelProperty : BHoMObject
    {
        public double[] Modifiers { get; set; }
        public PanelType Type { get; set; }
        public double Thickness { get; set; }
        public Materials.Material Material { get; set; }
        internal PanelProperty()
        {
            Modifiers = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        public PanelProperty(string name) : this()
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

    public class ConstantThickness : PanelProperty
    {
        internal ConstantThickness() { }
        public ConstantThickness(string name) : base(name) { Type = PanelType.Undefined; }
        public ConstantThickness(string name, double thickness, PanelType type) : this(name)
        {
            Thickness = thickness;
            Type = type;
        }
    }


    public class Waffle : PanelProperty
    {
        public double TotalDepthX { get; set; }
        public double TotalDepthY { get; set; }
        public double StemWidthX { get; set; }
        public double StemWidthY { get; set; }
        public double SpacingX { get; set; }
        public double SpacingY { get; set; }

        internal Waffle() { }

        public Waffle(string name) : base (name) { Type = PanelType.Slab; }

        public Waffle(string name, double slabDepth, double depthX, double depthY, double stemWidthX, double stemWidthY, double spacingX, double spacingY) : this(name)
        {
            Thickness = slabDepth;
            TotalDepthX = depthX;
            TotalDepthY = depthY;
            StemWidthX = stemWidthX;
            StemWidthY = stemWidthY;
            SpacingX = spacingX;
            SpacingY = spacingY;
        }
    }

    public class Ribbed : PanelProperty
    {
        public PanelDirection Direction { get; set; }
        public double TotalDepth { get; set; }
        public double StemWidth { get; set; }
        public double Spacing { get; set; }

        internal Ribbed() { }
        public Ribbed(string name) : base(name) { Type = PanelType.Slab; }

        public Ribbed(string name, double slabDepth, double totalDepth, double stemWidth, double spacing, PanelDirection direction) : this(name)
        {
            Thickness = slabDepth;
            TotalDepth = totalDepth;
            StemWidth = stemWidth;
            Spacing = spacing;
            Direction = direction;
        }
    }
}
