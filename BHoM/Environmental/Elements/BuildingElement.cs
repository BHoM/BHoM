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
    /// BuildingElement object for environmental models.
    /// </summary>
    public class BuildingElement : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int BEType { get; set; } = 0;
        public int Ghost { get; set; } = 0;
        public int Ground { get; set; } = 0;
        public int MarkDelete { get; set; } = 0;
        public double Width { get; set; } = 0.0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BuildingElement() { }

        /***************************************************/

        public BuildingElement(int beType, int ghost, int ground, int markDelete, double width)
        {
            BEType = beType;
            Ghost = ghost;
            Ground = ground;
            MarkDelete = markDelete;
            Width = width;

        }

    }

}
