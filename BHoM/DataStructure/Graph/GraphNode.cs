using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.DataStructure
{
    public class GraphNode<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public T Value { get; set; } = default(T);


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static implicit operator GraphNode<T>(T value)
        {
            return new GraphNode<T> { Value = value };
        }

        /***************************************************/
    }
}
