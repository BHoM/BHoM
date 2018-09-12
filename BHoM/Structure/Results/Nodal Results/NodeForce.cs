using System.ComponentModel;

namespace BH.oM.Structure.Results
{
    public class NodeForce : NodeResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Axial/membrane force in X direction in N/m2")]
        public double NXX { get; set; } = 0.0;

        [Description("Axial/membrane force in Y direction in N/m2")]
        public double NYY { get; set; } = 0.0;

        [Description("Axial/membrane force in XY direction in N/m2")]
        public double NXY { get; set; } = 0.0;

        [Description("Bending moment in X direction in N/m2")]
        public double MXX { get; set; } = 0.0;

        [Description("Bending moment in Y direction in N/m2")]
        public double MYY { get; set; } = 0.0;

        [Description("Bending moment in XY direction in N/m2")]
        public double MXY { get; set; } = 0.0;

        [Description("Shear force in X direction in N/m2")]
        public double VX { get; set; } = 0.0;

        [Description("Shear force in Y direction in N/m2")]
        public double VY { get; set; } = 0.0;

        /***************************************************/
    }
}
