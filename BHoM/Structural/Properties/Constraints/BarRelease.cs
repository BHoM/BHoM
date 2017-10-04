using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Bar release applicable to bar objects, contains BH.oM.Structural.Constraint objects
    /// for the start and end of a bar
    /// </summary>
    public class BarRelease : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public NodeConstraint StartConstraint { get; set; }

        public NodeConstraint EndConstraint { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarRelease() { }

        /***************************************************/

        public BarRelease(NodeConstraint startConstraint, NodeConstraint endConstraint, string name = "")
        {
            StartConstraint = startConstraint;
            EndConstraint = endConstraint;
            Name = name;
        }
    }  
}
