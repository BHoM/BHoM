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

        public virtual HashConfig HashConfig { get; set; } = new HashConfig();

        [Description("Enables the property-level diffing: differences in object properties are stored in the `ModifiedPropsPerObject` dictionary.")]
        public virtual bool EnablePropertyDiffing { get; set; } = false;

        [Description("List of names of the keys of the BHoMObjects' CustomData dictionary that should be ignored when doing the property-level diffing." +
            "\nBy default it includes `RenderMesh`.")]
        public virtual List<string> CustomDataToIgnore { get; set; } = new List<string>() { "RenderMesh" };

        [Description("If no Id or HashFragment is found on the objects, but the input lists have same length and the objects are in the same order," +
            "\ndiffing is attempted by taking each object one by one. It will be able to tell only if the objects have been modified or not (no new or old).")]
        public virtual bool AllowOneByOneDiffing { get; set; } = false;

        [Description("If EnablePropertyDiffing is true, this sets the maximum number of differences to be determine before stopping." +
            "\nUseful to limit the run time." +
            "\nDefaults to 1000.")]
        public virtual int MaxPropertyDifferences { get; set; } = 1000;

        [Description("If enabled, the Diff stores also the objects that did not change (`Unchanged` property).")]
        public virtual bool StoreUnchangedObjects { get; set; } = true;

        /***************************************************/
    }
}