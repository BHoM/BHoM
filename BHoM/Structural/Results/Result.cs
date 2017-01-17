using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public abstract class Result<TName, TLoadcase, TTimeStep> : IResult
        where TName : IComparable
        where TLoadcase : IComparable
        where TTimeStep : IComparable
    {
        public object[] Data { get; set; }

        public string Id
        {
            get
            {
                return (string)Data[0];
            }
            set
            {
                Data[0] = value;
            }
        }

        public TName Name
        {
            get
            {
                return (TName)Data[1];
            }
            set
            {
                Data[1] = value;
            }
        }

        public TLoadcase Loadcase
        {
            get
            {
                return (TLoadcase)Data[2];
            }
            set
            {
                Data[2] = value;
            }
        }

        public TTimeStep TimeStep
        {
            get
            {
                return (TTimeStep)Data[3];
            }
            set
            {
                Data[3] = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().FullName + " " + Id;
        }

        public Result() { }      

        public abstract ResultType ResultType { get; }
        

        public abstract string[] ColumnHeaders
        {
            get;
        }

        public int CompareTo(object obj)
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
    }
}
