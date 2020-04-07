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

using BH.oM.Environment.Fragments;
using BH.oM.Base;

using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environment.Gains
{
    [Description("An Environment gains Emitter object")]
    public class Emitter : BHoMObject, IEnvironmentObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The radiant property of the emitter")]
        public virtual double RadiantProportion { get; set; } = 0.0;

        [Description("The view property of the emitter")]
        public virtual double ViewCoefficient { get; set; } = 0.0;

        [Description("The maximum temperature outside the space the emitter should be working with")]
        public virtual double MaximumOutsideTemperature { get; set; } = 0.0;

        [Description("The temperature to be used outside the emitter when switched off")]
        public virtual double SwitchOffOutsideTemperature { get; set; } = 0.0;

        [Description("The type of emitter from the Emitter Type enum")]
        public virtual EmitterType Type { get; set; } = EmitterType.Undefined;

        /***************************************************/
    }
}

