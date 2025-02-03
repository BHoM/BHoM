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


using System;
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Ground
{

    [Description("Properties related to the results of the SPT test.")]
    public class SPTResultProperties : BHoMObject, ITestProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Reported SPT Result (ISPT_REP.")]
        public virtual string ReportedSPTResult { get; set; }

        [Description("Number of blows for seating drive (ISPT_SEAT).")]
        public virtual double SeatingDriveBlows { get; set; }

        [Description("Number of blows for main test drive (ISPT_MAIN).")]
		public virtual double MainTestDriveBlows { get; set; }

        [Description("SPT N value corrected by energy ration (ISPT_N60).")]
        public virtual double SPTN60 { get; set; }

        [Length]
        [Description("Total Penetration for seating drive and test drive (ISPT_NPEN).")]
		public virtual double TotalPenetration { get; set; }

        [Length]
        [Description("Self weight penetration (ISPT_SWP).")]
        public virtual double SelfWeightPenetration { get; set; }

        [Description("Number of Blows for 1st Increment Seating (ISPT_INC1).")]
        public virtual double NBlowsA { get; set; }

        [Description("Number of Blows for 2nd Increment Seating (ISPT_INC2).")]
        public virtual double NBlowsB { get; set; }

        [Description("Number of Blows for 1st Increment Test (ISPT_INC3).")]
		public virtual double NBlows1 { get; set; }

		[Description("Number of Blows for 2nd Increment Test (ISPT_INC4).")]
		public virtual double NBlows2 { get; set; }

		[Description("Number of Blows for 3rd Increment Test (ISPT_INC5).")]
		public virtual double NBlows3 { get; set; }

		[Description("Number of Blows for 4th Increment Test (ISPT_INC6).")]
		public virtual double NBlows4 { get; set; }

        [Length]
        [Description("Penetration for 1st Increment Seating (ISPT_PEN1).")]
        public virtual double PenetrationA { get; set; }

        [Length]
        [Description("Penetration for 2nd Increment Seating (ISPT_INC2).")]
        public virtual double PenatrationB { get; set; }

        [Length]
        [Description("Penetration for 1st Increment Test (ISPT_PEN3).")]
		public virtual double Penetration1 { get; set; }

        [Length]
        [Description("Penetration for 2nd Increment Test (ISPT_PEN4).")]
		public virtual double Penetration2 { get; set; }

        [Length]
        [Description("Penetration for 3rd Increment Test (ISPT_PEN5).")]
		public virtual double Penetration3 { get; set; }

        [Length]
        [Description("Penetration for 4th Increment Test (ISPT_PEN6).")]
		public virtual double Penetration4 { get; set; }


		/***************************************************/
	}
}
