/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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

namespace BH.oM.LifeCycleAssessment
{
    public enum Module
    {
        [Description(ModuleDescriptions.A0)]
        A0,
        [Description(ModuleDescriptions.A1)]
        A1,
        [Description(ModuleDescriptions.A2)]
        A2,
        [Description(ModuleDescriptions.A3)]
        A3,
        [Description(ModuleDescriptions.A1toA3)]
        A1toA3,
        [Description(ModuleDescriptions.A4)]
        A4,
        [Description(ModuleDescriptions.A5)]
        A5,
        [Description(ModuleDescriptions.A5_1)]
        A5_1,
        [Description(ModuleDescriptions.A5_2)]
        A5_2,
        [Description(ModuleDescriptions.A5_3)]
        A5_3,
        [Description(ModuleDescriptions.A5_4)]
        A5_4,
        [Description(ModuleDescriptions.B1)]
        B1,
        [Description(ModuleDescriptions.B1_1)]
        B1_1,
        [Description(ModuleDescriptions.B1_2)]
        B1_2,
        [Description(ModuleDescriptions.B2)]
        B2,
        [Description(ModuleDescriptions.B3)]
        B3,
        [Description(ModuleDescriptions.B1toB3)]
        B1toB3,
        [Description(ModuleDescriptions.B4)]
        B4,
        [Description(ModuleDescriptions.B4_1)]
        B4_1,
        [Description(ModuleDescriptions.B4_2)]
        B4_2,
        [Description(ModuleDescriptions.B5)]
        B5,
        [Description(ModuleDescriptions.B4toB5)]
        B4toB5,
        [Description(ModuleDescriptions.B1toB5)]
        B1toB5,
        [Description(ModuleDescriptions.B6)]
        B6,
        [Description(ModuleDescriptions.B7)]
        B7,
        [Description(ModuleDescriptions.B1toB7)]
        B1toB7,
        [Description(ModuleDescriptions.B7_1)]
        B7_1,
        [Description(ModuleDescriptions.B7_2)]
        B7_2,
        [Description(ModuleDescriptions.B7_3)]
        B7_3,
        [Description(ModuleDescriptions.B8)]
        B8,
        [Description(ModuleDescriptions.B8_1)]
        B8_1,
        [Description(ModuleDescriptions.B8_2)]
        B8_2,
        [Description(ModuleDescriptions.B8_3)]
        B8_3,
        [Description(ModuleDescriptions.C1)]
        C1,
        [Description(ModuleDescriptions.C2)]
        C2,
        [Description(ModuleDescriptions.C3)]
        C3,
        [Description(ModuleDescriptions.C4)]
        C4,
        [Description(ModuleDescriptions.C3toC4)]
        C3toC4,
        [Description(ModuleDescriptions.C1toC4)]
        C1toC4,
        [Description(ModuleDescriptions.D)]
        D,
        [Description(ModuleDescriptions.D_1)]
        D_1,
        [Description(ModuleDescriptions.D_2)]
        D_2,
    }
}





