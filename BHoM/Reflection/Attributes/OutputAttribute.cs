using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OutputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Name { get; private set; } = "";

        public string Description { get; private set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public OutputAttribute(string description)
        {
            Description = description;
        }

        /***************************************************/

        public OutputAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }


        /***************************************************/
    }
}
