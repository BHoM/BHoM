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



        //Overrides the calculate section property method to not update varables when getters are called
        public override void CalculateSection()
        { }


        public new double GrossArea
        {
            set { m_Area = value; }
            get { return base.GrossArea; }
        }


        public new double Asx
        {
            set { m_Asx = value; }
            get { return base.Asx; }
        }

        public new double Asy
        {
            set { m_Asy = value; }
            get { return base.Asy; }
        }

        public new double Ix
        {
            set { m_Ix = value; }
            get { return base.Ix; }
        }

        /// <summary>Second moment of inertia about the minor axis</summary>
        public new double Iy
        {
            set { m_Iy = value; }
            get { return base.Iy; }
        }

        ///<summary>Torsion Constant</summary>
        public new double J
        {
            get { return m_J; }
            set { m_J = value; }
        }

        public new double  Vy
        {
            set { m_Vy = value; }
            get { return base.Vy; }
        }

        public new double Vpy
        {
            set { m_Vpy = value; }
            get { return base.Vpy; }
        }

        public new double Vx
        {
            set { m_Vx = value; }
            get { return base.Vx; }
        }

        public new double Vpx
        {
            set { m_Vpx = value; }
            get { return base.Vpx; }
        }

        /// <summary>
        /// Plastic Section modulus about the major axis
        /// </summary>
        public new double Sx
        {
            set { m_Sx = value; }
            get { return base.Sx; }
        }

        /// <summary>
        /// Plastic Section modulus about the minor axis
        /// </summary>
        public new double Sy
        {
            set { m_Sy = value; }
            get { return base.Sy; }
        }

        /// <summary>
        /// Elastic Section modulus about the major axis
        /// </summary>
        public new double Zx
        {
            set { m_Zx = value; }
            get { return base.Zx; }
        }

        /// <summary>
        /// Plastic Section modulus about the minor axis
        /// </summary>
        public new double Zy
        {
            set { m_Zy = value; }
            get { return base.Zy; }
        }


    }
}
