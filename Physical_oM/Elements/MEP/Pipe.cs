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
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Physical.ConduitProperties;
using BH.oM.Physical.Elements;

namespace BH.oM.Physical.Elements
{
    [Description("A pipe object is a passageway which conveys material (water, waste, glycol)")]
    public class Pipe : BHoMObject, IConduitElement
    {
        /***************************************************/
        /**** Physical Only Properties                   ****/
        /***************************************************/

        public virtual ICurve Location { get; set; } = new Polyline();
        public virtual IConduitElementProperty Property { get; set; } = null;

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The volume of fluid being conveyed by the pipe per second (m3/s).")]
        public virtual double FlowRate { get; set; } = 0;

        [Description("The pipe section property defines the shape and its associated properties (radius, material, thickness).")]
        public virtual PipeSectionProperty SectionProperty { get; set; } = null;

        /***************************************************/
    }
}

