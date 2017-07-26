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
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DOFType UX { get; set; }

        public DOFType UY { get; set; }

        public DOFType Normal { get; set; }

        public double KX { get; set; } = 0;

        public double KY { get; set; } = 0;

        public double KNorm { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SurfaceConstraint(string name = "") 
        {
            Name = name;
        }
    }
}
