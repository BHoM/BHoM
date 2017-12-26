﻿namespace BH.oM.DataStructure
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
