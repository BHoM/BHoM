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
using BH.oM.Geometry;
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Humans.ViewQuality
{
    public class Avalue : ViewQualityResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Percentage of the cone of vision occupied by the clipped activity area.")]
        public virtual double AValue { get; set; } = 0.0;

        [Description("Percentage of the cone of vision occupied by heads occluding the activity area.")]
        public virtual double Occulsion { get; set; } = 0.0;

        [Description("Activity area projected to the spectator's viewing plane.")]
        public virtual Polyline FullActivityArea { get; set; } = new Polyline();

        [Description("Resulting Polyline after clipping the full activity area with the cone of vision.")]
        public virtual Polyline ClippedActivityArea { get; set; } = new Polyline();

        [Description("Effective cone of vision orientated to the spectator.")]
        public virtual Polyline ConeOfVision { get; set; } = new Polyline();

        [Description("Point representing the spectator's singular eye reference.")]
        public virtual Point ReferencePoint { get; set; } = new Point();

        [Description("Polylines of the spectator heads occluding the view of the activity area.")]
        public virtual List<Polyline> OccludingHeads { get; set; } = new List<Polyline>();

        /***************************************************/
    }
}
