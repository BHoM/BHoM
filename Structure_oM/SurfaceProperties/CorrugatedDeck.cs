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
using BH.oM.Structure.MaterialFragments;
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.SurfaceProperties
{
    [Description("Property for 2D analytical elements representing a slab on a corrugated deck. Generally used to represent concrete on metal deck.")]
    public class CorrugatedDeck : BHoMObject, ISurfaceProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Description("The primary material for the SurfaceProperty.")]
        public virtual IMaterialFragment Material { get; set; }

        [Description("Specifies if the ribs are running in local x or y direction.")]
        public virtual PanelDirection Direction { get; set; } = PanelDirection.X;

        [Length]
        [Description("Nominal height of the metal deck, from top flute to bottom flute.")]
        public virtual double Height { get; set; }

        [Length]
        [Description("Centre-centre distance between the ribs. Measured perpendicular to the rib direction." +
            " If this length is greater to the sum of BottomWidth and TopWidth, the deck is trapezoidal." +
            " If lesser, the deck has a dovetail shape.")]
        public virtual double Spacing { get; set; }

        [Length]
        [Description("Width of bottom flute.")]
        public virtual double BottomWidth { get; set; }

        [Length]
        [Description("Width of the top flute.")]
        public virtual double TopWidth { get; set; }

        [Length]
        [Description("Thickness of the decking stock.")]
        public virtual double Thickness { get; set; }

        [Description("The ratio between the actual volume of deck material in a given panel and the value calculated as Thickness * area of the panel.")]
        public virtual double VolumeFactor { get; set; }

        [Description("Defines what type of element this property will be used. Used by some analysis packages.")]
        public virtual PanelType PanelType { get; set; } = PanelType.Slab;

        /***************************************************/
    }
}



