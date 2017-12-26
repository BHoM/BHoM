using System.Collections.Generic;

namespace BH.oM.DataStructure
{
    public class PointMatrix<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double CellSize { get; set; } = 1.0;

        public Dictionary<DiscreetPoint, List<LocalData<T>>> Data { get; set; } = new Dictionary<DiscreetPoint, List<LocalData<T>>>();


        /***************************************************/
    }
}
