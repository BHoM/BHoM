﻿using BHG = BHoM.Geometry;
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
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Space : BHB.BHoMObject
    {
        /////////////////
        ////Properties///
        /////////////////

        public List<BHoM.Geometry.Polyline> Polylines
        {
            get;
            set;
        }
    }

}