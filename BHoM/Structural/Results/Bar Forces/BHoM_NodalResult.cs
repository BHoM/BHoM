
namespace BHoM.Structural.Results.Nodes
{
    /// <summary>
    /// Bar force object contains a set of coexisting forces, bar reference
    /// and orientation information
    /// </summary>
    public class NodalResult
    {
        /// <summary>Associated bar number</summary>
        public int NodeNumber { get; set; }

        /// <summary>Loadcase</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; set; }

        /// <summary>Associated loadcase number</summary>
        public int LoadcaseNumber { get; internal set; }

        /// <summary>Associated loadcase name</summary>
        public string LoadcaseName { get; internal set; }

        /// <summary>Translation vector</summary>
        public BHoM.Geometry.Vector Translation { get; set; }
        
        /// <summary>Rotation vector</summary>
        public BHoM.Geometry.Vector Rotation { get; set; }

        /// <summary>Acceleration vector</summary>
        public BHoM.Geometry.Vector Acceleration { get; set; }

        /// <summary>Angular acceleration vector</summary>
        public BHoM.Geometry.Vector AngularAcceleration { get; set; }

        /// <summary>Velocity vector</summary>
        public BHoM.Geometry.Vector Velocity { get; set; }

        /// <summary>Angular velocity vector</summary>
        public BHoM.Geometry.Vector AngularVelocity { get; set; }

        /// <summary>Force vector</summary>
        public BHoM.Geometry.Vector Force { get; set; }

        /// <summary>Moment vector</summary>
        public BHoM.Geometry.Vector Moment { get; set; }

        /// <summary>Orientation of node results</summary>
        public BHoM.Geometry.Plane OrientationPlane { get; set; }

        /// <summary>User text field for any user data</summary>
        public string UserData { get; set; }

        //////////////////////
        //// CONSTRUCTORS ////
        //////////////////////

        /// <summary>Construct a nodal result</summary>
        public NodalResult(int nodeNumber)
        {
            this.NodeNumber = nodeNumber;
        }

        /// <summary>Construct a nodal result with orientation plane</summary>
        public NodalResult(int nodeNumber, BHoM.Geometry.Plane orientationPlane)
        {
            this.NodeNumber = nodeNumber;
            this.OrientationPlane = orientationPlane;
        }
    }
}
