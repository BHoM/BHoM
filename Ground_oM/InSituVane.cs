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
		[Description("Top of Sample (IVAN_DPTH).")]
		public virtual double Depth { get; set; }

		[Description("Vane Test Result (IVAN_IVAN)")]
		public virtual double VaneResult { get; set; }

		[Description("Vane Test Residual Result (IVAN_IVAR)")]
		public virtual double VaneResidualResult { get; set; }

		[Description("Details of vane test, vane size (IVAN_REM)")]
		public virtual string VaneDetails { get; set; }

		[Description("Details of weather and environmental conditions during test (IVAN ENV).")]
		public virtual string VaneWeather { get; set; }

		/***************************************************/
	}
}





