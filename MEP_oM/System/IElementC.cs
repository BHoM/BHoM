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
using BH.oM.MEP.Fragments;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.MEP.System
{
    [Description("Enables Consumption based operations to be performed on elements that consume resources\n" +
                 "Ensures the material composition of a physical object is represented, defined as proportions of discrete types of material forming the object's total solid volume.\n" +
                 "Objects implementing this Interface will be required to implement some base methods for getting and setting data in a way that maintains the object's other properties.\n" +
                 "Documentation detailing required extension methods can be found here: https://github.com/BHoM/documentation/wiki/IElement-required-extension-methods")]
    public interface IElementC : IObject
    {
        [Description("A data fragment that contains information regarding the consumption properties of the object.")]
        List<ConsumptionFragment> Consumption { get; set; }
    }
}

