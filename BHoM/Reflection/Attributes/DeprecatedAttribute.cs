using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class DeprecatedAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; private set; } = "";

        public string FromVersion { get; private set; } = "1.0.0.0";

        public Type ReplacingType { get; private set; } = null;

        public string ReplacingMethod { get; private set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public DeprecatedAttribute(string fromVersion, string description = "", Type newType = null, string newMethod = "")
        {
            Description = description;
            FromVersion = fromVersion;
            ReplacingType = newType;
            ReplacingMethod = newMethod;
        }



        /***************************************************/
    }
}
