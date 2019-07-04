using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Humans.Interfaces;

namespace BH.oM.Humans.BodyParts
{
    public class Eye : IPointBodyPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point TrackingPoint { get; set; } = new Point();

        public Point Location { get; set; } = new Point();

        public Vector ViewDirection { get; set; } = new Vector();

        /***************************************************/
    }
}
