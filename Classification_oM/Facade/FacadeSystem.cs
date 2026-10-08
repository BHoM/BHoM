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

namespace BH.oM.Classification.Facade
{
    [Description("The principal construction system of a building facade or envelope.")]
    public enum FacadeSystem
    {
        Undefined,
        Bespoke,
        [DisplayText("Cavity wall")]
        CavityWall,
        [DisplayText("Curtain wall")]
        CurtainWall,
        [DisplayText("Green wall")]
        GreenWalls,
        Precast,
        Rainscreen,
        [DisplayText("Retained existing façade")]
        RetainedExistingFacade,
        [DisplayText("Sandwich panels")]
        SandwichPanels,
        [DisplayText("Structural glazing")]
        StructuralGlazing,
        [DisplayText("Window wall")]
        WindowWall,
        Other,
    }
}
