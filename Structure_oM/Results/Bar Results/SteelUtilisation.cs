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
    public class SteelUtilisation : BarResult
    { 

        public virtual string MajorEffectiveLength { get; set; }

        public virtual string MinorEffectiveLength { get; set; }


        public virtual int Class { get; set; }

        /// <summary>
        /// EC: EN1993-1-1: 6.2.3 and 6.2.4
        /// </summary>
        public virtual double TensionCompressionRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public virtual double MajorShearRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public virtual double MinorShearRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public virtual double TorsionRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public virtual double MajorTorsionShearRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public virtual double MinorTorsionShearRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public virtual double MajorBendingRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public virtual double MinorBendingRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public virtual double MajorBendingAxialRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public virtual double MinorBendingAxialRatio { get; set; }
        
        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public virtual double BiaxialBendingAxialRatio { get; set; }
        
        /// <summary>
        /// Buckling resistance.
        /// EC: EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double MajorUniformCompressionRatio { get; set; }
        
        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double MinorUniformCompressionRatio { get; set; }
        
        /// <summary>
        /// Buckling resistance. Lateral torsional buckling
        /// EC:  EN1993-1-1: 6.3.2
        /// </summary>
        public virtual double UniformBendingRatio { get; set; }
        
        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public virtual double MajorUniformBendingCompressionRatio { get; set; }
        
        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public virtual double MinorUniformBendingCompressionRatio { get; set; }

    }

}
