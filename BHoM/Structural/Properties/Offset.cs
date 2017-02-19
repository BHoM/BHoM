using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Materials;
using System.ComponentModel;

namespace BHoM.Structural.Properties
{
    /// <summary>
    /// Offsets for bars
    /// </summary>
    [Serializable]
    public class Offset : BHoM.Base.BHoMObject
    {
        /// <summary>Offset name</summary>
        public string Name { get; private set; }
        /// <summary>Offset array</summary>
        public double[] Offsets { get; private set; }

        /// <summary>
        /// Construct an offset by values
        /// </summary>
        /// <param name="xi">Axial Offset at start node</param>
        /// <param name="yi">Minor Axis Offset as start node</param>
        /// <param name="zi">Major Axis Offset as start node</param>
        /// <param name="xj">Axial Offset at end node</param>
        /// <param name="yj">Minor Axis Offset as end node</param>
        /// <param name="zj">Major Axis Offset as end node</param>
        public Offset(double xi, double yi, double zi, double xj, double yj, double zj)
        {
            this.Offsets = new double[] { xi, yi, zi, xj, yj, zj };
        }

        public Offset()
        {
            Offsets = new double[6];
        }

        [DisplayName("StartX")]
        [Description("Axial Offset from start node")]
        [DefaultValue(0)]
        public double StartX
        {
            get
            {
                return Offsets[0];
            }
            set
            {
                Offsets[0] = value;
            }
        }
        [DisplayName("StartY")]
        [Description("Minor axis offset from start node")]
        [DefaultValue(0)]
        public double StartY
        {
            get
            {
                return Offsets[1];
            }
            set
            {
                Offsets[1] = value;
            }
        }

        [DisplayName("StartZ")]
        [Description("Major axis offset from start node")]
        [DefaultValue(0)]
        public double StartZ
        {
            get
            {
                return Offsets[2];
            }
            set
            {
                Offsets[2] = value;
            }
        }

        [DisplayName("EndX")]
        [Description("Axial Offset from end node")]
        [DefaultValue(0)]
        public double EndX
        {
            get
            {
                return Offsets[3];
            }
            set
            {
                Offsets[3] = value;
            }
        }
        [DisplayName("EndY")]
        [Description("Minor axis offset from end node")]
        [DefaultValue(0)]
        public double EndY
        {
            get
            {
                return Offsets[4];
            }
            set
            {
                Offsets[4] = value;
            }
        }

        [DisplayName("EndZ")]
        [Description("Major axis offset from end node")]
        [DefaultValue(0)]
        public double EndZ
        {
            get
            {
                return Offsets[5];
            }
            set
            {
                Offsets[5] = value;
            }
        }
    }
}
