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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Diffing
{
    [Description("What type of Diffing should be computed.")]
    public enum DiffingType
    {
        [Description("Automatic: tries, in sequence, diffing with PersistentId, OneByOne, Hash.")]
        Automatic,
        [Description("Revision: for the Stream-revision workflow. The Diffing considers different Revisions of a Stream (a set of object that changed in time).")]
        Revision,
        [Description("PersistentId: uses the PersistentId stored in the Fragments of the BHoMObjects, if present. If more than one PersistentId is found on the objects, a PersistentId type must be specified in the DiffConfig.")]
        PersistentId,
        [Description("OneByOne: assuming the input collections are of the same length, this compares objects one by one.")]
        OneByOne,
        [Description("Hash: compares by using the object hashes. If there is already a HashFragment stored in the BHoMObjects, by default that is used. Otherwise, hash is computed for every object, and then by default it gets stored in the BHoMObjects. Default behaviours can be changed in the DiffConfig.")]
        Hash,
        [Description("CustomData: uses an Id stored under the BHoMObjects CustomData.")]
        CustomDataId
        /***************************************************/
    }
}
