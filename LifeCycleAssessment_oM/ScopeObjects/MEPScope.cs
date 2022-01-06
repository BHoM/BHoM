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

using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    [Description("The MEP Scope object provides a template for expected objects to be assessed within this Life Cycle Assessments. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment")]
    public class MEPScope : BHoMObject, IScope
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Mechanical Scope provides a template for expected objects to be assessed within the MEPScope")]
        public virtual MechanicalScope MechanicalScope { get; set; } = new MechanicalScope();

        [Description("Electrical Scope provides a template for expected objects to be assessed within the MEPScope")]
        public virtual ElectricalScope ElectricalScope { get; set; } = new ElectricalScope();

        [Description("Plumbing Scope provides a template for expected objects to be assessed within the MEPScope")]
        public virtual PlumbingScope PlumbingScope { get; set; } = new PlumbingScope();

        [Description("Fire Protection Scope provides a template for expected objects to be assessed within the MEPScope")]
        public virtual FireProtectionScope FireProtectionScope { get; set; } = new FireProtectionScope();
        /***************************************************/
    }
}

