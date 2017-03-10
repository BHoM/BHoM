using BHoM.Geometry;
using BHB = BHoM.Base;
using BHE = BHoM.Environmental.Elements;
using System;
using System.Reflection;
using BHoM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BHoM.Environmental.Elements
{
    /// <summary>
    /// Panel object for environmental models.
    /// </summary>
    public class Panel : BHB.BHoMObject
    {

        /////////////////
        ////Properties///
        /////////////////

        private Brep m_Panel;

        public string Type { get; set; }

        public Brep Geometry
        {
            get; set;
        }

        public bool IsValid() { return Geometry != null; }


        ////////////////////
        ////CONSTRUCTORS////
        ////////////////////

        public Panel()
        {
           
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(Surface surface)
        {
            Geometry = surface;
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(Brep boundary)
        {
            Geometry = boundary;
        }

        ///////////////
        ////METHODS////
        ///////////////

        /// <summary></summary>
        public override BHoM.Geometry.BHoMGeometry GetGeometry()
        {
            return Geometry;
        }

        /// <summary></summary>
        public void SetGeometry(BHoMGeometry geometry)
        {
            if (typeof(Brep).IsAssignableFrom(geometry.GetType()))
            {
                Geometry = geometry as Brep;
            }
        }
    }
}