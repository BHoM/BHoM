/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Geometry.CoordinateSystem;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;
using System;

namespace BH.oM.Ground
{


	[Description("A representation of a test sample defined by the depth of the sample and the name of the test.")]
	public interface ITest : IBHoMObject
	{
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Location identifier relating the borehole to the strata (LOCA_ID).")]
		string Id { get; set; }

		[Length]
		[Description("Depth to the top of the sample, measured from the top of the borehole (ISPT_TOP, IVAN_DEPTH, SAMP_TOP).")]
		double Top { get; set; }

		[Description("Name of Test (LBST_TEST).")]
		string LabTest { get; set; }

		[Description("A list of different properties including references, tests, analysis, results and detection.")]
		List<ITestProperties> ITestProperties { get; set; }


		/***************************************************/
	}
}
