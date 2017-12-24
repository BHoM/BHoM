using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /**** Constructors                              ****/
        /***************************************************/

        public Tree() { }

        /***************************************************/

        public Tree(T value, string name = "")
        {
            Value = value;
            Name = name;
        }

        /***************************************************/

        public Tree(Dictionary<string, Tree<T>> children, string name = "")
        {
            Children = children;
            Name = name;
        }
    }
}
