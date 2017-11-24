using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base.Results;

namespace BHoM.Structural.Results
{

    public class BarStrains : BarStrains<string, string, string>
    {
        public BarStrains() : base()
        { }

        public BarStrains(object[] data) : base(data) { }
        public BarStrains(string number, string loadcase, int position, int divisions, string timestep, double axialStrain) :
            base(number, loadcase, position, divisions, timestep, axialStrain)
        { }
    }

    public class BarStrains<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public BarStrains()
        {
            m_data = new object[7];
        }

        public BarStrains(object[] data)
        {
            m_data = data;
        }

        public BarStrains(TName number, TLoadcase loadcase, int position, int divisions, TTimeStep timestep, double axialStrain) : this()
        {

            Name = number;
            DisplacementPosition = position;
            TimeStep = timestep;
            Loadcase = loadcase;
            Divisions = divisions;
            AxialStrain = axialStrain;

            Id = Name + ":" + loadcase + ":" + DisplacementPosition + ":" + TimeStep;
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

        public double AxialStrain
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

        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "DisplacementPosition", "Divisions", "AxialStrain" };
            }
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.BarStrains;
            }
        }
    }

}
