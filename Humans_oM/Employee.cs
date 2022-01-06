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

using BH.oM.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Humans
{
    public class Employee : BHoMObject, IHumanRole
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Company the Employee works for.")]
        public virtual string Company { get; set; }

        [Description("Office assigned to the Employee.")]
        public virtual string Office { get; set; }

        [Description("Discipline the Employee works in.")]
        public virtual string Discipline { get; set; }

        [Description("Team the Employee belongs to.")]
        public virtual string Team { get; set; }

        [Description("Manager of the Employee.")]
        public virtual Employee Manager { get; set; }

        [Description("Seniority of the Employee.")]
        public virtual string Grade { get; set; }

        [Description("Company email of the Employee.")]
        public virtual string Email { get; set; }

        [Description("Company phone number of the Employee.")]
        public virtual string Phone { get; set; }

        public virtual string CodeDevelopmentRole { get; set; }

        [Description("Business Unit the Employee is assigned to.")]
        public virtual string BusinessUnit { get; set; }

        /***************************************************/
    }

}






