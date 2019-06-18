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
using BH.oM.Environment.Fragments;

namespace BH.oM.Environment.Gains
{
    public class Profile : BHoMObject, IEnvironmentObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ProfileType ProfileType { get; set; } = ProfileType.Undefined;

        public double MultiplicationFactor { get; set; } = 1.0;
        public double SetBackValue { get; set; } = 0.0; //Value for those outside the schedule

        public string Function { get; set; } = ""; //Function built query defined as a string within simulation

        public List<double> Values { get; set; } = new List<double>(); //List of values for each hour of simulation under hourly profile or hours in a year for yearly profile

        public ProfileCategory Category { get; set; } = ProfileCategory.Undefined;

        /***************************************************/
    }
}
