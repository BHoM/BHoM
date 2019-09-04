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
    public class Stream : BHoMObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string StreamId { get; } // Generally a GUID
        public string Revision { get; } // Perhaps this can become just a "revisionName" or "comment", like Github's Summary. After all, Revision can be given by Timestam+Author info
        public long Timestamp { get; }
        public string Author { get; }

        public IEnumerable<IBHoMObject> Objects { get; }

        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        [Description("Creates new Diffing Stream")]
        [Input("objects", "Objects to be included in the Stream")]
        [Input("streamName", "If not specified, the name will be `UnnamedStream` followed by UTC")]
        [Input("streamId", "If not specified, streamId will be a GUID.Revision is initally 0")]
        [Input("revision", "If not specified, revision is initially set to 0")]
        public Stream(IEnumerable<IBHoMObject> objects, string streamId = null, string revision = null)
        {
            Objects = objects;

            StreamId = string.IsNullOrWhiteSpace(streamId) ? Guid.NewGuid().ToString("N") : StreamId;
            Revision = revision;

            Timestamp = DateTime.UtcNow.Ticks;
            Author = Environment.UserDomainName + "/" + Environment.UserName;
        }

        /***************************************************/
    }
}
