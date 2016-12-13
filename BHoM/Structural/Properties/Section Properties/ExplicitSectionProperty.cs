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


        public new double Asx
        {
            set { m_Asx = value; }
            get { return m_Asx; }
        }

        public new double Asy
        {
            set { m_Asy = value; }
            get { return m_Asy; }
        }

        public new double Ix
        {
            set { m_Ix = value; }
            get { return m_Ix; }
        }

        /// <summary>Second moment of inertia about the minor axis</summary>
        public new double Iy
        {
            set { m_Iy = value; }
            get { return m_Iy; }
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

        public new double Vx
        {
            set;
            get;
        }

        public new double Vpx
        {
            set;
            get;
        }

        /// <summary>
        /// Plastic Section modulus about the major axis
        /// </summary>
        public new double Sx
        {
            set { m_Sx = value; }
            get { return m_Sx; }
        }

        /// <summary>
        /// Plastic Section modulus about the minor axis
        /// </summary>
        public new double Sy
        {
            set { m_Sy = value; }
            get { return m_Sy; }
        }

        /// <summary>
        /// Elastic Section modulus about the major axis
        /// </summary>
        public new double Zx
        {
            set { m_Zx = value; }
            get { return m_Zx; }
        }

        /// <summary>
        /// Elastic Section modulus about the minor axis
        /// </summary>
        public new double Zy
        {
            set { m_Zy = value; }
            get { return m_Zy; }
        }


    }
}
