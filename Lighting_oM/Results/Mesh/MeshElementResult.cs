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

namespace BH.oM.Lighting.Results.Mesh
{
    [Description("Base class for all discrete mesh element results, that is a result for an individual node. Stores all identifier information and how to sort the results in a collection")]
    public abstract class MeshElementResult : IObjectIdResult, ICasedResult, ITimeStepResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("ID of the AnalysisGrid that this result belongs to")]
        public virtual IComparable ObjectId { get; } = "";

        [Description("ID of the Node in the Analysis Grid that this result belongs to")]
        public virtual IComparable NodeID { get; } = "";

        [Description("Identifier for the Analysis Case that the result belongs to. Is generally name or number of the analysis")]
        public virtual IComparable ResultCase { get; } = "";

        [Description("Time step for time history results. Typically this will be hour intervals for most analysis")]
        public virtual double TimeStep { get; } = 0.0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected MeshElementResult(IComparable objectId,
                                IComparable nodeId,
                                IComparable resultCase,
                                double timeStep)
        {
            ObjectId = objectId;
            NodeID = nodeId;
            ResultCase = resultCase;
            TimeStep = timeStep;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        [Description("Controls how this result is sorted in relation to other results. Sorts with the following priority: Type, ObjectId, ResultCase, NodeID, TimeStep.")]
        public int CompareTo(IResult other)
        {
            MeshElementResult otherRes = other as MeshElementResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int objectId = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (objectId == 0)
            {
                int analysisCase = this.ResultCase.CompareTo(otherRes.ResultCase);
                if (analysisCase == 0)
                {
                    int nodeId = this.NodeID.CompareTo(otherRes.NodeID);
                        return nodeId == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : nodeId;
                }
                else
                    return analysisCase;
            }
            else
                return objectId;
        }

        /***************************************************/
    }
}




