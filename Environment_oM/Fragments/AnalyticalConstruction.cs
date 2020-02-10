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
using BH.oM.Analytical.Elements;

using System.ComponentModel;

namespace BH.oM.Environment.Fragments
{
    public class AnalyticalConstruction : IBHoMFragment, IImmutable
    {
        public double ConstructionThickness { get; } 
        public double ExternalEmissivity { get; }
        public double ExternalSolarAbsorptance { get; }
        public double ExternalVisibleReflectance { get; }
        public double GValue { get; }
        public double InternalEmissivity { get; }
        public double InternalSolarAbsorptance { get; }
        public double InternalVisibleReflectance { get; }
        public double RefractiveIndex { get; }
        public double RValue { get; }
        public double ThermalMassCm { get; }
        public double UValue { get; }
        public double VisibleLightTransmittance { get; }

        public AnalyticalConstruction(double constructionThickness, double externalEmissivity, double externalSolarAbsorptance, double externalVisibleReflectance, double gValue, double internalEmissivity, double internalSolarAbsorptance, double internalVisibleReflectance, double refractiveIndex, double rValue, double thermalMassCm, double uValue, double visibleLightTransmittance)
        {
            ConstructionThickness = constructionThickness;
            ExternalEmissivity = externalEmissivity;
            ExternalSolarAbsorptance = externalSolarAbsorptance;
            ExternalVisibleReflectance = externalVisibleReflectance;
            GValue = gValue;
            InternalEmissivity = internalEmissivity;
            InternalSolarAbsorptance = internalSolarAbsorptance;
            InternalVisibleReflectance = internalVisibleReflectance;
            RefractiveIndex = refractiveIndex;
            RValue = rValue;
            ThermalMassCm = thermalMassCm;
            UValue = uValue;
            VisibleLightTransmittance = visibleLightTransmittance;
        } 

    }
}
