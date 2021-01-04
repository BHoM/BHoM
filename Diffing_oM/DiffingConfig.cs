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
    public class DiffingConfig : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Settings to determine the uniqueness of an Object.")]
        public virtual ComparisonConfig ComparisonConfig { get; set; } = new ComparisonConfig();

        [Description("Enables the property-level diffing: differences in object properties are stored in the `ModifiedPropsPerObject` dictionary.")]
        public virtual bool EnablePropertyDiffing { get; set; } = false;

        [Description("If EnablePropertyDiffing is true, this sets the maximum number of differences to be determine before stopping." +
            "\nUseful to limit the run time." +
            "\nDefaults to 1000.")]
        public virtual int MaxPropertyDifferences { get; set; } = 1000;

        [Description("If enabled, the Diff includes also the objects that did not change (`Unchanged`).")]
        public virtual bool IncludeUnchangedObjects { get; set; } = true;

        [Description("Type of PersistentId that should be used to perform the Diffing.")]
        public virtual Type PersistentIdType { get; set; }

        [Description("Key of the CustomData dictionary where to look for an Id to use for the Diffing.")]
        public virtual string CustomDataKey { get; set; }

        /***************************************************/
    }
}