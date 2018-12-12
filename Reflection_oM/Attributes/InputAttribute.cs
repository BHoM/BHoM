using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Name { get; private set; } = "";

        public string Description { get; private set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public InputAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }


        /***************************************************/
    }
}
