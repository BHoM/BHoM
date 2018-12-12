using System;
using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;

namespace BH.oM.Structure.Results
{
    public class MeshDisplacement : MeshResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        
        [Description("Translation in local X direction (defined by result coordinate system), in m")]
        public double UXX { get; } = 0.0;

        [Description("Translation in local Y direction (defined by result coordinate system), in m")]
        public double UYY { get; } = 0.0;

        [Description("Translation in local Z direction (defined by result coordinate system), in m")]
        public double UZZ { get; } = 0.0;

        [Description("Rotatoin about local X axis (defined by result coordinate system), in radians")]
        public double RXX { get; } = 0.0;

        [Description("Rotatoin about local Y axis (defined by result coordinate system), in radians")]
        public double RYY { get; } = 0.0;

        [Description("Rotatoin about local Z axis (defined by result coordinate system), in radians")]
        public double RZZ { get; } = 0.0;

        /***************************************************/

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshDisplacement(IComparable objectId,
                                IComparable nodeId,
                                IComparable meshFaceId,
                                IComparable resultCase,
                                double timeStep,
                                MeshResultLayer meshResultLayer,
                                double layerPosition,
                                MeshResultSmoothingType smoothing,
                                CoordinateSystem coordinateSystem,
                                double uXX,
                                double uYY,
                                double uZZ,
                                double rXX,
                                double rYY, 
                                double rZZ) : base(objectId, nodeId, meshFaceId, resultCase, timeStep, meshResultLayer, layerPosition, smoothing, coordinateSystem)
        {            
            UXX = uXX;
            UYY = uYY;
            UZZ = uZZ;
            RXX = rXX;
            RYY = rYY;
            RZZ = rZZ;
        }

        /***************************************************/
    }
}
