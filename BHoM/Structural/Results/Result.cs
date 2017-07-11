using BH.oM.Structural.Interface;
using BH.oM.Structural.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public abstract class Result<TName, TLoadcase, TTimeStep> : IResult
        where TName : IComparable
        where TLoadcase : IComparable
        where TTimeStep : IComparable
    {
        protected object[] m_data;

        public string Id
        {
            get
            {
                return (string)m_data[0];
            }
            set
            {
                m_data[0] = value;
            }
        }

        public object this[int i]
        {
            get
            {
                return m_data[i];
            }
        }


        public TName Name
        {
            get
            {
                return (TName)m_data[1];
            }
            set
            {
                m_data[1] = value;
            }
        }

        public TLoadcase Loadcase
        {
            get
            {
                return (TLoadcase)m_data[2];
            }
            set
            {
                m_data[2] = value;
            }
        }

        public TTimeStep TimeStep
        {
            get
            {
                return (TTimeStep)m_data[3];
            }
            set
            {
                m_data[3] = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().FullName + " " + Id;
        }

        public virtual IResult Duplicate()
        {
            return (IResult)this.MemberwiseClone();
        }

        public Result() { }      

        public abstract ResultType ResultType { get; }
        

        public abstract string[] ColumnHeaders
        {
            get;
        }

        public virtual int CompareTo(object obj)
        {
            var r2 = obj as Result<TName, TLoadcase, TTimeStep>;
            if (r2 != null)
            {
                int n = this.Name.CompareTo(r2.Name);
                if (n == 0)
                {
                    int l = this.Loadcase.CompareTo(r2.Loadcase);
                    return l == 0 ? this.TimeStep.CompareTo(r2.TimeStep) : l;
                }
                else
                {
                    return n;
                }
            }
            return 1;
        }

        public object[] GetData()
        {
            return m_data;
        }

        public void SetData(object[] data)
        {
            m_data = data;
        }
    }
}
