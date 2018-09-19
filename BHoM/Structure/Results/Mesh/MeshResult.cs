using BH.oM.Common;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Structure.Results
{
    public abstract class MeshResult : IResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ObjectId { get; } = "";

        public string NodeId { get; } = "";

        public string MeshFaceId { get; } = "";

        public string ResultCase { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        public MeshResultLayer MeshResultLayer { get; set; }

        public double LayerPosition { get; set; }

        public MeshResultSmoothingType Smoothing { get; set; }

        [Description("CoordinateSystem required in order to report results in a particular direction, for example, for anisotropic materials")]
        public CoordinateSystem CoordinateSystem { get; set; } = new CoordinateSystem();

        public Dictionary<string, object> CustomData { get; set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected MeshResult(string objectId,
                                string nodeId,
                                string meshFaceId,
                                string resultCase,
                                double timeStep,
                                MeshResultLayer meshResultLayer,
                                double layerPosition,
                                MeshResultSmoothingType smoothing,
                                CoordinateSystem coordinateSystem)
        {
            ObjectId = objectId;
            NodeId = nodeId;
            MeshFaceId = MeshFaceId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            MeshResultLayer = meshResultLayer;
            LayerPosition = layerPosition;
            Smoothing = smoothing;
            CoordinateSystem = coordinateSystem;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            MeshResult otherRes = other as MeshResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int objectId = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (objectId == 0)
            {
                int loadcase = this.ResultCase.CompareTo(otherRes.ResultCase);
                if (loadcase == 0)
                {
                    int meshFaceId = this.MeshFaceId.CompareTo(otherRes.MeshFaceId);
                    if (meshFaceId == 0)
                    {
                        int nodeId = this.NodeId.CompareTo(otherRes.NodeId);
                        return nodeId == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : nodeId;
                    }
                    else {return meshFaceId;}
                }
                else {return loadcase;}
            }
            else {return objectId;}
        }

        /***************************************************/
    }
}

