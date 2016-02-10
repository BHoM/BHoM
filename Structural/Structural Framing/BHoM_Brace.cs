using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// Brace class, can be used as a wrapper for an analytical bar object
    /// </summary>
    public class Brace
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; private set; }

        /// <summary>
        /// Bar objects which make up the brace, if only one entry then brace
        /// consists of only one bar
        /// </summary>
        public List<BHoM.Structural.Bar> Bars { get; private set; }

        /// <summary>Beam start point</summary>
        public BHoM.Geometry.Point StartPoint { get; private set; }
        /// <summary>Beam end point</summary>
        public BHoM.Geometry.Point EndPoint { get; private set; }

        /// <summary>Level for vertical reference</summary>
        public string LevelName { get; private set; }

        /// <summary>
        /// Sets the name of the beam reference level
        /// </summary>
        /// <param name="levelName"></param>
        public void SetLevel(string levelName)
        {
            this.LevelName = levelName;
        }
    }
}