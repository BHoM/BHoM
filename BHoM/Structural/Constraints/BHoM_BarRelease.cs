using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHoM.Structural
{
    /// <summary>
    /// Bar release applicable to bar objects, contains BHoM.Structural.Constraint objects
    /// for the start and end of a bar
    /// </summary>
    public class BarRelease : BHoM.Global.BHoMObject
    {
        /// <summary>Start constraint</summary>
        public BHoM.Structural.Constraint StartConstraint 
        {
            get
            {
                return Project.GetObject(Parameters.LookUp<Guid>(Global.Param.StartConstraint)) as Constraint;
            }
            set
            {
                Parameters.AddItem<Guid>(Global.Param.Constraint, value.BHoM_Guid);
            }
        }

        /// <summary>End constraint</summary>
        public BHoM.Structural.Constraint EndConstraint
        {
            get
            {
                return Project.GetObject(Parameters.LookUp<Guid>(Global.Param.EndConstraint)) as Constraint;
            }
            set
            {
                Parameters.AddItem<Guid>(Global.Param.Constraint, value.BHoM_Guid);
            }
        }

        /// <summary>Construct a new constraint using constraint objects for start/end releases</summary>
        public BarRelease(BHoM.Structural.Constraint startConstraint, BHoM.Structural.Constraint endConstraint)
        {
            this.StartConstraint = startConstraint;
            this.EndConstraint = endConstraint;
            this.Name = startConstraint.Name + "-" + endConstraint.Name;
        }

        /// <summary>Construct a new constraint using constraint objects for start/end releases and name</summary>          
        public BarRelease(BHoM.Structural.Constraint startConstraint, BHoM.Structural.Constraint endConstraint, string name)
        {
            this.StartConstraint = startConstraint;
            this.EndConstraint = endConstraint;
            this.Name = name;
        }
    }  
}
