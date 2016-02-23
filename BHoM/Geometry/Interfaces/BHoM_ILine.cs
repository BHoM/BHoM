using System;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Line interface
    /// </summary>
    public interface ILine 
    {
        /// <summary>Start point as BHoM point</summary>
        Point StartPoint { get; set; }

        /// <summary>End point as BHoM point</summary>
        Point EndPoint { get; set; }

        /// <summary>Length of the line</summary>
        double Length { get; set; }
    }
}