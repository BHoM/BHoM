using BH.oM.Geometry;

namespace BH.oM.DataStructure
{
    public class LocalData<T> 
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Position { get; set; } = new Point();

        public T Data { get; set; } = default(T);


        /***************************************************/
    }
}
