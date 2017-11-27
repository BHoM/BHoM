using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    public class Constraint4DOF : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DOFType TranslationX { get; set; }

        public DOFType TranslationY { get; set; }

        public DOFType TranslationZ { get; set; }

        public DOFType RotationX { get; set; }

        public double TranslationalStiffnessX { get; set; }

        public double TranslationalStiffnessY { get; set; }

        public double TranslationalStiffnessZ { get; set; }

        public double RotationalStiffnessX { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Constraint4DOF(string name = "") 
        {
            Name = name;
        }
    }

}
