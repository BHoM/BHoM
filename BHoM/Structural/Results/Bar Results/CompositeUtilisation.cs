using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public class CompositeUtilisation : CompositeUtilisation<string, string, string>
    {
        public CompositeUtilisation() : base()
        { }

        public CompositeUtilisation(string number, string loadcase, string timeStep) : base(number, loadcase, timeStep)
        { }
    }


    public class CompositeUtilisation<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {

        public string MinorEffectiveLength { get; set; }

        public string MajorEffectiveLength { get; set; }

        public int ForcePosition { get; set; }

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

        public CompositeUtilisation()
        { }
        
        public CompositeUtilisation(TName number, TLoadcase loadcase, TTimeStep timeStep) : this()
        {
            Name = number;
            Loadcase = loadcase;
            TimeStep = timeStep;
            Id = number + ":" + loadcase + ":" + timeStep;
        }
    }
}
