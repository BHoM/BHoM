using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public class SurfaceConstraint : BHoMObject
    {
        /////////////////
        ////Properties///
        /////////////////

        public DOF UX { get; set; }

        public DOF UY { get; set; }

        public DOF Normal { get; set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        internal SurfaceConstraint()
        {
            UX = new DOF();
            UY = new DOF();
            Normal = new DOF();
        }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public SurfaceConstraint(string name) : this()
        {
            this.Name = name;
        }
    }
}
