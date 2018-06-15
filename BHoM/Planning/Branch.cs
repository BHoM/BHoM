using BH.oM.Base;
using System;
using System.Collections.Generic;

namespace BH.oM.Planning
{
    public class Branch : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string LastPusher { get; set; }

        public string Title { get; set; }

        public string RepoName { get; set; }

        public bool Protected { get; set; }

        public DateTimeOffset LastCommitDate { get; set; }


        /***************************************************/
    }
}
