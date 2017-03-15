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

        public string MinorEffectiveLength
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
        public string MajorEffectiveLength
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
        public int SteelClass
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
        ///  EC: EN1994-1-1: 6.7
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
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public double MinorBendingRatio
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
        /// EC: EN1994-1-1: 6.3 and 6.3
        /// </summary>
        public double MajorBendingRatio
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
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double MinorBendingAxialRatio
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
        ///  EC: EN1994-1-1: 6.7
        /// </summary>
        public double MajorBendingAxialRatio
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
        ///  EC: EN1994-1-1: 6.7.3
        /// </summary>
        public double BiaxialBendingAxialRatio
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
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public double MinorShearRatio
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
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public double MajorShearRatio
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
        ///  EC: EN1994-1-1: 6.5
        /// </summary>
        public double MinorBendingShearRatio
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
        ///  EC: EN1994-1-1: 6.3.4
        /// </summary>
        public double MajorBendingShearRatio
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
        ///  EC: EN1994-1-1: 6.4
        /// </summary>
        public double CompressionBucklingRatio
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
        public double BendingBucklingRatio
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
        public double BendingCompressionBucklingRatio
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

        public CompositeUtilisation()
        {
            m_data = new object[21];
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
                    "MinorEffectiveLength",
                    "MajorEffectiveLength",
                    "ForcePosition",
                    "SteelClass",
                    "TensionCompressionRatio",
                    "MinorBendingRatio",
                    "MajorBendingRatio",
                    "MinorBendingAxialRatio",
                    "MajorBendingAxialRatio",
                    "BiaxialBendingAxialRatio",
                    "MinorShearRatio",
                    "MajorShearRatio",
                    "MinorBendingShearRatio",
                    "MajorBendingShearRatio",
                    "CompressionBucklingRatio",
                    "BendingBucklingRatio",
                    "BendingCompressionBucklingRatio",
                };
            }
        }
    }
}
