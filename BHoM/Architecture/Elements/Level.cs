using BH.oM.Geometry;
using BH.oM.Base;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Architecture
{
    /// <summary>
    /// 
    /// </summary>
    public class Level : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Elevation { get; set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Level(double elevation)
        {
            this.Elevation = elevation;
        }

        /***************************************************/

    }
}
