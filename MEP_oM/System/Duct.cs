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
using BH.oM.MEP.System.SectionProperties;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Geometry;

namespace BH.oM.MEP.System
{
    [Description("A duct object is a passageway which conveys material (typically air)")]
    public class Duct : BHoMObject, IFlow
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The point at which the Duct object begins.")]
        public virtual Point StartPoint { get; set; } = null;

        [Description("The point at which the Duct object ends.")]
        public virtual Point EndPoint { get; set; } = null;

        [Description("The volume of fluid being conveyed by the Duct per second (m3/s).")]
        public virtual double FlowRate { get; set; } = 0;

        [Description("The Duct section property defines the shape (round, rectangular, ovular) and its associated properties (height, width, radius, material, thickness/gauge).")]
        public virtual DuctSectionProperty SectionProperty { get; set; } = null;

        [Angle]
        [Description("This is the Duct's planometric orientation angle (the rotation around its central axis).")]
        public virtual double OrientationAngle { get; set; } = 0;

        /***************************************************/
    }
}


