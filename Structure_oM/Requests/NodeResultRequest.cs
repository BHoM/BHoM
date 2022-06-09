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

using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Structure.Loads;


namespace BH.oM.Structure.Requests
{
    [Description("Request for extracting Node results from an adapter.")]
    public class NodeResultRequest : IStructuralResultRequest
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Defines which type of results that should be extracted.")]
        public virtual NodeResultType ResultType { get; set; } = NodeResultType.NodeReaction;

        [Description("Defines whether results should be extracted in global coordinates or local node coordinates.")]
        public virtual LoadAxis Axis { get; set; } = LoadAxis.Global;

        [Description("Defines which cases and/or combinations that results should be extracted for. Can generally be set to either Loadcase or Loadcombination objects, or identifiers matching the software. If nothing is provided, results for all cases will be assumed.")]
        public virtual List<object> Cases { get; set; } = new List<object>();

        [Description("Defines for which modes results should be extracted. Only applicable for some casetypes. If nothing is provided, results for all modes will be assumed.")]
        public virtual List<string> Modes { get; set; } = new List<string>();

        [Description("Defines which Nodes that results should be extracted for. Can generally be set to either pulled Node objects, or identifiers matching the software. If nothing is provided, results for all Nodes will be assumed.")]
        public virtual List<object> ObjectIds { get; set; } = new List<object>();

        /***************************************************/
    }
}



