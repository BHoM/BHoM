
using BH.oM.Base;

namespace BH.oM.SecurityTechnology.Elements.Security
{
    /// <summary>
    /// DataDevice object for Data Devices connectivity
    /// </summary>
    class DataDevice : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ElectricalPanel { get; set; }

        public string DataType { get; set; }

        public int DataCount { get; set; }

    }
}
