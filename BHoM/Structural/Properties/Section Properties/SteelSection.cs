using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structural.Properties
{

    // TODO: Things that probably need to be taken elsewhere ?
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
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Fabrication Fabrication { get; set; }

        public PlateRestraint PlateRestraint { get; set; }

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


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SteelSection() { }

        /***************************************************/

        /// <summary>
        /// Create a section property from a list of edges, shape type and material
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="sType"></param>
        /// <param name="mType"></param>
        public SteelSection(List<ICurve> edges, ShapeType sType)
        {
            Edges = edges;
            Shape = sType;
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        public double GetGrade()
        {
            return Material.TensileYieldStrength / 1000000;         
        }   

        
    }
}
