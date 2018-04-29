using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Output : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; private set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Output(string description)
        {
            Description = description;
        }


        /***************************************************/
    }
}
