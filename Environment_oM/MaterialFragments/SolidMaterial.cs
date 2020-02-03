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

namespace BH.oM.Environment.MaterialFragments
{
    [Description("Fragment containing the Gas Material properties related to materials")]
    public class SolidMaterial : BHoMObject, IEnvironmentMaterial, IBHoMFragment
    {
        [Description("The density of the material")]
        public double Density { get; set; } = 0.0;

        [Description("The amount of conductivity the material should have")]
        public double Conductivity { get; set; } = 0.0;

        [Description("The unit of specific heat the material should have")]
        public double SpecificHeat { get; set; } = 0.0;

        [Description("The amount of vapour resistance the material should have")]
        public double VapourResistivity { get; set; } = 0.0;

        [Description("A description of this material, default empty string")]
        public string Description { get; set; } = "";

        [Description("The roughness of the material from the Material Roughness enum")]
        public Roughness Roughness { get; set; } = Roughness.Undefined;

        [Description("The refraction of the material")]
        public double Refraction { get; set; } = 0.0;

        [Description("The amount of external solar reflectance of this solid material")]
        public double SolarReflectanceExternal { get; set; } = 0.0;

        [Description("The amount of internal solar reflectance of this solid material")]
        public double SolarReflectanceInternal { get; set; } = 0.0;

        [Description("The amount of solar transmittance of this solid material")]
        public double SolarTransmittance { get; set; } = 0.0;

        [Description("The amount of external light reflectance of this solid material")]
        public double LightReflectanceExternal { get; set; } = 0.0;

        [Description("The amount of internal light reflectance of this solid material")]
        public double LightReflectanceInternal { get; set; } = 0.0;

        [Description("The amount of light transmittance of this solid material")]
        public double LightTransmittance { get; set; } = 0.0;

        [Description("The external emissivity of this solid material")]
        public double EmissivityExternal { get; set; } = 0.0;

        [Description("The internal emissivity of this solid material")]
        public double EmissivityInternal { get; set; } = 0.0;

        [Description("The specularity of the solid material, where specularity is the proportion of directed light reflected from the material")]
        public double Specularity { get; set; } = 0.0;

        [Description("The amount of diffused light transmitted through the solid material")]
        public double TransmittedDiffusivity { get; set; } = 0.0;

        [Description("The amount of directed light transmitted through the solid material")]
        public double TransmittedSpecularity { get; set; } = 0.0;

        [Description("Define whether or not this material should be ignored in any uValue calculations")]
        public bool IgnoreInUValueCalculation { get; set; } = false;
    }
}

