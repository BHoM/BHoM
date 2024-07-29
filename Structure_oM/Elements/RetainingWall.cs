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
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Elements
{
    public class RetainingWall : BHoMObject, IElementM //Question if this should be a bhomobject or a compisiteobject. Cant be both. Settled on BHoMObject for now.
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Stem of the retaining wall.")]
        public virtual Stem Stem { get; set; } = new Stem();

        [Description("Footing of the retaining wall.")]
        public virtual Footing Footing { get; set; } = new Footing();

        [Description("The retained height of soil measured from the bottom of the wall Footing.")]
        public virtual double RetainedHeight { get; set; } = 0.0;

        [Description("The distance from top of Footing to finished floor level on the exposed face.")]
        public virtual double CoverDepth { get; set; } = 0.0;

        [Description("The distance from the base of the Footing to ground water level.")]
        public virtual double GroundWaterDepth { get; set; } = 0.0;

        [Angle]
        [Description("A property of the material being retained measured from the horizontal plane.")] 
        public virtual double RetentionAngle { get; set; } = 0.0;

        /***************************************************/
    }
}