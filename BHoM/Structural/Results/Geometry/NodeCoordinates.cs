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
        private object[] m_data;
        public NodeCoordinates()
        {
            m_data = new object[4];
        }

        public NodeCoordinates(string id, double x, double y, double z)
        {
            m_data = new object[] { id, x, y, z };
        }

        public string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "X", "Y", "Z" };
            }
        }


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

        public double X
        {
            get
            {
                return (double)m_data[1];
            }

            set
            {
                m_data[1] = value;
            }
        }

        public double Y
        {
            get
            {
                return (double)m_data[2];
            }

            set
            {
                m_data[2] = value;
            }
        }

        public double Z
        {
            get
            {
                return (double)m_data[3];
            }

            set
            {
                m_data[3] = value;
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
