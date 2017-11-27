﻿using BH.oM.Geometry;
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
    public class Panel : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Polyline Edges { get; set; } = new Polyline();
        public List<Opening> Openings { get; set; } = new List<Opening>();
       

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Panel() { }

        /***************************************************/

               
    }
}
