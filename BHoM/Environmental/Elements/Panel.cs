using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;
using BHE = BH.oM.Environmental;
using BHEP = BH.oM.Environmental.Properties;

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
        public BHEP.SurfaceDataProperties SurfaceData { get; set; } = new BHEP.SurfaceDataProperties();
        public BHE.Elements.BuildingElement BuildingElements { get; set; } = new BHE.Elements.BuildingElement();
        public BHEP.CFDProperties CDFProperties { get; set; } = new BHEP.CFDProperties();
        
                       

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Panel() { }

        /***************************************************/

        public Panel(Polyline edges, List<Opening> openings, string type, BHEP.SurfaceDataProperties surfaceData, BHE.Elements.BuildingElement buildingElements, BHEP.CFDProperties cdfProperties)
        {
            Edges = edges;
            Openings = openings;
            SurfaceData = surfaceData;
            BuildingElements = buildingElements;
            CDFProperties = cdfProperties;
            
        }

    }
               
}
