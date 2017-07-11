using BH.oM.Structural.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public class BarCoordinates : IResult
    {
        private object[] m_data;
        public BarCoordinates()
        {
            m_data = new object[9];
        }

        public BarCoordinates(string id, double x1, double y1, double z1, double x2, double y2, double z2, string section, double ori)
        {
            m_data = new object[] { id, x1, y1, z1, x2, y2, z2, section, ori };
        }

        public string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "X1", "Y1", "Z1", "X2", "Y2", "Z2", "SectionProp", "Orientation" };
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

        public double X1
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

        public double Y1
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

        public double Z1
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

        public double X2
        {
            get
            {
                return (double)m_data[4];
            }

            set
            {
                m_data[1] = value;
            }
        }

        public double Y2
        {
            get
            {
                return (double)m_data[5];
            }

            set
            {
                m_data[2] = value;
            }
        }

        public double Z2
        {
            get
            {
                return (double)m_data[6];
            }

            set
            {
                m_data[3] = value;
            }
        }

        public string SectionProp
        {
            get
            {
                return (string)m_data[7];
            }

            set
            {
                m_data[0] = value;
            }
        }

        public double Orientation
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

        public int CompareTo(object obj)
        {
            var r2 = obj as BarCoordinates;
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
