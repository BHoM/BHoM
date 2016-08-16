using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Results
{
    public abstract class Result : IComparable
    {
        internal object[] Data { get; set; }

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

        public int Name
        {
            get
            {
                return (int)Data[1];
            }
            set
            {
                Data[1] = value;
            }
        }

        public int Loadcase
        {
            get
            {
                return (int)Data[2];
            }
            set
            {
                Data[2] = value;
            }
        }

        public int TimeStep
        {
            get
            {
                return (int)Data[3];
            }
            set
            {
                Data[3] = value;
            }
        }

        public Result() { }

        public abstract string[] ColumnHeaders { get; }

        public abstract ResultType ResultType { get; }

        public int CompareTo(object obj)
        {
            Result r2 = obj as Result;
            int v1 = this.Name * 100000 + this.Loadcase * 100 + this.TimeStep;
            int v2 = r2.Name * 100000 + r2.Loadcase * 100 + r2.TimeStep;
            return v1.CompareTo(v2);
        }
    }

}
