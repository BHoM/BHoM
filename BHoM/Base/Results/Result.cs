using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Results
{
    public abstract class Result
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
    }

}
