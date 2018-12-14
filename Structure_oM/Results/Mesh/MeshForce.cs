using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using System;

namespace BH.oM.Structure.Results
{
    public class MeshForce : MeshResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Axial/membrane force in X direction in N/m")]
        public double NXX { get; } = 0.0;

        [Description("Axial/membrane force in Y direction in N/m")]
        public double NYY { get; } = 0.0;

        [Description("Axial/membrane force in XY direction in N/m")]
        public double NXY { get; } = 0.0;

        [Description("Bending moment in X direction in N/m")]
        public double MXX { get; } = 0.0;

        [Description("Bending moment in Y direction in Nm/m")]
        public double MYY { get; } = 0.0;

        [Description("Bending moment in XY direction in Nm/m")]
        public double MXY { get; } = 0.0;

        [Description("Shear force in X direction in N/m")]
        public double VX { get; } = 0.0;

        [Description("Shear force in Y direction in N/m")]
        public double VY { get; } = 0.0;

        /***************************************************/

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshForce(   IComparable objectId,
                            IComparable nodeId,
                            IComparable meshFaceId,
                            IComparable resultCase,
                            double timeStep,
                            MeshResultLayer meshResultLayer,
                            double layerPosition,
                            MeshResultSmoothingType smoothing,
                            Geometry.CoordinateSystem.Cartesian coordinateSystem,
                            double nXX,
                            double nYY,
                            double nXY,
                            double mXX,
                            double mYY,
                            double mXY,
                            double vX,
                            double vY) : base(objectId, nodeId, meshFaceId, resultCase, timeStep, meshResultLayer, layerPosition, smoothing, coordinateSystem)
        {            
            NXX = nXX;
            NYY = nYY;
            NXY = nXY;
            MXX = mXX;
            MYY = mYY;
            MXY = mXY;
            VX = vX;
            VY = vY;
        }

        /***************************************************/
    }
}
