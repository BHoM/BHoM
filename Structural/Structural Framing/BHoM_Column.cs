using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// Column class, can be used as a wrapper for an analytical bar object
    /// </summary>
    public class Column
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; private set; }

        /// <summary>
        /// Bar objects which make up the column, if only one entry then column
        /// consists of only one bar
        /// </summary>
        public List<BHoM.Structural.Bar> Bars { get; private set; }

        /// <summary>Beam start point</summary>
        public BHoM.Geometry.Point StartPoint { get; private set; }
        /// <summary>Beam end point</summary>
        public BHoM.Geometry.Point EndPoint { get; private set; }

        /// <summary>Level for vertical reference</summary>
        public string LevelName { get; private set; }

        /// <summary>Offset of the beam start point from the reference level</summary>
        public double StartOffset { get; private set; }
    }
}