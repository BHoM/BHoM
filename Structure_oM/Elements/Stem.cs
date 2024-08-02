/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.MaterialFragments;

namespace BH.oM.Structure.Elements
{
    public class Stem : BHoMObject, IElement2D, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Planar curve defining the edges at center of the stem.")]
        public virtual PolyCurve Outline { get; set; }

        [Description("Thickness at the top of the stem.")]
        public virtual double ThicknessTop { get; set; }

        [Description("Thickness at the bottom of the stem.")]
        public virtual double ThicknessBottom { get; set; }

        [Description("Normal to the surface of the stem denoting the direction of the retained face.")]
        public virtual Vector Normal { get; set; }

        [Description("Structural material of the property.")]
        public virtual IMaterialFragment Material { get; set; } = null;


        /***************************************************/

    }
}
