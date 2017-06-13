using BHoM.Base;
using BHoM.Base.Results;
using BHoM.Global;
using BHoM.Structural.Loads;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BHoM.Structural.Results
{
    public class BarDisplacement : BarDisplacement<string, string, string>
    {
        public BarDisplacement() : base()
        { }

        public BarDisplacement(object[] data) : base(data) { }
        public BarDisplacement(string number, string loadcase, int position, int divisions, string timestep, double ux, double uy, double uz, double utot, double rx, double ry, double rz, double rtot) :
            base(number, loadcase, position, divisions, timestep, ux, uy, uz, utot, rx, ry, rz, rtot)
        { }
    }

    public class BarDisplacement<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public BarDisplacement()
        {
            m_data = new object[14];
        }

        public BarDisplacement(object[] data)
        {
            m_data = data;
        }

        public BarDisplacement(TName number, TLoadcase loadcase, int position, int divisions, TTimeStep timestep, double ux, double uy, double uz, double utot, double rx, double ry, double rz, double rtot) : this()
        {
            Name = number;
            DisplacementPosition = position;
            TimeStep = timestep;
            Loadcase = loadcase;
            Divisions = divisions;
            UX = ux;
            UY = uy;
            UZ = uz;
            UTot = utot;
            RX = rx;
            RY = ry;
            RZ = rz;
            RTot = rtot;
        }

        public int DisplacementPosition
        {
            get
            {
                return (int)m_data[4];
            }
            set
            {
                m_data[4] = value;
            }
        }

        public int Divisions
        {
            get
            {
                return (int)m_data[5];
            }
            set
            {
                m_data[5] = value;
            }
        }

        public double UX
        {
            get
            {
                return (double)m_data[6];
            }
            set
            {
                m_data[6] = value;
            }
        }

        public double UY
        {
            get
            {
                return (double)m_data[7];
            }
            set
            {
                m_data[7] = value;
            }
        }

        public double UZ
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

        public double UTot
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

        public double RX
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

        public double RY
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

        public double RZ
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

        public double RTot
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

        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "DisplacementPosition", "Divisions", "UX", "UY", "UZ","UTot", "RX", "RY", "RZ","RTot" };
            }
        }

        public override int CompareTo(object obj)
        {
            var r2 = obj as BarDisplacement<TName, TLoadcase, TTimeStep>;
            if (r2 != null)
            {
                int i1, i2;
                int n;
                if (int.TryParse(this.Name.ToString(), out i1) && int.TryParse(r2.Name.ToString(), out i2))
                {
                    n = i2.CompareTo(i2);
                }
                else
                {
                    n = this.Name.CompareTo(r2.Name);
                }
                if (n == 0)
                {
                    int l = this.Loadcase.CompareTo(r2.Loadcase);
                    if (l == 0)
                    {
                        int f = this.DisplacementPosition.CompareTo(r2.DisplacementPosition);
                        return f == 0 ? this.TimeStep.CompareTo(r2.TimeStep) : f;
                    }
                    else
                    {
                        return l;
                    }
                }
                else
                {
                    return n;
                }
            }
            return 1;
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.BarDisplacement;
            }
        }
    }
}
