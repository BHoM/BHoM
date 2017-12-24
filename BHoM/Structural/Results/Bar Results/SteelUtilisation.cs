using BH.oM.Structural.Properties;
using BH.oM.Structural.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{

    [Serializable]
    public class SteelUtilisation : SteelUtilisation<string, string, string>
    {
        public SteelUtilisation() : base()
        { }

        public SteelUtilisation(string number, string loadcase, string timeStep) : base(number, loadcase, timeStep)
        { }
    }


    [Serializable]
    public class SteelUtilisation<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public string MajorEffectiveLength { get; set; }

        public string MinorEffectiveLength { get; set; }


        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public int ForcePosition { get; set; }

        public int Class { get; set; }

        /// <summary>
        /// EC: EN1993-1-1: 6.2.3 and 6.2.4
        /// </summary>
        public double TensionCompressionRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public double MajorShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public double MinorShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public double TorsionRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public double MajorTorsionShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public double MinorTorsionShearRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public double MajorBendingRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public double MinorBendingRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public double MajorBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public double MinorBendingAxialRatio { get; set; }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public double BiaxialBendingAxialRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC: EN1993-1-1: 6.3.1
        /// </summary>
        public double MajorUniformCompressionRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.1
        /// </summary>
        public double MinorUniformCompressionRatio { get; set; }

        /// <summary>
        /// Buckling resistance. Lateral torsional buckling
        /// EC:  EN1993-1-1: 6.3.2
        /// </summary>
        public double UniformBendingRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public double MajorUniformBendingCompressionRatio { get; set; }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public double MinorUniformBendingCompressionRatio { get; set; }


        public SteelUtilisation()
        { }

        public SteelUtilisation(TName number, TLoadcase loadcase, TTimeStep timeStep) : this()
        {
            Name = number;
            Loadcase = loadcase;
            TimeStep = timeStep;
            Id = number + ":" + loadcase + ":" + timeStep;
        }
    }

}