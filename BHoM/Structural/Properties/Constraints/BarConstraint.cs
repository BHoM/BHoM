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
        public DOFType UX { get; set; }

        public DOFType UY { get; set; }

        public DOFType UZ { get; set; }

        public DOFType RX { get; set; }

        public double KX { get; set; }

        public double KY { get; set; }

        public double KZ { get; set; }

        public double HX { get; set; }
        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        internal BarConstraint()
        { 
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
