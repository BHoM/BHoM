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
    [Description("The principal material of a building facade.")]
    public enum FacadeMaterial
    {
        Undefined,
        Aluminium,
        Brick,
        [DisplayText("Ceramic / Terracotta")]
        CeramicOrTerracotta,
        [DisplayText("Composite metal panel")]
        CompositeMetalPanel,
        [DisplayText("Engineered Stone")]
        EngineeredStone,
        [DisplayText("Fibre Reinforced Concrete")]
        FibreReinforcedConcrete,
        [DisplayText("Fibre Reinforced Plastic")]
        FibreReinforcedPlastic,
        Glass,
        [DisplayText("In-situ cast concrete")]
        InsituCastConcrete,
        [DisplayText("Natural stone")]
        NaturalStone,
        [DisplayText("Precast concrete")]
        PrecastConcrete,
        Render,
        [DisplayText("Solid metal panel")]
        SolidMetalPanel,
        Timber,
        [DisplayText("Ultra high performance concrete")]
        UltraHighPerformanceConcrete,
        Other,
    }
}
