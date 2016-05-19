using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace BHoM.Structural
{       
    /// <summary>
    /// Constraint object - base class for all release, restraint, support classes. 
    /// </summary>
    [Serializable]
    public class Constraint : Global.BHoMObject, IStructuralObject
    {
        /////////////////
        ////Properties///
        /////////////////
        private DOF[] m_DOF;


        public DOF UX
        {
            get
            {
                return m_DOF[0];
            }
            set
            {
                m_DOF[0] = value;
            }
        }

        public DOF UY
        {
            get
            {
                return m_DOF[1];
            }
            set
            {
                m_DOF[1] = value;
            }
        }

        public DOF UZ
        {
            get
            {
                return m_DOF[2];
            }
            set
            {
                m_DOF[2] = value;
            }
        }

        public DOF RX
        {
            get
            {
                return m_DOF[3];
            }
            set
            {
                m_DOF[3] = value;
            }
        }

        public DOF RY
        {
            get
            {
                return m_DOF[4];
            }
            set
            {
                m_DOF[4] = value;
            }
        }

        public DOF RZ
        {
            get
            {
                return m_DOF[5];
            }
            set
            {
                m_DOF[5] = value;
            }
        }

        /// <summary>Constraint type</summary>
        public ConstraintType Type 
        {
            get;
            set;
        }    

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        internal Constraint()
        {
            m_DOF = new DOF[6];
        }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public Constraint(string name)
        {
            this.Name = name;
            m_DOF = new DOF[6];
        }

        ///// <summary>Construct a constraint from DOF objects. Any constraint 
        ///// type (linear/non-linear) may be constructed using this.</summary>  
        //public Constraint(DOF x, DOF y, DOF z, DOF xx, DOF yy, DOF zz)
        //    :this()
        //{
        //    this.X = x; this.Y = y; this.Z = z; this.XX = xx; this.YY = yy; this.ZZ = zz;
        //}

        /// <summary>Construct a constraint from true/false. True blocks a DOF. 
        /// Only fixed or free constraint types can be constructed using this.</summary>       

        public Constraint(string name, bool[] fixity, double[] values)
        {
            m_DOF = new DOF[6];
            for (int i = 0; i < 6;i++)
            {
                m_DOF[i] = new DOF((fixity[i]) ? DOFType.Fixed : DOFType.Free, values[i]);
            }
        }

        public Constraint(string name, double[] values)
        {
            m_DOF = new DOF[6];
            for (int i = 0; i < 6; i++)
            {
                m_DOF[i] = new DOF((values[i] == -1) ? DOFType.Fixed : (values[i] == 0) ? DOFType.Free : DOFType.Spring, values[i]);           
            }
        }
        
        public Constraint(string name, IEnumerable<DOF> dof)
        {
            m_DOF = new DOF[6];
            int index = 0;
            foreach (DOF d in dof)
            {
                m_DOF[index++] = d;
            }
        }


        //////////////
        ////Methods///
        //////////////

        ///// <summary>Sets all DOF to fixed (-1)</summary>
        //public void SetFixed()
        //{
        //    this.X = new DOF(AxisDirection.X, DOFType.Fixed, -1);
        //    this.Y = new DOF(AxisDirection.Y, DOFType.Fixed, -1);
        //    this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
        //    this.XX = new DOF(AxisDirection.XX, DOFType.Fixed, -1);
        //    this.YY = new DOF(AxisDirection.YY, DOFType.Fixed, -1);
        //    this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Fixed, -1);
        //}

        ///// <summary>Sets all translational DOF to fixed (-1)</summary>
        //public void SetPinned()
        //{
        //    this.X = new DOF(AxisDirection.X, DOFType.Fixed, -1);
        //    this.Y = new DOF(AxisDirection.Y, DOFType.Fixed, -1);
        //    this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
        //    this.XX = new DOF(AxisDirection.XX, DOFType.Free, 0);
        //    this.YY = new DOF(AxisDirection.YY, DOFType.Free, 0);
        //    this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Free, 0);
        //}

        ///// <summary>Sets vertical (Z) translation to fixed (-1)</summary>
        //public void SetSliding()
        //{
        //    this.X = new DOF(AxisDirection.X, DOFType.Free, 0);
        //    this.Y = new DOF(AxisDirection.Y, DOFType.Free, 0);
        //    this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
        //    this.XX = new DOF(AxisDirection.XX, DOFType.Free, 0);
        //    this.YY = new DOF(AxisDirection.YY, DOFType.Free, 0);
        //    this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Free, 0);
        //}

        /// <summary>Sets the constraint name</summary>
        public void SetName(string name)
        {
            this.Name = name;
        }

        /// <summary>Sets the constraint type</summary>
        public void SetType(ConstraintType type)
        {
            this.Type = type;
        }      
    }
}
