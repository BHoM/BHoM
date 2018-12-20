/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

using BH.oM.Common;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Base;
using System.Collections.Generic;
using System;

namespace BH.oM.Structure.Results
{
    public abstract class MeshResult : IResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public IComparable ObjectId { get; } = "";

        public IComparable NodeId { get; } = "";

        public IComparable MeshFaceId { get; } = "";

        public IComparable ResultCase { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        public MeshResultLayer MeshResultLayer { get; set; }

        public double LayerPosition { get; set; }

        public MeshResultSmoothingType Smoothing { get; set; }

        [Description("CoordinateSystem required in order to report results in a particular direction, for example, for anisotropic materials")]
        public Geometry.CoordinateSystem.Cartesian CoordinateSystem { get; set; } = new Geometry.CoordinateSystem.Cartesian();

        public Dictionary<string, object> CustomData { get; set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected MeshResult(   IComparable objectId,
                                IComparable nodeId,
                                IComparable meshFaceId,
                                IComparable resultCase,
                                double timeStep,
                                MeshResultLayer meshResultLayer,
                                double layerPosition,
                                MeshResultSmoothingType smoothing,
                                Geometry.CoordinateSystem.Cartesian coordinateSystem)
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

