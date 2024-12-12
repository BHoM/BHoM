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

    [Description("A set of data related to SPT tests carried out")]
    public class SPT : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
 
        [Length]
        [Description("Depth to the top of the test sample (ISPT_TOP).")]
        public virtual double Top { get; set; }

        [Description("SPT N Value (ISPT_NVAL).")]
        public virtual double N { get; set; }

        [Description("SPT Hammer Number (ISPT_HAM).")]
        public virtual string SPTHammerNumber { get; set; }

        [Description("Energy Ratio of Hammer (ISPT_ERAT).")]
        public virtual double EnergyRatio { get; set; }

        [Description("Number of blows for main test drive (ISPT_MAIN).")]
        public virtual double MainTestDrive { get; set; }

        [Description("Total Penetration for seating drive and test drive (ISPT_NPEN).")]
        public virtual double TotalPenetration { get; set; }

		[Description("Number of Blows for 1st Increment Test (ISPT_INC3).")]
		public virtual double NBlows1 { get; set; }

		[Description("Number of Blows for 2nd Increment Test (ISPT_INC4).")]
		public virtual double NBlows2 { get; set; }

		[Description("Number of Blows for 3rd Increment Test (ISPT_INC5).")]
		public virtual double NBlows3 { get; set; }

		[Description("Number of Blows for 4th Increment Test (ISPT_INC6).")]
		public virtual double NBlows4 { get; set; }

		[Description("Penetration for 1st Increment Test (ISPT_PEN3).")]
		public virtual double Penetration1 { get; set; }

		[Description("Penetration for 1st Increment Test (ISPT_PEN4).")]
		public virtual double Penetration2 { get; set; }

		[Description("Penetration for 1st Increment Test (ISPT_PEN5).")]
		public virtual double Penetration3 { get; set; }

		[Description("Penetration for 1st Increment Test (ISPT_PEN6).")]
		public virtual double Penetration4 { get; set; }



		/***************************************************/
	}
}





