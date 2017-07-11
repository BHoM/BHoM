using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    public class SurfaceConstraint : BHoMObject
    {
        /////////////////
        ////Properties///
        /////////////////

        public DOFType UX { get; set; }

        public DOFType UY { get; set; }

        public DOFType Normal { get; set; }

        public double KX { get; set; }

        public double KY { get; set; }

        public double KNorm { get; set; }


        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        internal SurfaceConstraint()
        {           
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
