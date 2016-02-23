using System.Collections.Generic;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM IVector interface
    /// </summary>
    public interface IVector
    {
        /// <summary>X coordinate</summary>
        double X { get; set; }

        /// <summary>Y coordinate</summary>
        double Y { get; set; }

        /// <summary>Z coordinate</summary>
        double Z { get; set; }
    }
}
