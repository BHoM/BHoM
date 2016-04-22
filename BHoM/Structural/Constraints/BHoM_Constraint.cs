using System;
using System.Collections.Generic;
using System.Reflection;

namespace BHoM.Structural
{
    /// <summary>
    /// Constraint object - base class for all release, restraint, support classes. 
    /// </summary>
    [Serializable]
    public class Constraint : Global.BHoMObject, IStructuralObject
    {
        private List<DOFType> m_DOFTypes;
        private List<double> m_Values;

        /////////////////
        ////Properties///
        /////////////////

        internal List<DOFType> DOFTypes
        {
            get
            {
                return m_DOFTypes != null ? m_DOFTypes :
                    m_DOFTypes = Global.Utils.IntToEnumList<DOFType>(Parameters.LookUp<List<int>>(Global.Param.DOFTypes));
            }
            set
            {
                Parameters.AddList<int>(Global.Param.DOFTypes, Global.Utils.EnumToIntList<DOFType>(value));
            }
        }

        internal List<double> Values
        {
            get
            {
                return m_Values != null ? m_Values:
                    m_Values = Parameters.LookUp<List<double>>(Global.Param.Values);
            }
            set
            {
                m_Values = value;
                Parameters.AddList<double>(Global.Param.Values, value);
            }
        }

        /// <summary>Constraint type</summary>
        public ConstraintType Type 
        { 
            get
            {
                return (ConstraintType)Enum.ToObject(typeof(ConstraintType), (Parameters.LookUp<int>(Global.Param.ConstraintType)));
            }
            private set
            {
                Parameters.AddItem<int>(Global.Param.ConstraintType, (int)value);
            }
        }

        public DOF DOF(AxisDirection axisDir)
        {
            return new DOF(DOFTypes[(int)axisDir], Values[(int)axisDir]);
        }

        public DOFType DoFType(AxisDirection axisDir)
        {
            return DOFTypes[(int)axisDir];
        }

        public double Value(AxisDirection axisDir)
        {
            return Values[(int)axisDir];
        }
        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        public Constraint() { }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public Constraint(string name)
        {
            this.Number = -1;
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

        public Constraint(string name, bool[] fixity, double[] values)
        {
            List<DOFType> dofTypes = new List<DOFType>(6);
            List<double> vals = new List<double>(6);
            for (int i = 0; i < 6;i++)
            {
                dofTypes.Add((fixity[i]) ? DOFType.Fixed : DOFType.Free);
                vals.Add(values[i]);
            }
            DOFTypes = dofTypes;
            Values = vals;
        }

        public Constraint(string name, double[] values)
        {
            List<DOFType> dofTypes = new List<DOFType>(6);
            List<double> vals = new List<double>(6);
            for (int i = 0; i < 6; i++)
            {
                dofTypes.Add((values[i] == -1) ? DOFType.Fixed : (values[i] == 0) ? DOFType.Free : DOFType.Spring);
                Values.Add(values[i]);
            }
            DOFTypes = dofTypes;
            Values = vals;
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

        /// <summary>Returns the values for each DOF</summary>
        public double[] GetValues()
        {            
            return Values.ToArray();
        }

        /// <summary>Returns the descriptions for each DOF type</summary>
        public string[] GetDescriptions()
        {
            string[] descriptions = new string[6];
            for (int i = 0; i < 6; i++)
            {
                descriptions[i] = DOFTypes[i].ToString();
            }

            return descriptions;
        }

        /// <summary>
        /// Set the constraint number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.Number = number;
        }
    }
}
