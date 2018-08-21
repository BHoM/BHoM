﻿using System;

namespace BH.oM.Structural.Results
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
