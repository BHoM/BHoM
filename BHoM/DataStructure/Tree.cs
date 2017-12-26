using System.Collections.Generic;

namespace BH.oM.DataStructure
{
    [Serializable]
    public class Tree<T>
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
