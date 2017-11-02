﻿using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Architecture.Elements
{
    /// <summary>
    /// 
    /// </summary>
    public class Grid : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Grid() { }

        /***************************************************/

        public Grid(ICurve curve)
        {
            Curves.Add(curve);
        }

        public Grid(List<ICurve> curves)
        {
            this.Curves = curves;
        }

    }
}
