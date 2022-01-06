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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;

namespace BH.oM.LifeCycleAssessment
{
    [Description("Fire Protection Scope provides a template for expected objects to be assessed within the MEPScope")]
    public class FireProtectionScope : BHoMObject, IScope
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Fire protection equipment includes both fire and jockey pumps which convey water through the fire protection system")]
        public virtual List<IElementM> Equipment { get; set; } = new List<IElementM>();

        [Description("Distribution systems that convey fluids in the case of fire (e.g. domestic cold water).")]
        public virtual List<IElementM> Pipes { get; set; } = new List<IElementM>();

        [Description("Sprinklers are devices that release water upon the detection of a fire.")]
        public virtual List<IElementM> Sprinklers { get; set; } = new List<IElementM>();

        [Description("Tanks are containers that store water for fire protection.")]
        public virtual List<IElementM> Tanks { get; set; } = new List<IElementM>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled (e.g. fire hose valve cabinets)")]
        public virtual List<IElementM> AdditionalObjects { get; set; } = new List<IElementM>();
        /***************************************************/
    }
}


