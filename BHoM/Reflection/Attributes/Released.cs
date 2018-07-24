using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class Released : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; private set; } = "";

        public string FromVersion { get; private set; } = "1.0.0.0";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Released(string fromVersion, string description = "")
        {
            Description = description;
            FromVersion = fromVersion;
        }


        /***************************************************/
    }
}
