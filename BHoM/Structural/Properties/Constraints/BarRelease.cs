using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BHoM.Base;

namespace BHoM.Structural.Properties
{
    /// <summary>
    /// Bar release applicable to bar objects, contains BHoM.Structural.Constraint objects
    /// for the start and end of a bar
    /// </summary>
    public class BarRelease : BHoMObject
    {
        /// <summary>Start constraint</summary>
        public NodeConstraint StartConstraint 
        {
            get;
            set;
        }

        /// <summary>End constraint</summary>
        public NodeConstraint EndConstraint
        {
            get;
            set;
        }

        internal BarRelease() { }

        /// <summary>Construct a new constraint using constraint objects for start/end releases</summary>
        public BarRelease(NodeConstraint startConstraint, NodeConstraint endConstraint)
        {
            this.StartConstraint = startConstraint;
            this.EndConstraint = endConstraint;
            this.Name = startConstraint.Name + "-" + endConstraint.Name;
        }

        /// <summary>Construct a new constraint using constraint objects for start/end releases and name</summary>          
        public BarRelease(NodeConstraint startConstraint, NodeConstraint endConstraint, string name)
        {
            this.StartConstraint = startConstraint;
            this.EndConstraint = endConstraint;
            this.Name = name;
        }
    }  
}
