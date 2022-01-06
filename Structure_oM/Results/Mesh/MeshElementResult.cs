/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using BH.oM.Analytical.Results;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Base;
using System;

namespace BH.oM.Structure.Results
{
    [Description("Base class for all discrete mesh element results, that is a result for an individual node and/or face. Stores all identifier information and how to sort the results in a collection.")]
    public abstract class MeshElementResult : IMeshElementResult, IStructuralResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the FEMesh/Panel that this result belongs to. When extracted from an analysis package, the object id will match the format and value used in that particular package.")]
        public virtual IComparable ObjectId { get; }

        [Description("Id of the Node in the mesh that this result belongs to. Will be empty for smoothing types not relating to Nodes. When extracted from an analysis package, the Node id will correspond to the node id in the software and match the format and value used in that particular package.")]
        public virtual IComparable NodeId { get; }

        [Description("Id of the FEFace that this result belongs to. Will be empty for smoothing types not relating to Faces. When extracted from an analysis package, the face id will correspond to the face id in the software and match the format and value used in that particular package.")]
        public virtual IComparable MeshFaceId { get; }

        [Description("Identifier for the Loadcase or LoadCombination that the result belongs to. Is generally name or number of the loadcase, depending on the analysis package.")]
        public virtual IComparable ResultCase { get; }

        [Description("Positive index, starting at one. Only set for cases with modal outputs such as dynamic cases.")]
        public virtual int ModeNumber { get; }

        [Description("Time step for time history results.")]
        public virtual double TimeStep { get; }

        public virtual MeshResultLayer MeshResultLayer { get; }

        [Description("Position within the element thickness that result is extracted from, normalised to 1. I.e. 0 = lower surface, 0.5 = middle, 1 = top surface.")]
        public virtual double LayerPosition { get; }

        public virtual MeshResultSmoothingType Smoothing { get; }

        [Description("Vector basis required in order to report results in a particular direction, for example, for anisotropic materials.")]
        public virtual Basis Orientation { get; } = Basis.XY;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected MeshElementResult(IComparable objectId,
                                IComparable nodeId,
                                IComparable meshFaceId,
                                IComparable resultCase,
                                int modeNumber,
                                double timeStep,
                                MeshResultLayer meshResultLayer,
                                double layerPosition,
                                MeshResultSmoothingType smoothing,
                                Basis orientation)
        {
            ObjectId = objectId;
            NodeId = nodeId;
            MeshFaceId = meshFaceId;
            ResultCase = resultCase;
            ModeNumber = modeNumber;
            TimeStep = timeStep;
            MeshResultLayer = meshResultLayer;
            LayerPosition = layerPosition;
            Smoothing = smoothing;
            Orientation = orientation;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        [Description("Controls how this result is sorted in relation to other results. Sorts with the following priority: Type, ObjectId, ResultCase, MeshFaceId, NodeId, TimeStep.")]
        public int CompareTo(IResult other)
        {
            MeshElementResult otherRes = other as MeshElementResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int objectId = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (objectId == 0)
            {
                int loadcase = this.ResultCase.CompareTo(otherRes.ResultCase);
                if (loadcase == 0)
                {
                    int mode = this.ModeNumber.CompareTo(otherRes.ModeNumber);
                    if (mode == 0)
                    {

                        int meshFaceId = this.MeshFaceId.CompareTo(otherRes.MeshFaceId);
                        if (meshFaceId == 0)
                        {
                            int nodeId = this.NodeId.CompareTo(otherRes.NodeId);
                            return nodeId == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : nodeId;
                        }
                        else { return meshFaceId; }
                    }
                    else
                    {
                        return mode;
                    }
                }
                else
                {
                    return loadcase;
                }
            }
            else
            {
                return objectId;
            }
        }

        /***************************************************/
    }
}




