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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Reflection.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    [Description("Represents the differences between two sets of objects.")]
    public interface IDiff : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Objects present in the second set that are not present in the first set.")]
        IEnumerable<object> AddedObjects { get; }

        [Description("Objects not present in the second set that were present in the first set.")]
        IEnumerable<object> RemovedObjects { get; }

        [Description("Objects that are recognised as present both in the first set and the second set, but that have some property that is different."
            + "\nThe rules that were used to recognise modification are in the `DiffingConfig.ComparisonConfig`.")]
        IEnumerable<object> ModifiedObjects { get; }

        [Description("Objects that are recognised as the same in the first and second set.")]
        IEnumerable<object> UnchangedObjects { get; }

        IEnumerable<ObjectDifferences> ModifiedObjectsDifferences { get; }

        [Description("Default diffing settings for this Stream. Hashes of objects contained in this stream will be computed based on these configs.")]
        DiffingConfig DiffingConfig { get; }
    }
}


