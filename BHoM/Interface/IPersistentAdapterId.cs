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
using System.ComponentModel;

namespace BH.oM.Base
{
    [Description("Requires a Fragment to contain a PersistentId, imported through an Adapter, that can be used to track an object.")]
    public interface IPersistentAdapterId : IFragment
    {
        [Description("Persistent identifier of the object in the external software, imported through an Adapter." +
            "'Persistent' means that the identifier must be: globally unique and referring to exactly one object in the external software; generated once upon object creation in the external software; never changing throughout the life of the object in the external software." +
            "If all these requirements are satisfied, the PersistentId imported from the external software can be used for Diffing purposes.")]
        object PersistentId { get; }
    }
}



