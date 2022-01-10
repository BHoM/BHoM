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

using System;
using BH.oM.Base.Attributes;

namespace BH.oM.Structure.Results
{
    [NotImplemented]
    public class CompositeUtilisation : BarResult
    {
        public virtual string MinorEffectiveLength { get; }

        public virtual string MajorEffectiveLength { get; }

        public virtual int SteelClass { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public virtual double TensionCompressionRatio { get; }

        /// <summary>
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public virtual double MinorBendingRatio { get; }

        /// <summary>
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public virtual double MajorBendingRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public virtual double MinorBendingAxialRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public virtual double MajorBendingAxialRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7.3
        /// </summary>
        public virtual double BiaxialBendingAxialRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public virtual double MinorShearRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public virtual double MajorShearRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public virtual double MinorBendingShearRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public virtual double MajorBendingShearRatio { get; }

        /// <summary>
        ///  EC: EN1994-1-1: 6.4
        /// </summary>
        public virtual double CompressionBucklingRatio { get; }

        /// <summary>
        /// Buckling resistance.
        /// EC: EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double BendingBucklingRatio { get; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double BendingCompressionBucklingRatio { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public CompositeUtilisation(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double position, int divisions,
                                string minorEffectiveLength,
                                string majorEffectiveLength,
                                int steelClass,
                                double tensionCompressionRatio,
                                double minorBendingRatio,
                                double majorBendingRatio,
                                double minorBendingAxialRatio,
                                double majorBendingAxialRatio,
                                double biaxialBendingAxialRatio,
                                double minorShearRatio,
                                double majorShearRatio,
                                double minorBendingShearRatio,
                                double majorBendingShearRatio,
                                double compressionBucklingRatio,
                                double bendingBucklingRatio,
                                double bendingCompressionBucklingRatio)
            : base(objectId, resultCase, modeNumber, timeStep, position, divisions)
        {
            MinorEffectiveLength = minorEffectiveLength;
            MajorEffectiveLength = majorEffectiveLength;
            SteelClass = steelClass;
            TensionCompressionRatio = tensionCompressionRatio;
            MinorBendingRatio = minorBendingRatio;
            MajorBendingRatio = majorBendingRatio;
            MinorBendingAxialRatio = minorBendingAxialRatio;
            MajorBendingAxialRatio = majorBendingAxialRatio;
            BiaxialBendingAxialRatio = biaxialBendingAxialRatio;
            MinorShearRatio = minorShearRatio;
            MajorShearRatio = majorShearRatio;
            MinorBendingShearRatio = minorBendingShearRatio;
            MajorBendingShearRatio = majorBendingShearRatio;
            CompressionBucklingRatio = compressionBucklingRatio;
            BendingBucklingRatio = bendingBucklingRatio;
            BendingCompressionBucklingRatio = bendingCompressionBucklingRatio;
        }

        /***************************************************/
    }
}



