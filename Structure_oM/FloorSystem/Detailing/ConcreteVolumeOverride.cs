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

using BH.oM.Base;
using BH.oM.Base.Attributes;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Overrides the concrete volume per unit area of a slab on deck, instead of calculating it from the slab properties. The volume of the deck is still calculated from the slab on deck properties.")]
    [Targets(typeof(SlabOnDeck))]
    public class ConcreteVolumeOverride : IFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Volume of concrete per unit area of the slab. Replaces the concrete volume otherwise derived from the slab on deck properties.")]
        [Length]
        public virtual double VolumePerArea { get; set; }

        /***************************************************/
    }
}
