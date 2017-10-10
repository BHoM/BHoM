using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Constraint object - base class for all release, restraint, support classes. 
    /// </summary>
    public class NodeConstraint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Translational constraint on X Axis
        /// </summary>
        public DOFType UX { get; set; } = DOFType.Free;
        /// <summary>
        /// Elastic translational stiffness value on X axis
        /// </summary>
        public double KX { get; set; } = 0;

        /// <summary>
        /// Translational constraint on Y Axis
        /// </summary>
        public DOFType UY { get; set; } = DOFType.Free;
        /// <summary>
        /// Elastic translational stiffness value on Y axis
        /// </summary>
        public double KY { get; set; } = 0;

        /// <summary>
        /// Elastic translational stiffness value on Z axis
        /// </summary>
        public DOFType UZ { get; set; } = DOFType.Free;
        /// <summary>
        /// Elastic translational stiffness value on Z axis
        /// </summary>
        public double KZ { get; set; } = 0;

        /// <summary>
        /// Rotational constraint on X Axis
        /// </summary>
        public DOFType RX { get; set; } = DOFType.Free;
        /// <summary>
        /// Elastic translational stiffness value on X axis
        /// </summary>
        public double HX { get; set; } = 0;

        /// <summary>
        /// Rotational constraint on Y Axis
        /// </summary>
        public DOFType RY { get; set; } = DOFType.Free;
        /// <summary>
        /// Elastic translational stiffness value on Y axis
        /// </summary>
        public double HY { get; set; } = 0;

        /// <summary>
        /// Rotational constraint on Z Axis
        /// </summary>
        public DOFType RZ { get; set; } = DOFType.Free;
        /// <summary>
        /// Elastic translational stiffness value on Z axis
        /// </summary>
        public double HZ { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NodeConstraint() { }

        public NodeConstraint(string name = "")
        {
            Name = name;
        }
    }
}

//private double[] m_Values;
///////////////////
//////Properties///
///////////////////

//[Description("KX Direction elastic value")]
//[DefaultValue(0.0)]
//public double KX
//{
//    get
//    {
//        return m_Values[0];
//    }
//    set
//    {
//        m_Values[0] = value;
//    }
//}

//[Description("KY Direction elastic value")]
//[DefaultValue(0.0)]
//public double KY
//{
//    get
//    {
//        return m_Values[1];
//    }
//    set
//    {
//        m_Values[1] = value;
//    }
//}

//[Description("KZ Direction elastic value")]
//[DefaultValue(0.0)]
//public double KZ
//{
//    get
//    {
//        return m_Values[2];
//    }
//    set
//    {
//        m_Values[2] = value;
//    }
//}

//[Description("HX Direction elastic value")]
//[DefaultValue(0.0)]
//public double HX
//{
//    get
//    {
//        return m_Values[3];
//    }
//    set
//    {
//        m_Values[3] = value;
//    }
//}

//[Description("HY Direction elastic value")]
//[DefaultValue(0.0)]
//public double HY
//{
//    get
//    {
//        return m_Values[4];
//    }
//    set
//    {
//        m_Values[4] = value;
//    }
//}

//[Description("HZ Direction elastic value")]
//[DefaultValue(0.0)]
//public double HZ
//{
//    get
//    {
//        return m_Values[5];
//    }
//    set
//    {
//        m_Values[5] = value;
//    }
//}


/*public new string Name
{
    get
    {
        return base.Name == "" ? ToString() : base.Name;
    }
    set
    {
        base.Name = value;
    }
}*/


/// <summary>Constraint type</summary>
//public ConstraintType Type 
//{
//    get;
//    set;
//}    

///////////////////
////Constructors///
///////////////////

//        /// <summary>
//        /// Construct an empty constraint object
//        /// </summary>
//        public NodeConstraint()
//        {
//            m_Values = new double[6];
//        }

//        /// <summary>
//        /// Construct an empty constraint object with a name
//        /// </summary>
//        public NodeConstraint(string name) : this()
//        {
//            this.Name = name;
//        }

//        ///// <summary>Construct a constraint from DOF objects. Any constraint 
//        ///// type (linear/non-linear) may be constructed using this.</summary>  
//        //public Constraint(DOF x, DOF y, DOF z, DOF xx, DOF yy, DOF zz)
//        //    :this()
//        //{
//        //    this.X = x; this.Y = y; this.Z = z; this.XX = xx; this.YY = yy; this.ZZ = zz;
//        //}

//        /// <summary>Construct a constraint from true/false. True blocks a DOF. 
//        /// Only fixed or free constraint types can be constructed using this.</summary>       

//        public NodeConstraint(string name, bool[] fixity, double[] values) : this(name)
//        {
//            UX = (fixity[0]) ? DOFType.Fixed : (values[0] == 0) ? DOFType.Free : DOFType.Spring;
//            UY = (fixity[1]) ? DOFType.Fixed : (values[1] == 0) ? DOFType.Free : DOFType.Spring;
//            UZ = (fixity[2]) ? DOFType.Fixed : (values[2] == 0) ? DOFType.Free : DOFType.Spring;
//            RX = (fixity[3]) ? DOFType.Fixed : (values[3] == 0) ? DOFType.Free : DOFType.Spring;
//            RY = (fixity[4]) ? DOFType.Fixed : (values[4] == 0) ? DOFType.Free : DOFType.Spring;
//            RZ = (fixity[5]) ? DOFType.Fixed : (values[5] == 0) ? DOFType.Free : DOFType.Spring;
//            m_Values = values;
//        }

//        public NodeConstraint(string name, double[] values) : this(name)
//        {
//            UX = (values[0] == -1) ? DOFType.Fixed : (values[0] == 0) ? DOFType.Free : DOFType.Spring;
//            UY = (values[1] == -1) ? DOFType.Fixed : (values[1] == 0) ? DOFType.Free : DOFType.Spring;
//            UZ = (values[2] == -1) ? DOFType.Fixed : (values[2] == 0) ? DOFType.Free : DOFType.Spring;
//            RX = (values[3] == -1) ? DOFType.Fixed : (values[3] == 0) ? DOFType.Free : DOFType.Spring;
//            RY = (values[4] == -1) ? DOFType.Fixed : (values[4] == 0) ? DOFType.Free : DOFType.Spring;
//            RZ = (values[5] == -1) ? DOFType.Fixed : (values[5] == 0) ? DOFType.Free : DOFType.Spring;
//            m_Values = values;
//        }

//        public bool[] Fixity()
//        {
//            return new bool[] { UX == DOFType.Fixed, UY == DOFType.Fixed, UZ == DOFType.Fixed,
//                RX == DOFType.Fixed, RY == DOFType.Fixed, RZ == DOFType.Fixed };
//        }

//        public bool[] Freedom()
//        {
//            return new bool[] { UX != DOFType.Fixed, UY != DOFType.Fixed, UZ != DOFType.Fixed,
//                RX != DOFType.Fixed, RY != DOFType.Fixed, RZ != DOFType.Fixed };
//        }

//        public double[] ElasticValues()
//        {
//            return m_Values;
//        }

//        public string RestraintKey()
//        {
//            return DOFKey(UX) + DOFKey(UY) + DOFKey(UZ) + DOFKey(RX) + DOFKey(RY) + DOFKey(RZ);
//        }

//        public string ValueKey()
//        {
//            string result = "";
//            result += m_Values[0] != 0 ? " KX=" + Math.Round(m_Values[0], 2) : "";
//            result += m_Values[1] != 0 ? " KY=" + Math.Round(m_Values[1], 2) : "";
//            result += m_Values[2] != 0 ? " KZ=" + Math.Round(m_Values[2], 2) : "";
//            result += m_Values[3] != 0 ? " HX=" + Math.Round(m_Values[3], 2) : "";
//            result += m_Values[4] != 0 ? " HY=" + Math.Round(m_Values[4], 2) : "";
//            result += m_Values[5] != 0 ? " HZ=" + Math.Round(m_Values[5], 2) : "";

//            return string.IsNullOrEmpty(result) ? result : " ->" + result;
//        }

//        private string DOFKey(DOFType type)
//        {
//            switch (type)
//            {
//                case DOFType.Free:
//                    return "f";
//                case DOFType.Fixed:
//                case DOFType.FixedNegative:
//                case DOFType.FixedPositive:
//                    return "x";
//                case DOFType.Spring:
//                case DOFType.SpringNegative:
//                case DOFType.SpringPositive:
//                case DOFType.SpringRelative:
//                case DOFType.SpringRelativeNegative:
//                case DOFType.SpringRelativePositive:
//                    return "e";
//                        case DOFType.NonLinear:
//                    return "n";
//                default:
//                    return "f";
//            }
//        }

//        public override string ToString()
//        {
//            //return string.IsNullOrEmpty(base.Name) ? RestraintKey() + ValueKey() : base.Name;
//            return string.IsNullOrEmpty(base.Name) ? RestraintKey() + ValueKey() : base.Name + " " + RestraintKey() + " " + ValueKey();
//        }
//    }
//}
