using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    public class EdgeConstraint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DOFType TranslationX { get; set; }

        public DOFType TranslationY { get; set; }

        public DOFType TranslationZ { get; set; }

        public DOFType RotationX { get; set; }

        public DOFType RotationY { get; set; }

        public DOFType RotationZ { get; set; }

        public double StiffnessX { get; set; }

        public double StiffnessY { get; set; }

        public double StiffnessZ { get; set; }

        public double RotationalStiffnessX { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public EdgeConstraint(string name = "") 
        {
            Name = name;
        }
    }

}
