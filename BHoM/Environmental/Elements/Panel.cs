using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Elements
{
    /// <summary>
    /// PanelPlanar object for environmental models.
    /// </summary>
    [Serializable]
    public class Panel : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Type { get; set; }

        public ISurface Geometry { get; set; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Panel() { }

        /***************************************************/

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(ISurface surface)
        {
            Geometry = surface;
        }
    }
}


///***************************************************/
///**** Override BHoMObject                       ****/
///***************************************************/

///// <summary></summary>
//public override IBHoMGeometry GetGeometry()
//{
//    return Geometry;
//}

///***************************************************/

///// <summary></summary>
//public override void SetGeometry(IBHoMGeometry geometry)
//{
//    if (typeof(ISurface).IsAssignableFrom(geometry.GetType()))
//    {
//        Geometry = geometry as ISurface;
//    }
//}