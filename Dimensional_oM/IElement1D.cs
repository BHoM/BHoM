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

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Dimensional
{
    [Description("A Interface which exposes spatial operations to a ICurve based Element. /n" +
                 "The Interface's methods will expose the object to spatial operations, which can be applyed without modifying the objects other properties." +
                 "Objects implementing this Interface will be required to implement some base methods for getting and setting data in a way that maintains the objects other properties." +
                 "For further instructions refer to the documentation: https://github.com/BHoM/documentation/wiki/IElement-required-extension-methods")]
    public interface IElement1D : IElement
    {
    }
}

