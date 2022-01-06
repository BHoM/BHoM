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
using BH.oM.Geometry;
using System;
using System.ComponentModel;

namespace BH.oM.Humans.ViewQuality
{
    public class AvalueSettings : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Reference Cone of Vision used for all Spectators. This is equivalent to the curve generated from the intersection of the near clipping plane and the viewing frustum." +
            "It should be planar and closed and in a plane parallel to the global XY Plane." +
            "Default value is a square based frustum with 30 degree field of view and near clipping plane 0.1 from the eye reference location. Giving a a 0.115 * 0.115 square EffectiveConeOfVision.")]
        public virtual Polyline EffectiveConeOfVision { get; set; } = new Polyline();

        [Description("The distance from a spectator to the far clipping plane of their view frustum. Spectators in front of this plane will not be used in the occlusion part of the Avalue calculation. Default value is 1.")]
        public virtual double FarClippingPlaneDistance { get; set; } = 1.0;

        [Description("Calculate proportion of playing area obstructed by heads of Spectators in front. Default value is false")]
        public virtual bool CalculateOcclusion { get; set; } = false;

        [Description("Width of default EffectiveConeOfVision. Default value is 0.115. Used only when no EffectiveConeOfVision is provided.")]
        public virtual double EffectiveConeOfVisionWidth { get; set; } = 0.115;

        [Description("Height of default EffectiveConeOfVision. Default value is 0.115. Used only when no EffectiveConeOfVision is provided.")]
        public virtual double EffectiveConeOfVisionHeight { get; set; } = 0.115;

        [Description("The distance from a spectator to the near clipping plane of their view frustum. Default value is 0.1. Used only when no EffectiveConeOfVision is provided.")]
        public virtual double NearClippingPlaneDistance { get; set; } = 0.1;

        [Description("Optional focal point to set the view direction of the spectators. If none provided the Avalue is calculated using the neutral viewing direction of each spectator.")]
        public virtual Point FocalPoint { get; set; } = null;

        /***************************************************/
    }
}
