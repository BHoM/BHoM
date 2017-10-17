using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    public class BarConstraint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DOFType UX { get; set; }

        public DOFType UY { get; set; }

        public DOFType UZ { get; set; }

        public DOFType RX { get; set; }

        public double KX { get; set; }

        public double KY { get; set; }

        public double KZ { get; set; }

        public double HX { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarConstraint(string name = "") 
        {
            Name = name;
        }
    }

}
