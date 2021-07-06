/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Physical.Elements;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Physical.Reinforcement
{
    [Description("Set representing a list of physical reinforcing bars.")]
    public class ExplicitRebarSet : BHoMObject, IRebarSet
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Main function of reinforcement in the set.")]
        public ReinforcementFunction Function { get; set; } = ReinforcementFunction.Undefined;

        [Description("List of physical reinforcing bars.")]
        public List<IReinforcingBar> PhysicalBars { get; set; } = new List<IReinforcingBar>();

        /***************************************************/
    }
}
