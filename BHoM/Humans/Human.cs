using BH.oM.Base;

namespace BH.oM.Humans
{
    public class Human : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Office { get; set; }

        public string Discipline { get; set; }

        public string Team { get; set; }

        public string Grade { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string YammerLogin { get; set; }

        public string GitHubLogin { get; set; }

        public Skeleton Skeleton { get; set; }

        public string CodeDevelopmentRole { get; set; }

        public string BusinessUnit { get; set; }


        /***************************************************/
    }
}
