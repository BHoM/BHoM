using BH.oM.Base;

namespace BH.oM.Structure.Properties
{
    public class Constraint3DOF : BHoMObject
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
    }
}
