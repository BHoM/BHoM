
namespace BHoM.Structural.Results.Bars
{
    /// <summary>
    /// Bar force object contains a set of coexisting forces, bar reference
    /// and orientation information
    /// </summary>
    public class BarForce : IBarForce
    {
        /// <summary>Associated bar number</summary>
        public int BarNumber { get; set; }

        /// <summary>Position along the bar as an integer 0 = start, 1 = end</summary>
        public int Position { get; set; }

        /// <summary>Position along the bar of the force. Set 0 for 1 for end</summary>
        public double RelativePosition { get; set; }

        /// <summary>Represents the number of positions along the bar</summary>
        public int Divisions { get; set; }

        /// <summary>Loadcase</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; set; }

        /// <summary>Associated loadcase number</summary>
        public int LoadcaseNumber { get; internal set; }

        /// <summary>Associated loadcase name</summary>
        public string LoadcaseName { get; internal set; }

        /// <summary>Axial force, tension negative</summary>
        public double FX { get; set; }
        
        /// <summary>Shear force, minor axis</summary>
        public double FY { get; set; }

        /// <summary>Shear force, major axis</summary>
        public double FZ { get; set; }

        /// <summary>Torsion</summary>
        public double MX { get; set; }

        /// <summary>Bending moment, minor axis</summary>
        public double MY { get; set; }

        /// <summary>Bending moment, major axis</summary>
        public double MZ { get; set; }

        /// <summary>Maximum principle stress</summary>
        public double SMax { get; set; }

        /// <summary>Minimum principle stress</summary>
        public double SMin { get; set; }

        /// <summary>Orientation of bar forces inherited from bar</summary>
        public BHoM.Geometry.Plane OrientationPlane { get; set; }

        /// <summary>User text field for any user data</summary>
        public string UserData { get; set; }

        //////////////////////
        //// CONSTRUCTORS ////
        //////////////////////

        /// <summary>Construct a bar force with loadcases</summary>
        public BarForce(BHoM.Structural.Loads.Loadcase loadcase, int barNumber, int position)
        {
            this.Loadcase = loadcase;
            this.BarNumber = barNumber;
            this.Position = position;
            this.LoadcaseNumber = loadcase.Number;
            this.LoadcaseName = loadcase.Name;
        }

        /// <summary>Construct a bar force with loadcases</summary>
        public BarForce(BHoM.Structural.Loads.Loadcase loadcase, int barNumber, int position, BHoM.Geometry.Plane orientationPlane)
        {
            this.BarNumber = barNumber;
            this.Position = position;
            this.Loadcase = loadcase;
            this.LoadcaseNumber = loadcase.Number;
            this.LoadcaseName = loadcase.Name;
            this.OrientationPlane = orientationPlane;
        }
    }
}
