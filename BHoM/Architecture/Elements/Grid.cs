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
    public class Grid : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Grid() { }

        /***************************************************/

        public Grid(ICurve curve)
        {
            List<ICurve> curves = new List<Geometry.ICurve>();
            curves.Add(curve);
            this.Curves = curves;
        }

        public Grid(List<ICurve> curves)
        {
            this.Curves = curves;
        }

    }
}
