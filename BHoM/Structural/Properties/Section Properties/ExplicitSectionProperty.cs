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
            set;
            get;
        }


        public new double Asy
        {
            set;
            get;
        }

        public new double Asz
        {
            set;
            get;
        }

        public new double Iy
        {
            set;
            get;
        }

        /// <summary>Second moment of inertia about the minor axis</summary>
        public new double Iz
        {
            set;
            get;
        }

        ///<summary>Torsion Constant</summary>
        public new double J
        {
            get;
            set;
        }

        public double  Vy
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
            set;
            get;
        }

        /// <summary>
        /// Plastic Section modulus about the minor axis
        /// </summary>
        public new double Sz
        {
            set;
            get;
        }

        /// <summary>
        /// Elastic Section modulus about the major axis
        /// </summary>
        public new double Zy
        {
            set;
            get;
        }

        /// <summary>
        /// Elastic Section modulus about the minor axis
        /// </summary>
        public new double Zz
        {
            set;
            get;
        }

        public override double[] SectionData
        {
            get;
            set;
        }
    }
}
