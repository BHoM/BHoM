using System.Collections.Generic;

namespace BHoM.Geometry 
{
    /// <summary>
    /// BHoM IPlane interface
    /// </summary>
     public interface IPlane
    {
        /// <summary>X vector</summary>
        Vector X { get; set; }
        /// <summary>Y vector</summary>
        Vector Y { get; set; }
        /// <summary>Z vector</summary>
        Vector Z { get; set; }

        /// <summary>Origin point</summary>
        Point Origin { get; set; }
    }
}
