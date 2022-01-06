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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Security.Enums;
using BH.oM.Geometry;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Security.Elements
{
    [Description("A camera object is a electronic security device typically used in closed-circuit television (CCTV) systems.")]
    public class CameraDevice : BHoMObject, IElement0D, IElementM
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("The point at which the Camera is installed, known as the eye position.")]
        public virtual Point EyePosition { get; set; } = new Point();

        [Description("The point at which the Camera is looking at, known as the target position.")]
        public virtual Point TargetPosition { get; set; } = new Point();
        
        [Length]
        [Description("The horizontal field of view of the Camera, known as the real-world width length of what the camera views.")]
        public virtual double HorizontalFieldOfView { get; set; } = 0;               

        [Description("The Camera mounting type that describes how it's installed.")]
        public virtual MountingType Mounting { get; set; } = MountingType.Undefined;

        [Description("The Camera type that describes its characteristics.")]
        public virtual CameraType Type { get; set; } = CameraType.Undefined;        

        [Description("The Camera megapixels that determines its image quality.")]
        public virtual double Megapixels { get; set; } = 0;

        /***************************************************/
    }
}


