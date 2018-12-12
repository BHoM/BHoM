using BH.oM.Base;

namespace BH.oM.Structure.Properties.Constraint
{
    public class Constraint4DOF : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DOFType TranslationX { get; set; } = DOFType.Free;

        public DOFType TranslationY { get; set; } = DOFType.Free;

        public DOFType TranslationZ { get; set; } = DOFType.Free;

        public DOFType RotationX { get; set; } = DOFType.Free;

        public double TranslationalStiffnessX { get; set; } = 0;

        public double TranslationalStiffnessY { get; set; } = 0;

        public double TranslationalStiffnessZ { get; set; } = 0;

        public double RotationalStiffnessX { get; set; } = 0;


        /***************************************************/
    }

}
