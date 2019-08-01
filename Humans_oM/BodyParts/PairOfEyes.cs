using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Humans.Interfaces;

namespace BH.oM.Humans.BodyParts
{
    public class PairOfEyes : IPointBodyPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point TrackingPoint { get; set; } = new Point();

        public Eye LeftEye { get; set; } = new Eye();

        public Eye RightEye { get; set; } = new Eye();

        public Point ReferenceLocation { get; set; } = new Point();

        public Vector ViewDirection { get; set; } = new Vector();
    }
}
