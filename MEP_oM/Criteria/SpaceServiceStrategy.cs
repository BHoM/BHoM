/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

namespace BH.oM.MEP.Criteria
{
    [Description("Defines the intended HVAC service strategies for a space. It does not assign service groups or equipment.")]
    public class SpaceServiceStrategy : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Intended outdoor-air provision. Unspecified means no value is defined here; when used as a space override, the SpaceType default is inherited.")]
        public virtual OutdoorAirStrategy OutdoorAirStrategy { get; set; }
            = OutdoorAirStrategy.Unspecified;

        [Description("Intended cooling strategy. Unspecified inherits the SpaceType default when used as a space override. NoneRequired explicitly states that cooling is not required.")]
        public virtual CoolingStrategy CoolingStrategy { get; set; }
            = CoolingStrategy.Unspecified;

        [Description("Intended heating strategy. Unspecified inherits the SpaceType default when used as a space override. NoneRequired explicitly states that heating is not required.")]
        public virtual HeatingStrategy HeatingStrategy { get; set; }
            = HeatingStrategy.Unspecified;

        [Description("Intended mechanical extract provision. Unspecified inherits the SpaceType default when used as a space override.")]
        public virtual ExtractStrategy ExtractStrategy { get; set; }
            = ExtractStrategy.Unspecified;

        /***************************************************/
    }
}