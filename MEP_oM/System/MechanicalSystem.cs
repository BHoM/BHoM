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

using System.ComponentModel;
using BH.oM.MEP.Enums;
using BH.oM.Base;

namespace BH.oM.MEP.System
{
    [Description("Mechanical systems are qualified by their ability to convey air, water, etc to a building/room/area")]
    public class MechanicalSystem : BHoMObject, ISystemType
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/ 

        [Description("Fluid type that flows throughout the specified flow objects.")]
        public virtual FluidType FluidType { get; set; } = FluidType.Undefined;

        [Description("The mean temperature of the fluid within the mechanical system (degrees Celsius).")]
        public virtual double FluidTemperature { get; set; } = 0;

        [Description("The viscosity of the fluid is the measure of its resistance to flow.")]
        public virtual double FluidViscosity { get; set; } = 0;

        [Description("The mass per unit volume of the fluid within the mechanical system.")]
        public virtual double FluidDensity { get; set; } = 0;

        /***************************************************/
    }
}


