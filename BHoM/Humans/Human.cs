using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Humans
{
    public class Human : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IHumanRole> Roles { get; set; } = new List<IHumanRole>();


        public string Company { get; set; }  // TODO: Move all those relevant to an Employee : IHumanRole class

        public string Office { get; set; }

        public string Discipline { get; set; }

        public string Team { get; set; }

        public string Grade { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        //public string YammerLogin { get; set; }

        //public string GitHubLogin { get; set; }


        public Skeleton Skeleton { get; set; }

        public string CodeDevelopmentRole { get; set; } 

        public string BusinessUnit { get; set; }


        /***************************************************/
    }

    // Todo: Move this to its own file when the BHoM is available for PR 
    public interface IHumanRole : IObject { }

    /***************************************************/

    public class Employee : IHumanRole
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

        /***************************************************/
    }

}



