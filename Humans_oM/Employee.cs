using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Humans
{
    public class Employee : BHoMObject, IHumanRole
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Company { get; set; }  

        public string Office { get; set; }

        public string Discipline { get; set; }

        public string Team { get; set; }

        public string Grade { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CodeDevelopmentRole { get; set; }

        public string BusinessUnit { get; set; }

        /***************************************************/
    }

}



