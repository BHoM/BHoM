﻿using System.Collections.Generic;
using BH.oM.Structural.Properties;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BH.oM panel class - a planar surface object with a list of 'edges' (curves with properties) for both external and internal edges (openings)
    /// </summary>
    public class PanelPlanar : Base.BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Edge> ExternalEdges = new List<Edge>();

        public List<Opening> Openings = new List<Opening>();

        public Property2D Property { get; set; } = new ConstantThickness();      


        /***************************************************/ 
    }
}
       