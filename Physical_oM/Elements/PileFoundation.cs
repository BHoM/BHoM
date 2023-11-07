/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using BH.oM.Dimensional;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BH.oM.Physical.Elements
{
    [Description("A composite object representing a pile foundation. This object contains physical representations of a pile cap and collection of piles.")]
    public class PileFoundation : BHoMObject, IElementM, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The pile cap with an outline containing all of the Piles.")]
        public virtual PadFoundation PileCap { get; }

        [Description("A list of Piles contained within the extents of the PileCap.")]
        public virtual ReadOnlyCollection<Pile> Piles { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PileFoundation(PadFoundation pileCap, ReadOnlyCollection<Pile> piles)
        {
            PileCap = pileCap;
            Piles = piles;
        }

        /***************************************************/
    }
}
