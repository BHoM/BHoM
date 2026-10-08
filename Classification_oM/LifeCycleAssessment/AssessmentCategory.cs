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

namespace BH.oM.Classification.LifeCycleAssessment
{
    [Description("The impact assessment method of a life cycle assessment, and the region it applies to (e.g. CML under EN 15804+A1, PEF under EN 15804+A2, TRACI).")]
    public enum AssessmentCategory
    {
        [DisplayText("I don't know")]
        Undefined,
        [DisplayText("CML (EN15804+A1) - Europe")]
        CML,
        [DisplayText("PEF (EN15804+A2) - Europe 2022+")]
        PEF,
        [DisplayText("TRACI - North America")]
        TRACI,
        Other,
    }
}
