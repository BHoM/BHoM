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
		
		public string Author { get; set; }
		
		public string Committer { get; set; }

        public int Additions { get; set; }

        public int Deletions { get; set; }

        public int TotalChanges { get; set; }


        /***************************************************/

    }
}
