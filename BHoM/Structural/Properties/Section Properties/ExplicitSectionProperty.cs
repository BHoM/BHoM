using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public class ExplicitSectionProperty : SectionProperty
    {
        public ExplicitSectionProperty()
        { }


        protected override string GenerateStandardName()
        {
            return "Explicit";
        }

        //Overrides the calculate section property method to not update varables when getters are called


        public new double GrossArea
        {
            set { m_Area = value; }
            get { return m_Area; }
        }


        public new double Asy
        {
            set { m_Asy = value; }
            get { return m_Asy; }
        }

        public new double Asz
        {
            set { m_Asz = value; }
            get { return m_Asz; }
        }

        public new double Iy
        {
            set { m_Iy = value; }
            get { return m_Iy; }
        }

        /// <summary>Second moment of inertia about the minor axis</summary>
        public new double Iz
        {
            set { m_Iz = value; }
            get { return m_Iz; }
        }

        ///<summary>Torsion Constant</summary>
        public new double J
        {
            get;
            set;
        }

        public new double  Vy
        {
            set;
            get;
        }

        public new double Vpy
        {
            set;
            get;
        }

        public new double Vz
        {
            set;
            get;
        }

        public new double Vpz
        {
            set;
            get;
        }

        /// <summary>
        /// Plastic Section modulus about the major axis
        /// </summary>
        public new double Sy
        {
            set { m_Sy = value; }
            get { return m_Sy; }
        }

        /// <summary>
        /// Plastic Section modulus about the minor axis
        /// </summary>
        public new double Sz
        {
            set { m_Sz = value; }
            get { return m_Sz; }
        }

        /// <summary>
        /// Elastic Section modulus about the major axis
        /// </summary>
        public new double Zy
        {
            set { m_Zy = value; }
            get { return m_Zy; }
        }

        /// <summary>
        /// Elastic Section modulus about the minor axis
        /// </summary>
        public new double Zz
        {
            set { m_Zz = value; }
            get { return m_Zz; }
        }


    }
}
