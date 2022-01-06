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
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Diffing
{
    [Description("General configurations for the Diffing process, including settings for the Hash computation.")]
    public class DiffingConfig : IObject
    {
        /***************************************************/ 
        /**** Properties                                ****/
        /***************************************************/

        [Description("Settings to determine the uniqueness of an Object.")]
        public virtual BaseComparisonConfig ComparisonConfig { get; set; } = new ComparisonConfig();

        [Description("Enables the property-level diffing: differences in object properties are stored in the `ModifiedPropsPerObject` dictionary of the Diff object." +
            "\nWARNING: may be slow." +
            "\nFor large object collections, if you are not interested in what properties changed, you can turn this to false to speed up.")]
        public virtual bool EnablePropertyDiffing { get; set; } = true;

        [Description("If enabled, the Diff includes also the objects that did not change (`Unchanged`)." +
            "\nWhen dealing with very large sets, you can keep this on `false` to improve performance: the UnchangedObjects can be derived from the original set, minus the Deleted and Modified objects.")]
        public virtual bool IncludeUnchangedObjects { get; set; } = true;

        [Description("By default, duplicate Ids are not allowed and Diffing will not consider them. If you want to be able to specify duplicate Ids, set this to true.")]
        public virtual bool AllowDuplicateIds { get; set; } = false;

        /***************************************************/
    }
}

