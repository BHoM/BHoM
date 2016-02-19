using System;

namespace BHoM.Structural
{
    /// <summary>
    /// Constraint object - base class for all release, restraint, support classes. 
    /// </summary>
    [Serializable]
    public class Constraint : IStructuralObject
    {
        /////////////////
        ////Properties///
        /////////////////

        /// <summary>Constraint number</summary>
        public int Number { get; private set; }

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
        
        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Construct an empty constraint object
        /// </summary>
        public Constraint()
        {
            this.Number = -1;
            this.Name = "";
        }

        /// <summary>
        /// Construct an empty constraint object with a name
        /// </summary>
        public Constraint(string name)
        {
            this.Number = -1;
            this.Name = name;
        }

        /// <summary>Construct a constraint from DOF objects. Any constraint 
        /// type (linear/non-linear) may be constructed using this.</summary>  
        public Constraint(DOF x, DOF y, DOF z, DOF xx, DOF yy, DOF zz)
            :this()
        {
            this.X = x; this.Y = y; this.Z = z; this.XX = xx; this.YY = yy; this.ZZ = zz;
        }

        /// <summary>Construct a constraint from true/false. True blocks a DOF. 
        /// Only fixed or free constraint types can be constructed using this.</summary>
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

        /// <summary>Construct a constraint from double. Set -1 to block a DOF, 0 to release, 
        /// any other number is assumed to be a linear spring constant. 
        /// Any linear contraint types can be constructed using this.</summary>
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
        
        //////////////
        ////Methods///
        //////////////

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

        /// <summary>
        /// Set the constraint number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.Number = number;
        }


        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        public BHoM.Collections.Dictionary<string, object> GetProperties()
        {
            BHoM.Collections.Dictionary<string, object> PropertiesDictionary = new BHoM.Collections.Dictionary<string, object>();
            PropertiesDictionary.Add("Number", this.Number);
            PropertiesDictionary.Add("Name", this.Name);
            PropertiesDictionary.Add("X", this.X);
            PropertiesDictionary.Add("Y", this.Y);
            PropertiesDictionary.Add("Z", this.Z);
            PropertiesDictionary.Add("XX", this.XX);
            PropertiesDictionary.Add("YY", this.YY);
            PropertiesDictionary.Add("ZZ", this.ZZ);
            PropertiesDictionary.Add("ConstraintType", this.Type);
            //PropertiesDictionary.Add("UserData", this.UserData);
            //PropertiesDictionary.Add("BHoM_Guid", this.BHoM_Guid);

            return PropertiesDictionary;
        }
    }
}
