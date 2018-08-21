using BH.oM.Geometry;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Offsets for bars
    /// </summary>
    public class Offset : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector Start { get; set; } = new Vector();

        public Vector End { get; set; } = new Vector();

        /***************************************************/
    }
}
