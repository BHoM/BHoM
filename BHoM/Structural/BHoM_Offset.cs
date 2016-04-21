using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Materials; 

namespace BHoM.Structural
{
    /// <summary>
    /// Offsets for bars
    /// </summary>
    [Serializable]
    public class Offset
    {
        /// <summary>Offset name</summary>
        public string Name { get; private set; }
        /// <summary>Offset array</summary>
        public double[] Offsets { get; private set; }

        /// <summary>
        /// Construct an offset by values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="xx"></param>
        /// <param name="yy"></param>
        /// <param name="zz"></param>
        public Offset(double x, double y, double z, double xx, double yy, double zz)
        {
            this.Offsets = new double[6] { x, y, z, xx, yy, zz };
        }

        /// <summary>
        /// Set the offset name
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.Name = name;
        }
     }
}
