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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using BH.oM.Base;
using BH.oM.Geometry;

using System.ComponentModel;

namespace BH.oM.Environment.Analysis
{
    [Description("An AnalysisGrid is used to define an area in 3D space that should be analysed for a given set of results, e.g. daylighting levels, wind levels, heat indexes, etc. - an AnalysisGrid can be used to represent a measurable bit of the environment, including a void in a space, or it can be used to represent a mesh on a panel for analysis")]
    public class AnalysisGrid : BHoMObject, IImmutable
    {
        [Description("The BoundaryCurve is the outer-most edges of the AnalysisGrid. Nodes should not fall outside of this curve")]
        public virtual Polyline BoundaryCurve { get; } = null;

        [Description("The InnerCurves define any openings within the AnalysisGrid which should not be analysed or included in results, such as windows, doors, or atriums")]
        public virtual ReadOnlyCollection<Polyline> InnerCurves { get; } = null;

        [Description("The Nodes define the geometric points in 3D space that form the analysis points of this grid. Each node in the Nodes property will be analysed in the analysis package")]
        public virtual ReadOnlyCollection<Node> Nodes { get; } = null;

        [Description("The ID of the AnalysisGrid. This should be unique for AnalysisGrids in a collection and is used to refer to result objects in the ObjectId property of result objects")]
        public virtual int ID { get; } = -1;

        [Description("The name for the AnalysisGrid to identify it for users")]
        public override string Name { get; set; } = "";

        public AnalysisGrid(Polyline boundaryCurve = null, ReadOnlyCollection<Polyline> innerCurves = null, ReadOnlyCollection<Node> nodes = null, int id = -1)
        {
            BoundaryCurve = boundaryCurve;
            InnerCurves = innerCurves ?? new ReadOnlyCollection<Polyline>(new List<Polyline>());
            Nodes = nodes ?? new ReadOnlyCollection<Node>(new List<Node>());
            ID = id;
        }
    }
}


