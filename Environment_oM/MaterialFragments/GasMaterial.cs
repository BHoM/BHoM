/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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

namespace BH.oM.Environment.MaterialFragments
{
    public class GasMaterial : BHoMObject, IEnvironmentMaterial
    {
        public double Density { get; set; } = 0.0;
        public double Conductivity { get; set; } = 0.0;
        public double SpecificHeat { get; set; } = 0.0;
        public double VapourResistivity { get; set; } = 0.0;
        public string Description { get; set; } = "";
        public Roughness Roughness { get; set; } = Roughness.Undefined;
        public double Refraction { get; set; } = 0.0;

        public double ConvectionCoefficient { get; set; } = 0.0;
        public Gas Gas { get; set; } = Gas.Undefined;
    }
}
