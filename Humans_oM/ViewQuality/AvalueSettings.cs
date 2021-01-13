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
using System.ComponentModel;

namespace BH.oM.Humans.ViewQuality
{
    public class AvalueSettings : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual ViewConeEnum ConeType { get; set; } = ViewConeEnum.Undefined;

        public virtual bool CalculateOcclusion { get; set; } =  false;

        [Description("Distance from eye ref point to the plane where the Avalue is calculated")]
        public virtual double EyeFrameDist { get; set; } = 0.1;

        public virtual double ForeheadSize { get; set; } = 0.120;

        [Description("Radius from viewplane centre for finding nearest potentially occulding heads")]
        public virtual double NearHeadRange { get; set; } = 0.100;

        /***************************************************/
    }
}


