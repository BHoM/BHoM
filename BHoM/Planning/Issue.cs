using BH.oM.Base;
using System;
using System.Collections.Generic;

namespace BH.oM.Planning
{
    public class Issue : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Creator { get; set; }

        public List<string> Assignees { get; set; }

        public string Title { get; set; }

        public string RepoName { get; set; }

        public int Number { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public string MilestoneName { get; set; }

        public bool PullRequested { get; set; } = false;

        public List<string> Labels { get; set; } = new List<string>();


        /***************************************************/
    }
}
