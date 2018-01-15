using BH.oM.Geometry;
using BH.oM.Base;
using BHE = BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;
namespace BH.oM.Environmental.Elements_Legacy
{
    /// <summary>
    /// Space Objects
    /// </summary>
    public class Space : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Polyline> Contours { get; set; } = new List<Polyline>();

        public Panel Panels { get; set; } = new Panel();
       

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Space() { }

        public Space(Panel panels)
        {
            Panels = panels;
        }
    }

}