using System.Collections.Generic;

namespace BH.oM.DataStructure
{
    public class Tree<T> : IDataStructure
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Dictionary<string, Tree<T>> Children { get; set; } = new Dictionary<string, Tree<T>>();

        public string Name { get; set; } = "";

        public T Value { get; set; } = default(T);


        /***************************************************/
    }
}
