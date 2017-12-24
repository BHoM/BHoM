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
    [Serializable]
    public class BarRelease : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Constraint6DOF StartRelease { get; set; }

        public Constraint6DOF EndRelease { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarRelease() { }

        /***************************************************/

        public BarRelease(Constraint6DOF startConstraint, Constraint6DOF endConstraint, string name = "")
        {
            StartRelease = startConstraint;
            EndRelease = endConstraint;
            Name = name;
        }
    }
}
