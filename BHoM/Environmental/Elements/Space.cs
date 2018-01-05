﻿using BH.oM.Geometry;
using BH.oM.Base;
using BHE = BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;
namespace BH.oM.Environmental.Elements
{
    /// <summary>
    /// Space Objects
    /// </summary>
    public class Space : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Panel Panels { get; set; } = new Panel();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Space() { }

        public Space(Panel panels)
        {
            Panels = panels;
        }
    }

}