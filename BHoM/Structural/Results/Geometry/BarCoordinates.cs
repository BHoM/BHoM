using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class BarCoordinates : IResult
    {
        public BarCoordinates()
        {
            Data = new object[7];
        }

        public BarCoordinates(string id, double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Data = new object[] { id, x1, y1, z1, x2, y2, z2 };
        }

        public string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "X1", "Y1", "Z1", "X2", "Y2", "Z2" };
            }
        }

        public object[] Data
        {
            get;

            set;
        }

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

        public double X1
        {
            get
            {
                return (double)Data[1];
            }

            set
            {
                Data[1] = value;
            }
        }

        public double Y1
        {
            get
            {
                return (double)Data[2];
            }

            set
            {
                Data[2] = value;
            }
        }

        public double Z1
        {
            get
            {
                return (double)Data[3];
            }

            set
            {
                Data[3] = value;
            }
        }

        public double X2
        {
            get
            {
                return (double)Data[4];
            }

            set
            {
                Data[1] = value;
            }
        }

        public double Y2
        {
            get
            {
                return (double)Data[5];
            }

            set
            {
                Data[2] = value;
            }
        }

        public double Z2
        {
            get
            {
                return (double)Data[6];
            }

            set
            {
                Data[3] = value;
            }
        }

        public int CompareTo(object obj)
        {
            var r2 = obj as BarCoordinates;
            if (r2 != null)
            {
                return Id.CompareTo(r2.Id);
            }
            return 1;
        }
    }
}
