/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using System.Collections;
using System.Collections.Generic;

namespace BH.oM.Geometry.Results
{
    public class MeshResult<T, G> : IMeshResult, ICasedResult 
        where T: IGenericResult<G> 
        where G : IMeshComponentResult // the double generic allows to set a meaningful constraint: MeshResult can only have `ComponentResults` of type `IMeshComponentResult`.
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual IAdapterId ObjectId { get; set; }

        [Description("Identifier for the Loadcase or LoadCombination that the result belongs to. Is generally name or number of the loadcase, depending on the analysis package.")]
        public virtual IComparable ResultCase { get; set; }

        [Description("All the results for the components of this Mesh (nodes or faces).")]
        public virtual IEnumerable<T> ComponentsResults { get; set; }

        public int CompareTo(IResult other)
        {
            throw new NotImplementedException();
        }
    }
}



