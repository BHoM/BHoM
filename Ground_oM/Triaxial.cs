/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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


using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;

namespace BH.oM.Ground
{

    [Description("A stratum containing the geological information based on the AGS schema.")]
    public class InSituVane : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
   
        [Length]
        [Description("Top of sample (SAMP_TOP).")]
        public virtual double Top { get; set; }

        [Pressure]
        [Description("Undrained shear strength at failure (TRIT_CU)")]
        public virtual double Cu { get; set; }

        [Length]
        [Description("Specimen diameter (TRIT_SDIA)")]
        public virtual double SpecimenDiameter { get; set; }

        [Description("Specimen length (TRIT_SLEN)")]
        public virtual double SampelLength { get; set; }

        [Description("Specimen initial water/moisture content (TRIT_IMC)")]
        public virtual double IMC { get; set; }

        [Description("Mode of Failure (TRIT_MODE)")]
        public virtual string FailureMode { get; set; }

        [Description("Specimen final water/moisture content (TRIT_FMC)")]
        public virtual double FMC { get; set; }

		[Description("Total Cell pressure (TRIT_CELL)")]
		public virtual double CellPressure { get; set; }

		[Description("Corrected deviator stress at failure (TRIT_DEVF)")]
		public virtual double DeviatorStress { get; set; }

		[Description("Initial bulk density (TRIT_BDEN)")]
		public virtual double BDensity { get; set; }

		[Description("Initial dry density (TRIT_DDEN)")]
		public virtual double DDensity { get; set; }

		[Description("Axial strain at failure (TRIT_STRN)")]
		public virtual double AxialStrain { get; set; }

		/***************************************************/
	}
}





