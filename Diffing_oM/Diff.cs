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
using BH.oM.Base.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    [Description("Represents the differences between two sets of objects.")]
    public class Diff : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Objects present in the second set that are not present in the first set.")]
        public virtual IEnumerable<object> AddedObjects { get; }

        [Description("Objects not present in the second set that were present in the first set.")]
        public virtual IEnumerable<object> RemovedObjects { get; }

        [Description("Objects that are recognised as present both in the first set and the second set, but that have some property that is different."
            + "\nThe rules that were used to recognise modification are in the `DiffingConfig.ComparisonConfig`.")]
        public virtual IEnumerable<object> ModifiedObjects { get; }

        [Description("Objects that are recognised as the same in the first and second set.")]
        public virtual IEnumerable<object> UnchangedObjects { get; }

        public virtual IEnumerable<ObjectDifferences> ModifiedObjectsDifferences { get; }

        [Description("Default diffing settings for this Stream. Hashes of objects contained in this stream will be computed based on these configs.")]
        public virtual DiffingConfig DiffingConfig { get; }

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        [Description("Creates new Delta object with information on the added, removed or modified object, and (if exists) the Diffing Stream that contains them.")]
        [Input("addedObjects", "Objects existing exclusively in the 'primary' set, i.e. the 'new' objects.")]
        [Input("removedObjects", "Objects existing exclusively in the 'secondary' set, i.e. the 'old' objects.")]
        [Input("modifiedObjects", "Objects existing in both sets that have some differences in their properties.")]
        [Input("modifiedPropsPerObject", "Dictionary holding the differences in properties of the 'modified' objects. See the corresponding property description for more info.")]
        public Diff(IEnumerable<object> addedObjects, IEnumerable<object> removedObjects, IEnumerable<object> modifiedObjects, DiffingConfig diffingConfig, IEnumerable<ObjectDifferences> modifiedObjectsDifferences = null, IEnumerable<object> unchangedObjects = null)
        {
            AddedObjects = addedObjects;
            RemovedObjects = removedObjects;
            ModifiedObjects = modifiedObjects;
            DiffingConfig = diffingConfig;
            ModifiedObjectsDifferences = modifiedObjectsDifferences;
            UnchangedObjects = unchangedObjects;
        }

        /***************************************************/
    }
}



