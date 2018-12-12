using BH.oM.Base;
using System;
using System.Collections.Generic;

namespace BH.oM.Planning
{
    public class PullRequest : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Creator { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string HtmlUrl { get; set; }

        public string RepoName { get; set; }

        public string BranchName { get; set; }

        public int Number { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public string MilestoneName { get; set; }

        public int Additions { get; set; }

        public int Deletions { get; set; }

        public List<string> Reviewers { get; set; } = new List<string>();


        /***************************************************/
    }
}
