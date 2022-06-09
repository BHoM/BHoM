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
using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    [Description("Base class for all Relation classes.")]
    public class Relation : BHoMObject, IRelation
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Reference Guid to source entity.")]
        public virtual Guid Source { get; set; } = Guid.Empty;

        [Description("Reference Guid to target entity.")]
        public virtual Guid Target { get; set; } = Guid.Empty;

        [Description("This Relation's sub Graph.")]
        public virtual Graph Subgraph { get; set; } = new Graph();

        [Description("Weight of the Relation.")]
        public virtual double Weight { get; set; } = 1.0;

        [Description("Curve that represents the link between the source and target entities.")]
        public virtual ICurve Curve { get; set; }

    }
}


