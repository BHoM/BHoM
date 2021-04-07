/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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

        [Description("Closed Polyline defining the Spectators Cone of Vision. This is the boundary of the near clipping plane of the viewing frustum. Default value is a 0.115 * 0.115 square 0.1 from the eye reference location. ")]
        public virtual Polyline EffectiveConeOfVision { get; set; } = new Polyline();

        [Description("Calculate proportion of playing area obstructed by heads of Spectators in front. Default value is false")]
        public virtual bool CalculateOcclusion { get; set; } =  false;

        [Description("Distance from eye reference point to the plane where the Avalue is calculated.")]
        public virtual double EyeFrameDist { get; set; } = 0.1;

        [Description("The distance from a spectator to the far clipping plane of their view frustum. Spectators in front of this plane will not be used in the Cvalue calculation.")]
        public virtual double FarClippingPlaneDistance { get; set; } = 1.0;

        [Description("Spectator view cone angle in radians. Default is approximately 2.0944 radians or 120 degrees. Field of view for a spectator, within which spectators in front are consider to be effectively blocking the view and used for the Cvalue calcualtion. ")]
        public virtual double ViewConeAngle { get; set; } = Math.PI * 2 / 3;

        /***************************************************/
    }
}


