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
using BH.oM.Reflection.Attributes;

namespace BH.oM.Structure.Results
{
    [NotImplemented]
    public class CompositeUtilisation : BarResult
    { 
        public virtual string MinorEffectiveLength { get; set; }

        public virtual string MajorEffectiveLength { get; set; }

        public virtual int SteelClass { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public virtual double TemsionCompressionRatio { get; set; }

        /// <summary>
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public virtual double MinorBendingRatio { get; set; }

        /// <summary>
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public virtual double MajorBendingRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public virtual double MinorBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public virtual double MajorBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7.3
        /// </summary>
        public virtual double BiaxialBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public virtual double MinorShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public virtual double MajorShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public virtual double MinorBendingShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public virtual double MajorBendingShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.4
        /// </summary>
        public virtual double CompressionBucklingRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC: EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double BendingBucklingRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double BendingCompressionBucklingRatio { get; set; }


    }
}

