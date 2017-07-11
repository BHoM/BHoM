//using System.Collections.Generic;

//namespace BH.oM.Structural.Elements
//{
//    /// <summary>
//    /// Beam class, can be used as a wrapper for an analytical bar object
//    /// </summary>
//    public class Beam 
//    {
//        /// <summary>BHoM unique ID</summary>
//        public System.Guid BHoM_Guid { get; private set; }

//        /// <summary>
//        /// Bar objects which make up the beam, if only one entry then beam
//        /// consists of only one bar
//        /// </summary>
//        public List<Bar> Bars { get; private set; }

//        /// <summary>Beam start point</summary>
//        public BH.oM.Geometry.Point StartPoint { get; private set; }
//        /// <summary>Beam end point</summary>
//        public BH.oM.Geometry.Point EndPoint { get; private set; }

//        /// <summary>Level for vertical reference</summary>
//        public string LevelName { get; private set; }

//        /// <summary>Offset of the beam start point from the reference level</summary>
//        public double StartOffset { get; private set; }

//        /// <summary>Offset of the beam end point from the reference level</summary>
//        public double EndOffset { get; private set; }

//        /// <summary>
//        /// Constructs a beam object from a bar object, if data is missing this can be
//        /// set separately
//        /// </summary>
//        /// <param name="bar"></param>
//        public Beam(Bar bar)
//        {
//            this.Bars = new List<Bar>();
//            this.Bars.Add(bar);
//            this.StartPoint = new Geometry.Point(bar.StartPoint);
//            this.EndPoint = new Geometry.Point(bar.EndPoint);
//            this.LevelName = bar.Storey.Name;
//            this.StartOffset = bar.StartPoint.Z - bar.Storey.Elevation;
//            this.EndOffset = bar.EndPoint.Z - bar.Storey.Elevation;
//        }

//        /// <summary>
//        /// Sets the name of the beam reference level
//        /// </summary>
//        /// <param name="levelName"></param>
//        public void SetLevel(string levelName)
//        {
//            this.LevelName = levelName;
//        }

//        /// <summary>
//        /// Set the offset distance between the beam start point and the reference level
//        /// </summary>
//        /// <param name="distance"></param>
//        public void SetStartOffset(double distance)
//        {
//            this.StartOffset = distance;
//        }

//        /// <summary>
//        /// Set the offset distance between the beam end point and the reference level
//        /// </summary>
//        /// <param name="distance"></param>
//        public void SetEndOffset(double distance)
//        {
//            this.EndOffset = distance;
//        }


//    }
//}