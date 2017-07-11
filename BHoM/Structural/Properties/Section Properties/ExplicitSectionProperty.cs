using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    public class ExplicitSectionProperty : SectionProperty
    {
        public ExplicitSectionProperty()
        { }


        protected string GenerateStandardName()
        {
            return "Explicit";
        }

        //Overrides the calculate section property method to not update varables when getters are called
    }
}
