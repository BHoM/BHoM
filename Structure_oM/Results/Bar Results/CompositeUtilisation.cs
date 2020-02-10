/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

namespace BH.oM.Structure.Results
{
    public class CompositeUtilisation : BarResult
    { 
        public string MinorEffectiveLength { get; set; }

        public string MajorEffectiveLength { get; set; }

        public int SteelClass { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double TemsionCompressionRatio { get; set; }

        /// <summary>
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public double MinorBendingRatio { get; set; }

        /// <summary>
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public double MajorBendingRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double MinorBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double MajorBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7.3
        /// </summary>
        public double BiaxialBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public double MinorShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public double MajorShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public double MinorBendingShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public double MajorBendingShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.4
        /// </summary>
        public double CompressionBucklingRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC: EN1993-1-1: 6.3.1
        /// </summary>
        public double BendingBucklingRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.1
        /// </summary>
        public double BendingCompressionBucklingRatio { get; set; }


    }
}

