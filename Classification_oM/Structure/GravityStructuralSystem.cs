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
    [Description("The principal structural system resisting gravity loads in a building, leading with the material and then the construction method.")]
    public enum GravityStructuralSystem
    {
        Undefined,
        [DisplayText("Steel: Hot rolled steel")]
        Steel_HotRolledSteel,
        [DisplayText("Steel: Light gauge steel")]
        Steel_LightGaugeSteel,
        [DisplayText("Concrete: Conventional in-situ")]
        Concrete_InSitu,
        [DisplayText("Concrete: Post tension (PT)")]
        Concrete_PostTension,
        [DisplayText("Concrete: Precast")]
        Concrete_Precast,
        [DisplayText("Timber: Softwood/Hardwood")]
        Timber_SoftwoodHardwood,
        [DisplayText("Timber: Engineered timber")]
        Timber_EngineeredTimber,
        [DisplayText("Masonry: Brickwork")]
        Masonry_Brickwork,
        [DisplayText("Masonry: Concrete blockwork")]
        Masonry_ConcreteBlockwork,
        Hybrid,
        None,
        Other,
    }
}
