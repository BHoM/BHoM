using BHoM.Geometry;
using BHoM.Base;
using BHoM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using BHoM.Structural.Databases;

namespace BHoM.Structural.Properties
{
    public enum Fabrication
    {
        Welded,
        HotRolled,
        HotFormed, 
        ColdFormed
    }

    public enum PlateRestraint
    {
        NoRestraint,
        TopFlangeRestraint,
        BottomFlangeRestraint,
        WebRestraint,
        FullRestraint
    }

    public class SteelSection : SectionProperty
    {

        public SteelSection()
        {
        }

        /// <summary>
        /// Create a section property from a list of edges, shape type and material
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="sType"></param>
        /// <param name="mType"></param>
        public SteelSection(BHoM.Geometry.Group<Curve> edges, ShapeType sType) : this()
        {
            Edges = edges;
            Shape = sType;
            //SectionMaterial = mType;
        }     

        public double GetGrade()
        {
            return Material.TensileYieldStrength / 1000000;         
        }   

        public Fabrication Fabrication
        {
            get; set;
        }

        public PlateRestraint PlateRestraint
        {
            get;
            set;
        }

        public double Mass { get; set; }

        public double B1 { get; set; }

        public double B2 { get; set; }

        public double B3 { get; set; }

        public double Tw { get; set; }

        public double Tf1 { get; set; }

        public double Tf2 { get; set; }

        public double r1 { get; set; }

        public double r2 { get; set; }

        public double Spacing { get; set; }
    }
}
