using BH.oM.Base;

namespace BH.oM.Structure.Properties.Constraint
{
    /// <summary>
    /// Bar release applicable to bar objects, contains BH.oM.Structure.Constraint objects
    /// for the start and end of a bar
    /// </summary>
    public class BarRelease : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Constraint6DOF StartRelease { get; set; }

        public Constraint6DOF EndRelease { get; set; }


        /***************************************************/
    }  
}
