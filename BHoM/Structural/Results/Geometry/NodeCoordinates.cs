using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class NodeCoordinates : IResult
    {
        public NodeCoordinates()
        {
            Data = new object[4];
        }

        public NodeCoordinates(string id, double x, double y, double z)
        {
            Data = new object[] { id, x, y, z };
        }

        public string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "X", "Y", "Z" };
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

        public double X
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

        public double Y
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

        public double Z
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

        public int CompareTo(object obj)
        {
            var r2 = obj as NodeCoordinates;
            if (r2 != null)
            {
                return Id.CompareTo(r2.Id);
            }
            return 1;
        }
    }
}
