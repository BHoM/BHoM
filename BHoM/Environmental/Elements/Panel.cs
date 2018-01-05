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
        public double Area { get; set; } = 0.0;
        public string Type { get; set; } = "";
        
                       

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Panel() { }

        /***************************************************/

        public Panel(Polyline edges, List<Opening> openings, double area, string type)
        {
            Edges = edges;
            Openings = openings;
            Area = area;
            Type = type;
            
        }

    }
               
}
