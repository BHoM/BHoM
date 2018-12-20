/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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
using BH.oM.Environment.Interface;
using BH.oM.Environment.Materials;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Elements
{
    public class Construction : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IMaterial> Materials { get; set; } = new List<IMaterial>();
        public double Thickness { get; set; } = 0.0;
        public List<double> UValues { get; set; } = new List<double>();
        public ConstructionType ConstructionType { get; set; } = ConstructionType.Opaque;
        public double AdditionalHeatTransfer { get; set; } = 0.0;
        public double FFactor { get; set; } = 0.0; //Watts per Meter per Degrees Celsius (w/m degC) - conduction only for floor elements (14.12.2018)
        public ConstructionRoughness Roughness { get; set; } = ConstructionRoughness.Rough;

        public double AbsorptanceValue { get; set; } = 0.0;
        public AbsorptanceUnit AbsorptanceUnit { get; set; } = AbsorptanceUnit.Fraction;
        public AbsorptanceType AbsorptanceType { get; set; } = AbsorptanceType.ExtIR;

        /***************************************************/
    }
}
