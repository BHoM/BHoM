using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    public class DiffProjFragment : IBHoMFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ProjectName { get; private set; }
        public string ProjectId { get; private set; }
        public int Revision { get; set; } = 0;

        /***************************************************/

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/
        [Description("Creates new Diffing Project with automatically defined name and Id. The name will be `UnnamedProject` followed by UTC. Id will be a GUID. Revision is initally 0.")]
        public DiffProjFragment()
        {
            ProjectName = String.IsNullOrWhiteSpace(ProjectName) ? "UnnamedProject-createdOn" + DateTime.Now.ToString() + "localTime" : ProjectName;
        }

        [Description("Creates new Diffing Project with a GUID for its Id. Revision is initally 0.")]
        public DiffProjFragment(string projectName)
        {
            ProjectName = projectName;
            ProjectId = string.IsNullOrWhiteSpace(ProjectId) ? Guid.NewGuid().ToString("N") : ProjectId;
        }

        [Description("Creates new Diffing Project. Revision is initally 0.")]
        public DiffProjFragment(string projectName, string projectId)
            : this(projectName)
        {
            ProjectId = projectId;
        }

        /***************************************************/


        /***************************************************/
        /**** IBHoMFragment stuff (not needed)          ****/
        /***************************************************/

        public Guid BHoM_Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = "";

        public List<IBHoMFragment> Fragments { get; set; } = new List<IBHoMFragment>();

        public HashSet<string> Tags { get; set; } = new HashSet<string>();

        public Dictionary<string, object> CustomData { get; set; } = new Dictionary<string, object>();

        public IBHoMObject GetShallowClone(bool newGuid = false)
        {
            return null;
        }

        /***************************************************/
    }
}
