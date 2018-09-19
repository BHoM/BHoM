using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structure.Results
{
    public class MeshVonMises: MeshResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Von Mises Stress, in N/m2")]
        public double S { get; }

        [Description("Von Mises normal/membrane forces, in N/m")]
        public double N { get; }

        [Description("Von Mises moments, in Nm/m")]
        public double M { get; }

        /***************************************************/

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshVonMises(string objectId,
                            string nodeId,
                            string meshFaceId,
                            string resultCase,
                            double timeStep,
                            MeshResultLayer meshResultLayer,
                            double layerPosition,
                            MeshResultSmoothingType smoothing,
                            CoordinateSystem coordinateSystem,
                            double s,
                            double n,
                            double m): base(objectId, nodeId, meshFaceId, resultCase, timeStep, meshResultLayer, layerPosition, smoothing, coordinateSystem)
        {
            S = s;
            N = n;
            M = m;
        }

        /***************************************************/
    }
}
