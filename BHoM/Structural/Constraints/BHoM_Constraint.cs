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
    public class NodeConstraint : Global.BHoMObject, IStructuralObject
    {
        /////////////////
        ////Properties///
        /////////////////
     
        public DOF UX { get; set; }
       
        public DOF UY { get; set; }

        public DOF UZ { get; set; }

        public DOF RX { get; set; }

        public DOF RY { get; set; }

        public DOF RZ { get; set; }

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
        public NodeConstraint()
        {
            UX = new DOF();
            UY = new DOF();
            UZ = new DOF();
            RX = new DOF();
            RY = new DOF();
            RZ = new DOF();
        }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public NodeConstraint(string name) : this()
        {
            this.Name = name;
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

        public NodeConstraint(string name, bool[] fixity, double[] values)
        {
            UX = new DOF((fixity[0]) ? DOFType.Fixed : DOFType.Free, values[0]);
            UY = new DOF((fixity[1]) ? DOFType.Fixed : DOFType.Free, values[1]);
            UZ = new DOF((fixity[2]) ? DOFType.Fixed : DOFType.Free, values[2]);
            RX = new DOF((fixity[3]) ? DOFType.Fixed : DOFType.Free, values[3]);
            RY = new DOF((fixity[4]) ? DOFType.Fixed : DOFType.Free, values[4]);
            RZ = new DOF((fixity[5]) ? DOFType.Fixed : DOFType.Free, values[5]);
        }

        public NodeConstraint(string name, double[] values)
        {
            UX = new DOF((values[0] == -1) ? DOFType.Fixed : (values[0] == 0) ? DOFType.Free : DOFType.Spring, values[0]);
            UY = new DOF((values[1] == -1) ? DOFType.Fixed : (values[1] == 0) ? DOFType.Free : DOFType.Spring, values[1]);
            UZ = new DOF((values[2] == -1) ? DOFType.Fixed : (values[2] == 0) ? DOFType.Free : DOFType.Spring, values[2]);
            RX = new DOF((values[3] == -1) ? DOFType.Fixed : (values[3] == 0) ? DOFType.Free : DOFType.Spring, values[3]);
            RY = new DOF((values[4] == -1) ? DOFType.Fixed : (values[4] == 0) ? DOFType.Free : DOFType.Spring, values[4]);
            RZ = new DOF((values[5] == -1) ? DOFType.Fixed : (values[5] == 0) ? DOFType.Free : DOFType.Spring, values[5]);
        }     
    }

    public class BarConstraint : BHoM.Global.BHoMObject
    {


        public DOF Horizontal { get; set; }

        public DOF Vertical { get; set; }

        public DOF Axial { get; set; }

        public DOF Rotational { get; set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        internal BarConstraint()
        {
            Horizontal = new DOF();
            Vertical = new DOF();
            Axial = new DOF();
            Rotational = new DOF();
        }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public BarConstraint(string name) : this()
        {
            this.Name = name;
        }
    }

    public class SurfaceConstraint : BHoM.Global.BHoMObject
    {
        /////////////////
        ////Properties///
        /////////////////
      
        public DOF UX { get; set; }

        public DOF UY { get; set; }

        public DOF Normal { get; set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        internal SurfaceConstraint()
        {
            UX = new DOF();
            UY = new DOF();
            Normal = new DOF();
        }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public SurfaceConstraint(string name) : this()
        {
            this.Name = name;
        }
    }
}
