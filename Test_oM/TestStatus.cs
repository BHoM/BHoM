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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Test
{
    [Description("Defines the status of the Test Information. Designed to be very clear, concrete statuses, with minimal ambiguity.")]
    public enum TestStatus
    {
        [Description("The status is such that immediate action should be taken, and workflows should not continue further until this is addressed.")]
        Error,

        [Description("Everything is good, as close to perfect as we can get, with no further action needing to be taken.")]
        Pass,

        [Description("Something hasn't quite gone to plan, but is not sufficient enough to stop everything. It is advised to investigate further before continuing, but you can continue before addressing this.")]
        Warning,
    }
}
