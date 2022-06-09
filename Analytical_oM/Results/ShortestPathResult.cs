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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Analytical.Results;
using BH.oM.Geometry;

namespace BH.oM.Analytical.Elements
{
    [Description("Results associated with the computation of shortest paths.")]
    public class ShortestPathResult : IObjectIdResult, ICasedResult, ITimeStepResult, IImmutable
    {
        [Description("ID of the object that this result belongs to.")]
        public virtual IComparable ObjectId { get; }

        [Description("Identifier for the search that the result belongs to.")]
        public virtual IComparable ResultCase { get; }

        [Description("Time step for time history results.")]
        public virtual double TimeStep { get; }

        [Description("Shortest path as an ordered collection of entities.")]
        public virtual List<IBHoMObject> Path { get; set; } = new List<IBHoMObject>();

        [Description("Shortest path as an ordered collection of ICurves.")]
        public virtual List<ICurve> Curves { get; set; } = new List<ICurve>();

        [Description("Total length of the shortest path. If the graph contained spatial entities and relations the distance traversed. If the graph is non spatial a count of traversed relations.")]
        public virtual double Length { get; set; } = 0.0;

        [Description("Total cost of the shortest path. Sum of each relation weight multiplied by its the length.")]
        public virtual double Cost { get; set; } = 0.0;

        [Description("All entities visited in searching for the path.")]
        public virtual List<IBHoMObject> EntitiesVisited { get; set; } = new List<IBHoMObject>();

        [Description("Shortest path as an ordered collection of IRelations.")]
        public virtual List<IRelation> Relations{ get; set; } = new List<IRelation>();

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/
        public ShortestPathResult(IComparable objectId, IComparable resultCase, double timeStep, List<IBHoMObject> path, double length, double cost, List<IBHoMObject> entitiesVisited, List<IRelation> relations, List<ICurve> curves = null) 
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            Path = path;
            Length = length;
            Cost = cost;
            EntitiesVisited = entitiesVisited;
            Curves = curves;
            Relations = relations;
        }
        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            ShortestPathResult otherRes = other as ShortestPathResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                return l == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : l;
            }
            else
            {
                return n;
            }
        }
    }
}

