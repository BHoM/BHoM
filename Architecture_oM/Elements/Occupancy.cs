/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using System.ComponentModel;

using BH.oM.Base;

namespace BH.oM.Architecture.Elements
{
    public class Occupancy : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The area per person is representative of the square meters each person occupies within the building or space.")]
        public virtual double AreaPerPerson { get; set; } = 0.0;

        [Description("Percentage of Females of the total occupant count of the building or space.")]
        public virtual double FemalePercentage { get; set; } = 0.5;

        [Description("Percentage of Gender Neutral of the total occupant count of the building or space.")]
        public virtual double GenderNeutralPercentage { get; set; } = 0.0;

        [Description("Percentage of Males of the total occupant count of the building or space.")]
        public virtual double MalePercentage { get; set; } = 0.5;

        [Description("The total number of people that occupy the building or space.")]
        public virtual int OccupantCount { get; set; } = 0;

        /***************************************************/
    }
}


