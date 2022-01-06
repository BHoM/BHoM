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


using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Physical.Materials;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Physical.Reinforcement
{
    [Description("Defining shear reinforcement for framing elements.")]
    public class Stirrup : BHoMObject, IReinforcingBar
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Centreline of the Reinforcing bar in three-dimensional space. When the BendRadius is sufficient for any kinks in the rebar, this can be defined as a polyline, ommiting any arcs in corners.")]
        public virtual ICurve CentreCurve { get; set; }

        [Length]
        public virtual double Diameter { get; set; }

        public virtual Material Material { get; set; }

        [Length]
        [Description("Bend radius used for any discontinuities in the CentreCurve.")]
        public virtual double BendRadius { get; set; }

        /***************************************************/
    }
}

