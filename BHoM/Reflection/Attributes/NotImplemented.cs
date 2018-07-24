using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NotImplemented : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; private set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NotImplemented(string description = "")
        {
            Description = description;
        }


        /***************************************************/
    }
}
