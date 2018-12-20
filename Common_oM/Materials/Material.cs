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

using BH.oM.Base;


namespace BH.oM.Common.Materials
{
    /// <summary>
    /// Material class for use in all other object classes and namespaces
    /// </summary>
    public class Material : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public MaterialType Type { get; set; } = MaterialType.Steel;

        public double YoungsModulus { get; set; } = 0.0;

        public double PoissonsRatio { get; set; } = 0.0;

        public double DryDensity { get;  set; } = 0.0;

        public double CoeffThermalExpansion { get; set; } = 0.0;

        public double DampingRatio { get; set; } = 0.0;

        public double Density { get; set; } = 0.0; //in [kg/m^3] 

        public double CompressiveYieldStrength { get; set; } = 0.0;

        public double TensileYieldStrength { get; set; } = 0.0;

        public double StrainAtYield { get; set; } = 0.0;


        /***************************************************/
    }
}




