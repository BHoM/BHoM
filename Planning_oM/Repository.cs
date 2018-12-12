using BH.oM.Base;

namespace BH.oM.Planning
{
    public class Repository : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int OpenIssues { get; set; } = 0;

        public int OpenPullRequests { get; set; } = 0;

        public int ClosedIssues { get; set; } = 0;

        public int ClosedPullRequests { get; set; } = 0;


        /***************************************************/
    }
}
