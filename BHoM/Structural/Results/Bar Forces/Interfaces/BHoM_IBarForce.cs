
namespace BHoM.Structural.Results.Bars
{
    /// <summary>
    /// Bar force interface class
    /// </summary>
    public interface IBarForce 
    {
        /// <summary>Associated bar number</summary>
        int BarNumber { get; set; }

        /// <summary>Position along the bar as an integer 0 = start, 1 = end</summary>
        int Position { get; set; }

        /// <summary>Position along the bar of the force. Set 0 for 1 for end</summary>
        double RelativePosition { get; set; }

        /// <summary>Represents the number of positions along the bar</summary>
        int Divisions { get; set; }

        /// <summary>Loadcase</summary>
        BHoM.Structural.Loads.Loadcase Loadcase { get; set; }

        /// <summary>Associated loadcase number</summary>
        int LoadcaseNumber { get; }

        /// <summary>Associated loadcase name</summary>
        string LoadcaseName { get; }

        /// <summary>Axial force, tension negative</summary>
        double FX { get; set; }

        /// <summary>Shear force, minor axis</summary>
        double FY { get; set; }

        /// <summary>Shear force, major axis</summary>
        double FZ { get; set; }

        /// <summary>Torsion</summary>
        double MX { get; set; }

        /// <summary>Bending moment, minor axis</summary>
        double MY { get; set; }

        /// <summary>Bending moment, major axis</summary>
        double MZ { get; set; }

        /// <summary>Maximum principle stress</summary>
        double SMax { get; set; }

        /// <summary>Minimum principle stress</summary>
        double SMin { get; set; }

        /// <summary>Orientation of bar forces inherited from bar</summary>
        BHoM.Geometry.Plane OrientationPlane { get; set; }

        /// <summary>User text field for any user data</summary>
        string UserData { get; set; }

       

    }
}
