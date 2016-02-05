using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    [Serializable]
    public class Constraint 
    {
        public string Name { get; private set; }

        //Degrees of freedom
        public ConstraintType Type { get; private set; }
        public DOF X { get; private set; }
        public DOF Y { get; private set; }
        public DOF Z { get; private set; }
        public DOF XX { get; private set; }
        public DOF YY { get; private set; }

        public DOF ZZ { get; private set; }
        public ConstraintId ID { get; private set; }
        public List<int> NodeNumbers { get; private set; }
        public List<BHoM.Structural.Node> Nodes { get; private set; }

        public void AddNode(BHoM.Structural.Node node)
        {
            this.Nodes.Add(node);
            this.NodeNumbers.Add(node.Number);
        }
        
        public Constraint()
        {
            this.Nodes = new List<BHoM.Structural.Node>();
            this.NodeNumbers = new List<int>();
        }

        //Construct a constraint from DOF objects. Any constraint type (linear/non-linear) may be constructed using this.
        public Constraint(DOF x, DOF y, DOF z, DOF xx, DOF yy, DOF zz)
            :this()
        {
            this.X = x; this.Y = y; this.Z = z; this.XX = xx; this.YY = yy; this.ZZ = zz;
        }

        //Construct a constraint from true/false. True blocks a DOF. Only fixed or free constraint types can be constructed using this.
        public Constraint(bool x, bool y, bool z, bool xx, bool yy, bool zz)
            :this()
        {
            this.X = (x) ? new DOF(AxisDirection.X, DOFType.Fixed) : new DOF(AxisDirection.X, DOFType.Free);
            this.Y = (y) ? new DOF(AxisDirection.Y, DOFType.Fixed) : new DOF(AxisDirection.Y, DOFType.Free);
            this.X = (z) ? new DOF(AxisDirection.Z, DOFType.Fixed) : new DOF(AxisDirection.Z, DOFType.Free);
            this.XX = (xx) ? new DOF(AxisDirection.XX, DOFType.Fixed) : new DOF(AxisDirection.XX, DOFType.Free);
            this.YY = (yy) ? new DOF(AxisDirection.YY, DOFType.Fixed) : new DOF(AxisDirection.YY, DOFType.Free);
            this.ZZ = (zz) ? new DOF(AxisDirection.ZZ, DOFType.Fixed) : new DOF(AxisDirection.ZZ, DOFType.Free);
        }

        //Construct a constraint from double. Set -1 to block a DOF, 0 to release, any other number is assumed to be a linear spring constant. 
        //Any linear contraint types can be constructed using this.
        public Constraint(double x, double y, double z, double xx, double yy, double zz)
            :this()
        {
            this.X = (x == -1) ? new DOF(AxisDirection.X, DOFType.Fixed, x) : (x == 0) ? new DOF(AxisDirection.X, DOFType.Free, x) : new DOF(AxisDirection.X, DOFType.Spring, x);
            this.Y = (y == -1) ? new DOF(AxisDirection.Y, DOFType.Fixed, y) : (y == 0) ? new DOF(AxisDirection.Y, DOFType.Free, y) : new DOF(AxisDirection.Y, DOFType.Spring, y);
            this.Z = (z == -1) ? new DOF(AxisDirection.Z, DOFType.Fixed, z) : (z == 0) ? new DOF(AxisDirection.Z, DOFType.Free, z) : new DOF(AxisDirection.Z, DOFType.Spring, z);
            this.XX = (xx == -1) ? new DOF(AxisDirection.XX, DOFType.Fixed, xx) : (xx == 0) ? new DOF(AxisDirection.XX, DOFType.Free, xx) : new DOF(AxisDirection.XX, DOFType.Spring, xx);
            this.YY = (yy == -1) ? new DOF(AxisDirection.YY, DOFType.Fixed, yy) : (yy == 0) ? new DOF(AxisDirection.YY, DOFType.Free, yy) : new DOF(AxisDirection.YY, DOFType.Spring, yy);
            this.ZZ = (zz == -1) ? new DOF(AxisDirection.ZZ, DOFType.Fixed, zz) : (zz == 0) ? new DOF(AxisDirection.ZZ, DOFType.Free, zz) : new DOF(AxisDirection.ZZ, DOFType.Spring, zz); 
        }

        public void SetFixed()
        {
            this.X = new DOF(AxisDirection.X, DOFType.Fixed, -1);
            this.Y = new DOF(AxisDirection.Y, DOFType.Fixed, -1);
            this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
            this.XX = new DOF(AxisDirection.XX, DOFType.Fixed, -1);
            this.YY = new DOF(AxisDirection.YY, DOFType.Fixed, -1);
            this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Fixed, -1);
        }

        public void SetPinned()
        {
            this.X = new DOF(AxisDirection.X, DOFType.Fixed, -1);
            this.Y = new DOF(AxisDirection.Y, DOFType.Fixed, -1);
            this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
            this.XX = new DOF(AxisDirection.XX, DOFType.Free, 0);
            this.YY = new DOF(AxisDirection.YY, DOFType.Free, 0);
            this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Free, 0);
        }

        public void SetSliding()
        {
            this.X = new DOF(AxisDirection.X, DOFType.Free, 0);
            this.Y = new DOF(AxisDirection.Y, DOFType.Free, 0);
            this.Z = new DOF(AxisDirection.Z, DOFType.Fixed, -1);
            this.XX = new DOF(AxisDirection.XX, DOFType.Free, 0);
            this.YY = new DOF(AxisDirection.YY, DOFType.Free, 0);
            this.ZZ = new DOF(AxisDirection.ZZ, DOFType.Free, 0);
        }


        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetType(ConstraintType type)
        {
            this.Type = type;
        }

        public BHoM.Structural.Restraint ToRestraint()
        {
            BHoM.Structural.Restraint restraint = new Restraint();
            restraint.X = this.X;
            restraint.Y = this.Y;
            restraint.Z = this.Z;
            restraint.XX = this.XX;
            restraint.YY = this.YY;
            restraint.ZZ = this.ZZ;
            return restraint;
        }

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

    public class DOF
    {
        public AxisDirection Direction { get; set; }
        public DOFType Type { get; set; }
        public double Value { get; set; }
        public object NonLinearModel { get; set; }
        
        public DOF(AxisDirection direction, DOFType type)
        {
            this.Direction = direction;
            this.Type = type;
        }

        public DOF(AxisDirection direction, DOFType type, double Value)
        {
            this.Direction = direction;
            this.Type = type;
            this.Value = Value;
        }

        public DOF(AxisDirection direction, DOFType type, object Value)
        {
            this.Direction = direction;
            this.Type = type;
            this.NonLinearModel = Value;
        }
     }

    [Serializable]
    public class ConstraintId : ISerializable
    {
        public string Name { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name, typeof(string));
        }

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
