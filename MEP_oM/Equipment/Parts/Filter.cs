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

namespace BH.oM.MEP.Equipment.Parts
{
    [Description("Filters are devices that remove solid particles from a system")]
    public class Filter : BHoMObject, IPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Type denotes the kind of filter (eg fiberglass, pleated, HEPA, washable, etc)")]
        public virtual string Type { get; set; } = "";
        
        [Description("MERV Rating is the Minimum Efficiency Rating Value which denotes the effectiveness of the filter's ability to trap small particles)")]
        public virtual int MERVRating { get; set; } = 0;
        
        [Description("Initial pressure drop describes the pressure drop across a new (unused) filter")]
        public virtual double InitialPressureDrop { get; set; } = 0.0;
        
        [Description("Replacement pressure drop describes the pressure drop across a used filter, and indicates that the filter should be replaced")]
        public virtual double ReplacementPressureDrop { get; set; } = 0.0;
        
        [Description("Area indicates the face area of the filter in m2")]
        public virtual double Area { get; set; } = 0.0;

        /***************************************************/
    }
}



