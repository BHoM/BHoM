using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHoM.Structural.Constraints
{
    /// <summary>
    /// Bar release applicable to bar objects, contains BHoM.Structural.Constraint objects
    /// for the start and end of a bar
    /// </summary>
    public class BarRelease 
    {
        /// <summary>Bar release name</summary>
        public string Name { get; private set; }

        /// <summary>Start constraint</summary>
        public BHoM.Structural.Constraints.Constraint StartConstraint { get; private set; }

        /// <summary>End constraint</summary>
        public BHoM.Structural.Constraints.Constraint EndConstraint { get; private set; }

        /// <summary>Construct a new constraint using constraint objects for start/end releases</summary>
        public BarRelease(BHoM.Structural.Constraints.Constraint startConstraint, BHoM.Structural.Constraints.Constraint endConstraint)
        {
            this.StartConstraint = startConstraint;
            this.EndConstraint = endConstraint;
            this.Name = startConstraint.Name + "-" + endConstraint.Name;
        }

        /// <summary>Construct a new constraint using constraint objects for start/end releases and name</summary>          
        public BarRelease(BHoM.Structural.Constraints.Constraint startConstraint, BHoM.Structural.Constraints.Constraint endConstraint, string name)
        {
            this.StartConstraint = startConstraint;
            this.EndConstraint = endConstraint;
            this.Name = name;
        }


    }

  
}
