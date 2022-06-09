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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    [Description("Information about how an object's property should be included or not in a comparison (i.e. when computing an object's Hash or Diffing)." +
        "A ComparisonInclusion object is returned by the extension method of the same name (which is invoked automatically when Hashing or Diffing)." +
        "The ComparisonInclusion() method can be implemented in specific Toolkits/namespaces to customise the comparison (i.e. with Toolkit-specific information which would be otherwise unavailable to the base Hash/Diffing)." +
        "See the wiki for examples of this.")]
    public class ComparisonInclusion : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Whether the current property should be included or not in the comparison (i.e. Hash or Diffing).")]
        public virtual bool Include { get; set; } = true;

        [Description("A custom DisplayName can be set so changes detected will be displayed with this name instead of the default Property Name.")]
        public virtual string DisplayName { get; set; }
    }
}



