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

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.Classification.Structure
{
    [Description("The seismic zone of a site: No for no seismic zoning, then Zone 1 to Zone 4 with Zone 2 split into 2A and 2B.")]
    public enum SeismicZone
    {
        Undefined,
        No,
        [DisplayText("Zone 1")]
        Zone1,
        [DisplayText("Zone 2A")]
        Zone2A,
        [DisplayText("Zone 2B")]
        Zone2B,
        [DisplayText("Zone 3")]
        Zone3,
        [DisplayText("Zone 4")]
        Zone4,
    }
}
