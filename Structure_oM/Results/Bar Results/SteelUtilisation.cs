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
    public class SteelUtilisation : BarResult
    {

        public virtual string MajorEffectiveLength { get; }

        public virtual string MinorEffectiveLength { get; }


        public virtual int SteelClass { get; }

        /// <summary>
        /// EC: EN1993-1-1: 6.2.3 and 6.2.4
        /// </summary>
        public virtual double TensionCompressionRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public virtual double MajorShearRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public virtual double MinorShearRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public virtual double TorsionRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public virtual double MajorTorsionShearRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public virtual double MinorTorsionShearRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public virtual double MajorBendingRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public virtual double MinorBendingRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public virtual double MajorBendingAxialRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public virtual double MinorBendingAxialRatio { get; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public virtual double BiaxialBendingAxialRatio { get; }

        /// <summary>
        /// Buckling resistance.
        /// EC: EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double MajorUniformCompressionRatio { get; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.1
        /// </summary>
        public virtual double MinorUniformCompressionRatio { get; }

        /// <summary>
        /// Buckling resistance. Lateral torsional buckling
        /// EC:  EN1993-1-1: 6.3.2
        /// </summary>
        public virtual double UniformBendingRatio { get; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public virtual double MajorUniformBendingCompressionRatio { get; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public virtual double MinorUniformBendingCompressionRatio { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SteelUtilisation(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double position, int divisions,
                                string majorEffectiveLength,
                                string minorEffectiveLength,
                                int steelClass,
                                double tensionCompressionRatio,
                                double majorShearRatio,
                                double minorShearRatio,
                                double torsionRatio,
                                double majorTorsionShearRatio,
                                double minorTorsionShearRatio,
                                double majorBendingRatio,
                                double minorBendingRatio,
                                double majorBendingAxialRatio,
                                double minorBendingAxialRatio,
                                double biaxialBendingAxialRatio,
                                double majorUniformCompressionRatio,
                                double minorUniformCompressionRatio,
                                double uniformBendingRatio,
                                double majorUniformBendingCompressionRatio,
                                double minorUniformBendingCompressionRatio)
            : base(objectId, resultCase, modeNumber, timeStep, position, divisions)
        {
            MajorEffectiveLength = majorEffectiveLength;
            MinorEffectiveLength = minorEffectiveLength;
            SteelClass = steelClass;
            TensionCompressionRatio = tensionCompressionRatio;
            MajorShearRatio = majorShearRatio;
            MinorShearRatio = minorShearRatio;
            TorsionRatio = torsionRatio;
            MajorTorsionShearRatio = majorTorsionShearRatio;
            MinorTorsionShearRatio = minorTorsionShearRatio;
            MajorBendingRatio = majorBendingRatio;
            MinorBendingRatio = minorBendingRatio;
            MajorBendingAxialRatio = majorBendingAxialRatio;
            MinorBendingAxialRatio = minorBendingAxialRatio;
            BiaxialBendingAxialRatio = biaxialBendingAxialRatio;
            MajorUniformCompressionRatio = majorUniformCompressionRatio;
            MinorUniformCompressionRatio = minorUniformCompressionRatio;
            UniformBendingRatio = uniformBendingRatio;
            MajorUniformBendingCompressionRatio = majorUniformBendingCompressionRatio;
            MinorUniformBendingCompressionRatio = minorUniformBendingCompressionRatio;

        }

        /***************************************************/

    }
}


