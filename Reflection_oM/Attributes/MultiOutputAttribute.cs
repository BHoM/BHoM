using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MultiOutputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int Index { get; private set; } = 0;

        public string Name { get; private set; } = "";

        public string Description { get; private set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MultiOutputAttribute(int index, string name, string description)
        {
            Index = index;
            Name = name;
            Description = description;
        }


        /***************************************************/
    }
}
