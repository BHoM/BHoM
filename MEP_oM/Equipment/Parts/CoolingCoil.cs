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
using BH.oM.Base;
using BH.oM.MEP.Process;

namespace BH.oM.MEP.Equipment.Parts
{
    [Description("Cooling coils allow fluids (air) to lower their temperature as they pass through the coil")]
    public class CoolingCoil : BHoMObject, ICoolProcess, IHeatExchanger, IFlowImpediment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Total capacity indicates the combined sensible and latent capacity of the cooling coil")]
        public virtual double TotalCapacity { get; set; } = 0.0;
        
        [Description("Sensible capacity indicates the ability for the cooling coil to change the temperature (rather than the phase) of the fluid (air).")]
        public virtual double SensibleCapacity { get; set; } = 0.0;

        [Description("Latent capacity indicates the ability for the cooling coil to change the phase of the fluid (air).")]
        public virtual double LatentCapacity { get; set; } = 0.0;

        [Description("Pressure Drop indicates the amount of resistance created by the coil which creates a loss in pressure of the fluid (air)")]
        public virtual double PressureDrop { get; set; } = 0.0;
        public PartsFlowNode EnteringProcessFluid { get => throw new global::System.NotImplementedException(); set => throw new global::System.NotImplementedException(); }
        public PartsFlowNode LeavingProcessFluid { get => throw new global::System.NotImplementedException(); set => throw new global::System.NotImplementedException(); }
        public PartsFlowNode EnteringFluid { get => throw new global::System.NotImplementedException(); set => throw new global::System.NotImplementedException(); }
        public PartsFlowNode LeavingFluid { get => throw new global::System.NotImplementedException(); set => throw new global::System.NotImplementedException(); }


        /***************************************************/
    }
}



