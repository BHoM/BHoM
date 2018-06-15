using System;
using BH.oM.Base;

namespace BH.oM.Planning
{
    public class Commit : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string RepoName { get; set; }

        public DateTimeOffset Date { get; set; }


        /***************************************************/

    }
}
