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

namespace BH.oM.Ground
{

    [Description("Details for the location of the borehole including project references, phasing and location algorithms.")]
    public class Location : BHoMObject, IBoreholeProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Method of location (LOCA_LOCM).")]
        public virtual string Method { get; set; } = "";

        [Description("Site location sub division (within project) code or description (LOCA_LOCA).")]
        public virtual string SubDivision { get; set; } = "";

        [Description("Investigation phase grouping code or description (LOCA_CLST).")]
        public virtual string Phase { get; set; } = "";

        [Description("Alignment identifier (LOCA_ALID).")]
        public virtual string Alignment { get; set; } = "";

        [Description("Offset from the alignment (LOCA_OFFS).")]
        public virtual double Offset { get; set; } = double.NaN;

        [Description("Chainage relating to the project (LOCA_CNGE).")]
        public virtual string Chainage { get; set; } = "";

        [Description("Reference to details of algorithm used to calculate local grid reference, local ground levels or chainage (LOCA_TRAN).")]
        public virtual string Algorithm { get; set; } = "";

        /***************************************************/
    }
}
