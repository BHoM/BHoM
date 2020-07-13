/*	
 * This file is part of the Buildings and Habitats object Model (BHoM)	
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.	
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
    public class DiffConfig : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Tolerance used to determine numerical differences." +
            "\nDefaults to 1e-6.")]
        public virtual double NumericTolerance { get; set; } = 1e-6;

        [Description("By default, diffing considers all the properties of the objects." +
            "\nHere you can specify a list of property names. Only the properties with a name matching any of this list will be considered for diffing." +
            "\nE.g., if you input 'Name' only the differences in terms of name will be returned." +
            "\nNOTE: these can be only top-level properties of the object (not the sub-properties).")]
        public virtual List<string> PropertiesToConsider { get; set; } = new List<string>();

        [Description("List of strings specifying the names of the properties that should be ignored in the diffing." +
            "\nNOTE: This considers ALL properties AND sub-properties. Any property with a name matching any of this list will be ignored." +
            "\nBy default it includes `BHoM_Guid`.")]
        public virtual List<string> PropertiesToIgnore { get; set; } = new List<string>() { "BHoM_Guid" };

        [Description("Enables the property-level diffing: differences in object properties are stored in the `ModifiedPropsPerObject` dictionary.")]
        public virtual bool EnablePropertyDiffing { get; set; } = true;

        [Description("If EnablePropertyDiffing is true, this sets the maximum number of differences to be determine before stopping." +
            "\nUseful to limit the run time." +
            "\nDefaults to 1000.")]
        public virtual int MaxPropertyDifferences { get; set; } = 1000;

        [Description("If enabled, the Diff stores also the objects that did not change (`Unchanged` property).")]
        public virtual bool StoreUnchangedObjects { get; set; } = false;

        /***************************************************/
    }
}