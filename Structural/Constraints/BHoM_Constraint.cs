using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    /// <summary>
    /// Constraint object - base class for all release, restraint, support classes. 
    /// </summary>
    [Serializable]
    public class Constraint 
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; private set; }

        /// <summary>Constraint name</summary>
        public string Name { get; private set; }

        /// <summary>Constraint type</summary>
        public ConstraintType Type { get; private set; }
        /// <summary>X degree of freedom</summary>
        public DOF X { get; private set; }
        /// <summary>Y degree of freedom</summary>
        public DOF Y { get; private set; }
        /// <summary>Z degree of freedom</summary>
        public DOF Z { get; private set; }
        /// <summary>XX degree of freedom</summary>
        public DOF XX { get; private set; }
        /// <summary>YY degree of freedom</summary>
        public DOF YY { get; private set; }
        /// <summary>ZZ degree of freedom</summary>
        public DOF ZZ { get; private set; }
        /// <summary>Constraint ID object</summary>
        public ConstraintId ID { get; private set; }

        /// <summary>Construct a constraint from DOF objects. Any constraint 
        /// type (linear/non-linear) may be constructed using this.</summary>  
        public Constraint(DOF x, DOF y, DOF z, DOF xx, DOF yy, DOF zz)
        {
            this.X = x; this.Y = y; this.Z = z; this.XX = xx; this.YY = yy; this.ZZ = zz;
        }

        /// <summary>Construct a constraint from true/false. True blocks a DOF. 
        /// Only fixed or free constraint types can be constructed using this.</summary>
        public Constraint(bool x, bool y, bool z, bool xx, bool yy, bool zz)
        {
            this.X = (x) ? new DOF(AxisDirection.X, DOFType.Fixed) : new DOF(AxisDirection.X, DOFType.Free);
            this.Y = (y) ? new DOF(AxisDirection.Y, DOFType.Fixed) : new DOF(AxisDirection.Y, DOFType.Free);
            this.X = (z) ? new DOF(AxisDirection.Z, DOFType.Fixed) : new DOF(AxisDirection.Z, DOFType.Free);
            this.XX = (xx) ? new DOF(AxisDirection.XX, DOFType.Fixed) : new DOF(AxisDirection.XX, DOFType.Free);
            this.YY = (yy) ? new DOF(AxisDirection.YY, DOFType.Fixed) : new DOF(AxisDirection.YY, DOFType.Free);
            this.ZZ = (zz) ? new DOF(AxisDirection.ZZ, DOFType.Fixed) : new DOF(AxisDirection.ZZ, DOFType.Free);
        }

        /// <summary>Construct a constraint from double. Set -1 to block a DOF, 0 to release, 
        /// any other number is assumed to be a linear spring constant. 
        /// Any linear contraint types can be constructed using this.</summary>
        public Constraint(double x, double y, double z, double xx, double yy, double zz)
        {
            this.X = (x == -1) ? new DOF(AxisDirection.X, DOFType.Fixed, x) : (x == 0) ? new DOF(AxisDirection.X, DOFType.Free, x) : new DOF(AxisDirection.X, DOFType.Spring, x);
            this.Y = (y == -1) ? new DOF(AxisDirection.Y, DOFType.Fixed, y) : (y == 0) ? new DOF(AxisDirection.Y, DOFType.Free, y) : new DOF(AxisDirection.Y, DOFType.Spring, y);
            this.Z = (z == -1) ? new DOF(AxisDirection.Z, DOFType.Fixed, z) : (z == 0) ? new DOF(AxisDirection.Z, DOFType.Free, z) : new DOF(AxisDirection.Z, DOFType.Spring, z);
            this.XX = (xx == -1) ? new DOF(AxisDirection.XX, DOFType.Fixed, xx) : (xx == 0) ? new DOF(AxisDirection.XX, DOFType.Free, xx) : new DOF(AxisDirection.XX, DOFType.Spring, xx);
            this.YY = (yy == -1) ? new DOF(AxisDirection.YY, DOFType.Fixed, yy) : (yy == 0) ? new DOF(AxisDirection.YY, DOFType.Free, yy) : new DOF(AxisDirection.YY, DOFType.Spring, yy);
            this.ZZ = (zz == -1) ? new DOF(AxisDirection.ZZ, DOFType.Fixed, zz) : (zz == 0) ? new DOF(AxisDirection.ZZ, DOFType.Free, zz) : new DOF(AxisDirection.ZZ, DOFType.Spring, zz); 
        }

        /// <summary>Sets all DOF to fixed (-1)</summary>
        public void SetFixed()
        {
            this.X = new DOF(AxisDirection.X, DOFType.Fixed, -1);
            this.Y = new DOF(AxisDirection.Y, DOFType.Fixed, -1);
            this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
            this.XX = new DOF(AxisDirection.XX, DOFType.Fixed, -1);
            this.YY = new DOF(AxisDirection.YY, DOFType.Fixed, -1);
            this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Fixed, -1);
        }

        /// <summary>Sets all translational DOF to fixed (-1)</summary>
        public void SetPinned()
        {
            this.X = new DOF(AxisDirection.X, DOFType.Fixed, -1);
            this.Y = new DOF(AxisDirection.Y, DOFType.Fixed, -1);
            this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
            this.XX = new DOF(AxisDirection.XX, DOFType.Free, 0);
            this.YY = new DOF(AxisDirection.YY, DOFType.Free, 0);
            this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Free, 0);
        }

        /// <summary>Sets vertical (Z) translation to fixed (-1)</summary>
        public void SetSliding()
        {
            this.X = new DOF(AxisDirection.X, DOFType.Free, 0);
            this.Y = new DOF(AxisDirection.Y, DOFType.Free, 0);
            this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
            this.XX = new DOF(AxisDirection.XX, DOFType.Free, 0);
            this.YY = new DOF(AxisDirection.YY, DOFType.Free, 0);
            this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Free, 0);
        }

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
            double[] values = new double[]{
                this.X.Value, 
                this.Y.Value, 
                this.Z.Value, 
                this.XX.Value, 
                this.YY.Value, 
                this.ZZ.Value };
            return values;
        }

        /// <summary>Returns the descriptions for each DOF type</summary>
        public string[] GetDescriptions()
        {
            string[] descriptions = new string[] { 
                this.X.Type.ToString(), 
                this.Y.Type.ToString(), 
                this.Z.Type.ToString(), 
                this.XX.Type.ToString(), 
                this.YY.Type.ToString(), 
                this.ZZ.Type.ToString() };
            return descriptions;
        }
      }

    /// <summary>
    /// Degrees of freedom class for use in constraint objects
    /// </summary>
    public class DOF
    {
        /// <summary>Direction</summary>
        public AxisDirection Direction { get; set; }
        /// <summary>Type of DOF (linear/non-linear etc)</summary>
        public DOFType Type { get; set; }
        /// <summary>DOF value</summary>
        public double Value { get; set; }
        /// <summary>DOF non-linear model</summary>
        public object NonLinearModel { get; set; }

        /// <summary>Constructs a DOF using direction and type</summary>
        public DOF(AxisDirection direction, DOFType type)
        {
            this.Direction = direction;
            this.Type = type;
        }

        /// <summary>Constructs a DOF using direciton, type and value</summary>
        public DOF(AxisDirection direction, DOFType type, double Value)
        {
            this.Direction = direction;
            this.Type = type;
            this.Value = Value;
        }

        /// <summary>Constructs a DOF using direction, type and values as objects for non-linear model</summary>
        public DOF(AxisDirection direction, DOFType type, object Value)
        {
            this.Direction = direction;
            this.Type = type;
            this.NonLinearModel = Value;
        }
     }

    /// <summary>
    /// Constraint ID object
    /// </summary>
    [Serializable]
    public class ConstraintId : ISerializable
    {
        /// <summary>Constraint name</summary>
        public string Name { get; set; }

        /// <summary></summary>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name, typeof(string));
        }

        /// <summary>Constructs and ID using name</summary>
        public ConstraintId(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Ctor used by the serialisation engine
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public ConstraintId(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
        }
    }



    
}
