using BH.oM.Structural.Properties;
using BH.oM.Structural.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{

    public class SteelUtilisation : SteelUtilisation<string, string, string>
    {
        public SteelUtilisation() : base()
        { }

        public SteelUtilisation(string number, string loadcase, string timeStep) : base(number, loadcase, timeStep)
        { }
    }


    public class SteelUtilisation<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public string MajorEffectiveLength
        {
            get
            {
                return (string)m_data[4];
            }
            set
            {
                m_data[4] = value;
            }
        }
        public string MinorEffectiveLength
        {
            get
            {
                return (string)m_data[5];
            }
            set
            {
                m_data[5] = value;
            }
        }

        /// <summary>
        /// Buckling resistance.
        /// EC:  EN1993-1-1: 6.3.3
        /// </summary>
        public int ForcePosition
        {
            get
            {
                return (int)m_data[6];
            }
            set
            {
                m_data[6] = value;
            }
        }
        public int Class
        {
            get
            {
                return (int)m_data[7];
            }
            set
            {
                m_data[7] = value;
            }
        }


        /// <summary>
        /// EC: EN1993-1-1: 6.2.3 and 6.2.4
        /// </summary>
        public double TensionCompressionRatio
        {
            get
            {
                return (double)m_data[8];
            }
            set
            {
                m_data[8] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public double MajorShearRatio
        {
            get
            {
                return (double)m_data[9];
            }
            set
            {
                m_data[9] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.6
        /// </summary>
        public double MinorShearRatio
        {
            get
            {
                return (double)m_data[10];
            }
            set
            {
                m_data[10] = value;
            }
        }


        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public double TorsionRatio
        {
            get
            {
                return (double)m_data[11];
            }
            set
            {
                m_data[11] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public double MajorTorsionShearRatio
        {
            get
            {
                return (double)m_data[12];
            }
            set
            {
                m_data[12] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.7
        /// </summary>
        public double MinorTorsionShearRatio
        {
            get
            {
                return (double)m_data[13];
            }
            set
            {
                m_data[13] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public double MajorBendingRatio
        {
            get
            {
                return (double)m_data[14];
            }
            set
            {
                m_data[14] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.5
        /// </summary>
        public double MinorBendingRatio
        {
            get
            {
                return (double)m_data[15];
            }
            set
            {
                m_data[15] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public double MajorBendingAxialRatio
        {
            get
            {
                return (double)m_data[16];
            }
            set
            {
                m_data[16] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public double MinorBendingAxialRatio
        {
            get
            {
                return (double)m_data[17];
            }
            set
            {
                m_data[17] = value;
            }
        }

        /// <summary>
        ///  EC: EN1993-1-1: 6.2.9
        /// </summary>
        public double BiaxialBendingAxialRatio
        {
            get
            {
                return (double)m_data[18];
            }
            set
            {
                m_data[18] = value;
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
                return (double)m_data[19];
            }
            set
            {
                m_data[19] = value;
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
                return (double)m_data[20];
            }
            set
            {
                m_data[20] = value;
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
                return (double)m_data[21];
            }
            set
            {
                m_data[21] = value;
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
                return (double)m_data[22];
            }
            set
            {
                m_data[22] = value;
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
                return (double)m_data[23];
            }
            set
            {
                m_data[23] = value;
            }
        }


        public SteelUtilisation()
        {
            m_data = new object[24];
        }

        public SteelUtilisation(TName number, TLoadcase loadcase, TTimeStep timeStep) : this()
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
                    "MajorEffectiveLength",
                    "MinorEffectiveLength",
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