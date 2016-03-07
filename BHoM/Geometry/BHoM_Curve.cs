using System;

namespace BHoM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    [Serializable]
    public abstract class Curve : Global.BHoMObject
    {
        /// <summary>Start point as BHoM curve</summary>
        public abstract Point StartPoint { get; set; }

        /// <summary>End point as BHoM curve</summary>
        public abstract Point EndPoint { get; set; }
    }
}