using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    public class Stream : IBHoMFragment, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string StreamName { get; }
        public string StreamId { get; }
        public int Revision { get; set; }

        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        [Description("Creates new Diffing Stream with automatically defined name and Id. . Id will be a GUID. Revision is initally 0.")]
        [Input("streamName", "If not specified, the name will be `UnnamedStream` followed by UTC")]
        [Input("streamId", "If not specified, streamId will be a GUID.Revision is initally 0.")]
        [Input("revision", "If not specified, revision is initially set to 0.")]
        public Stream(string streamName = null, string streamId = null, int revision = 0)
        {
            StreamName = String.IsNullOrWhiteSpace(streamName) ? "UnnamedStream-createdOn" + DateTime.Now.ToString() + "localTime" : StreamName;
            StreamId = string.IsNullOrWhiteSpace(StreamId) ? Guid.NewGuid().ToString("N") : StreamId;
            Revision = 0;
        }

        /***************************************************/


        /***************************************************/
        /**** IBHoMFragment stuff (not needed)          ****/
        /***************************************************/

        public Guid BHoM_Guid { get; set; } = default(Guid);

        public string Name { get; set; } = null;

        public List<IBHoMFragment> Fragments { get; set; } = null;

        public HashSet<string> Tags { get; set; } = null;

        public Dictionary<string, object> CustomData { get; set; } = null;

        public IBHoMObject GetShallowClone(bool newGuid = false)
        {
            return null;
        }

        /***************************************************/
    }
}
