using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Materials;
using System.ComponentModel;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Offsets for bars
    /// </summary>
    [Serializable]
    public class Offset : BH.oM.Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Axial Offset from start node")]
        public double StartX { get; set; } = 0;


        [Description("Minor axis offset from start node")]
        public double StartY { get; set; } = 0;

        [Description("Major axis offset from start node")]
        public double StartZ { get; set; } = 0;

        [Description("Axial Offset from end node")]
        public double EndX { get; set; } = 0;

        [Description("Minor axis offset from end node")]
        public double EndY { get; set; } = 0;

        [Description("Major axis offset from end node")]
        public double EndZ { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Offset() { }

        /***************************************************/

        public Offset(double startX, double startY, double startZ, double endX, double endY, double endZ)
        {
            StartX = startX;
            StartY = startY;
            StartZ = startZ;
            EndX = endX;
            EndY = endY;
            EndZ = endZ;
        }

    }
}
