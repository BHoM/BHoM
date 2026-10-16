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
    [Description("The type of foundation of a building, leading with the principal material and then the construction method.")]
    public enum FoundationType
    {
        Undefined,
        [DisplayText("Concrete: Pad/Footing")]
        Concrete_PadFooting,
        [DisplayText("Concrete: Mass Pads")]
        Concrete_MassPads,
        [DisplayText("Concrete: Reinforced Pads")]
        Concrete_ReinforcedPads,
        [DisplayText("Concrete: Mass + Reinforced Pads")]
        Concrete_MassAndReinforcedPads,
        [DisplayText("Concrete: Piles and Caps")]
        Concrete_PilesAndCaps,
        [DisplayText("Concrete: Piled Raft")]
        Concrete_PiledRaft,
        [DisplayText("Concrete: Raft / Mat slab")]
        Concrete_RaftMatSlab,
        [DisplayText("Steel: Driven Piles")]
        Steel_DrivenPiles,
        [DisplayText("Stone: Blocks")]
        Stone_Blocks,
        [DisplayText("Stone: Vibro Columns")]
        Stone_VibroColumns,
        [DisplayText("Timber: Driven Piles")]
        Timber_DrivenPiles,
        None,
        Other,
    }
}
