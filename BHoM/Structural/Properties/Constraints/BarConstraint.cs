using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public class BarConstraint : BHoMObject
    {
        public DOF Horizontal { get; set; }

        public DOF Vertical { get; set; }

        public DOF Axial { get; set; }

        public DOF Rotational { get; set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        internal BarConstraint()
        {
            Horizontal = new DOF();
            Vertical = new DOF();
            Axial = new DOF();
            Rotational = new DOF();
        }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public BarConstraint(string name) : this()
        {
            this.Name = name;
        }
    }

}
