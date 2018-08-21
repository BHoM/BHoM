using BH.oM.Base;

namespace BH.oM.Structure.Loads
{
    /// <summary>
    /// Interface implemented by all loading related classes
    /// </summary>
    public interface ILoad : IBHoMObject        
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        Loadcase Loadcase { get; set; }

        LoadAxis Axis { get; set; }

        bool Projected { get; set; }


        /***************************************************/
    }
}
