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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Environment.MaterialFragments
{
    [Description("Fragment containing solid material properties related to material")]
    public class SolidMaterial : BHoMObject, IEnvironmentMaterial, IFragment
    {
        public virtual double Density { get; set; } = 0.0;

        public virtual double Conductivity { get; set; } = 0.0;

        public virtual double SpecificHeat { get; set; } = 0.0;

        public virtual double VapourResistivity { get; set; } = 0.0;

        public virtual string Description { get; set; } = "";

        [Description("Required for some calculations, such as determining the convective heat transfer coefficient. Use Roughness enum")]
        public virtual Roughness Roughness { get; set; } = Roughness.Undefined;

        public virtual double Refraction { get; set; } = 0.0;

        public virtual double SolarReflectanceExternal { get; set; } = 0.0;

        public virtual double SolarReflectanceInternal { get; set; } = 0.0;

        public virtual double SolarTransmittance { get; set; } = 0.0;

        public virtual double LightReflectanceExternal { get; set; } = 0.0;

        public virtual double LightReflectanceInternal { get; set; } = 0.0;

        public virtual double LightTransmittance { get; set; } = 0.0;

        public virtual double EmissivityExternal { get; set; } = 0.0;

        public virtual double EmissivityInternal { get; set; } = 0.0;

        public virtual double Specularity { get; set; } = 0.0;

        public virtual double TransmittedDiffusivity { get; set; } = 0.0;

        public virtual double TransmittedSpecularity { get; set; } = 0.0;

        [Description("Define whether or not this material should be ignored in any uValue calculations")]
        public virtual bool IgnoreInUValueCalculation { get; set; } = false;
    }
}



