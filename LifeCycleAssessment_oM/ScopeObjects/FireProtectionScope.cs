/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.MEP.Elements;

namespace BH.oM.LifeCycleAssessment
{
    [Description("Fire Protection Scope.")]
    public class FireProtectionScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Fire protection equipment used to facilitate functionality of the overall system")]
        public virtual List<IBHoMObject> Equipment { get; set; } = new List<IBHoMObject>();

        [Description("BHoM Pipes used for fire protection")]
        public virtual List<Pipe> Pipes { get; set; } = new List<Pipe>();

        [Description("Sprinklers used for fire protection throughout the building")]
        public virtual List<IBHoMObject> Sprinklers { get; set; } = new List<IBHoMObject>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled")]
        public virtual List<IBHoMObject> AdditionalObjects { get; set; } = new List<IBHoMObject>();
        /***************************************************/
    }
}
