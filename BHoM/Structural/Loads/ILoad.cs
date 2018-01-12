using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Interface implemented by all loading related classes
    /// </summary>
    public interface ILoad : IObject        
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
