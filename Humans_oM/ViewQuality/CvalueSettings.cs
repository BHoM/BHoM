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
using System;
using System.ComponentModel;

namespace BH.oM.Humans.ViewQuality
{
    public class CvalueSettings : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual CvalueFocalMethodEnum FocalMethod { get; set; } = CvalueFocalMethodEnum.Undefined;

        [Description("Value assigned to spectators where Cvalue cannot be calculated, for example on a front row.")]
        public virtual double DefaultCValue { get; set; } =  0;

        [Description("The distance from a spectator to the far clipping plane of their view frustum. Spectators in front of this plane will not be used in the Cvalue calculation.")]
        public virtual double FarClippingPlaneDistance  { get; set; } =  2;

        [Description("Spectator view cone angle in radians. Default is approximately 2.0944 radians or 120 degrees. Field of view for a spectator, within which spectators in front are consider to be effectively blocking the view and used for the Cvalue calcualtion. ")]
        public virtual double ViewConeAngle { get; set; } = Math.PI * 2/3;

        /***************************************************/
    }
}



