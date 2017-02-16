using BHG = BHoM.Geometry;
using BHB = BHoM.Base;
using System;
using System.Reflection;
using BHoM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BHoM.Environmental.Elements
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Panel : BHB.BHoMObject
    {
        /////////////////
        ////Properties///
        /////////////////


        public List<BHoM.Geometry.Line> Lines
        {
            get; set;
        }

    }

}