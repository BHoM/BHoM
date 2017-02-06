using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
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

        public string EffectiveLength
        {
            get
            {
                return (string)Data[4];
            }
            set
            {
                Data[4] = value;
            }
        }


        public int ForcePosition
        {
            get
            {
                return (int)Data[5];
            }
            set
            {
                Data[5] = value;
            }
        }
        public int SteelClass
        {
            get
            {
                return (int)Data[6];
            }
            set
            {
                Data[6] = value;
            }
        }


        /// <summary>
        ///  EC: EN1993-1-1: 6.6
        /// </summary>
        public double ShearConnectionRatio
        {
            get
            {
                return (double)Data[11];
            }
            set
            {
                Data[11] = value;
            }
        }

        /// <summary>
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public double BendingRatio
        {
            get
            {
                return (double)Data[7];
            }
            set
            {
                Data[7] = value;
            }
        }

        /// <summary>
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public double BendingShearRatio
        {
            get
            {
                return (double)Data[8];
            }
            set
            {
                Data[8] = value;
            }
        }

        /// <summary>
        ///  EC: EN1994-1-1: 6.4
        /// </summary>
        public double LateralTorisionBucklingRatio
        {
            get
            {
                return (double)Data[9];
            }
            set
            {
                Data[9] = value;
            }
        }


        /// <summary>
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public double LateralForceRatio
        {
            get
            {
                return (double)Data[10];
            }
            set
            {
                Data[10] = value;
            }
        }


        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double CompressionRatio
        {
            get
            {
                return (double)Data[12];
            }
            set
            {
                Data[12] = value;
            }
        }


        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double MajorBendingAxialRatio
        {
            get
            {
                return (double)Data[15];
            }
            set
            {
                Data[15] = value;
            }
        }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double MinorBendingAxialRatio
        {
            get
            {
                return (double)Data[16];
            }
            set
            {
                Data[16] = value;
            }
        }

        /// <summary>
        ///  EC: EN1994-1-1: 6.7.3
        /// </summary>
        public double BiaxialBendingAxialRatio
        {
            get
            {
                return (double)Data[17];
            }
            set
            {
                Data[17] = value;
            }
        }

        /// <summary>
        /// Buckling resistance.
        /// EC: EN1993-1-1: 6.3.1
        /// </summary>
        public double MajorUniformCompressionRatio
        {
            get
            {
                return (double)Data[18];
            }
            set
            {
                Data[18] = value;
            }
        }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.1
        /// </summary>
        public double MinorUniformCompressionRatio
        {
            get
            {
                return (double)Data[19];
            }
            set
            {
                Data[19] = value;
            }
        }

        /// <summary>
        /// Buckling resistance. Lateral torsional buckling
        /// EC:  EN1993-1-1: 6.3.2
        /// </summary>
        public double UniformBendingRatio
        {
            get
            {
                return (double)Data[20];
            }
            set
            {
                Data[20] = value;
            }
        }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public double MajorUniformBendingCompressionRatio
        {
            get
            {
                return (double)Data[21];
            }
            set
            {
                Data[21] = value;
            }
        }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public double MinorUniformBendingCompressionRatio
        {
            get
            {
                return (double)Data[22];
            }
            set
            {
                Data[22] = value;
            }
        }


        public CompositeUtilisation()
        {
            Data = new object[23];
        }

        public CompositeUtilisation(TName number, TLoadcase loadcase, TTimeStep timeStep) : this()
        {
            Name = number;
            Loadcase = loadcase;
            TimeStep = timeStep;
            Id = number + ":" + loadcase + ":" + timeStep;
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.Utilisation;
            }
        }

        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] {
                    "Id",
                    "Name",
                    "Loadcase",
                    "TimeStep",
                    "EffectiveLength",
                    "ForcePosition",
                    "Class",
                    "TensionCompressionRatio",
                    "MajorShearRatio",
                    "MinorShearRatio",
                    "TorsionRatio",
                    "MajorTorsionShearRatio",
                    "MinorTorsionShearRatio",
                    "MajorBendingRatio",
                    "MinorBendingRatio",
                    "MajorBendingAxialRatio",
                    "MinorBendingAxialRatio",
                    "BiaxialBendingAxialRatio",
                    "MajorUniformCompressionRatio",
                    "MinorUniformCompressionRatio",
                    "UniformBendingRatio",
                    "MajorUniformBendingCompressionRatio",
                    "MinorUniformBendingCompressionRatio",
                };
            }
        }
    }

}
