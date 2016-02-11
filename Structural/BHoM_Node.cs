using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Geometry;

namespace BHoM.Structural
{
    /// <summary>
    /// Node objects
    /// </summary>
    [Serializable]
    public class Node : IStructuralObject
    {
        /////////////////
        ////Properties///
        /////////////////

        /// <summary>BHoM object ID</summary>
        public Guid BHoM_ID { get { return BHoM_ID; } private set { SetBHoM_ID(); } }

        /// <summary>Node number</summary>
        public int Number { get; private set; }

        /// <summary>Node name</summary>
        public string Name { get; private set; }

        /// <summary>BHoM User Test</summary>
        public string UserText { get { return UserText; } set { UserText = value; } }

        /// <summary>Node position as a point object</summary>
        public Point Point { get; private set; }

        /// <summary>Node constraint (support/restraint)</summary>
        public BHoM.Structural.Constraint Constraint { get; private set; }

        /// <summary>Returns true is node is constrained</summary>
        public bool IsConstrained { get; private set; }

        /// <summary>Constraint name - is inherited from constraint object if exists</summary>
        public string ConstraintName { get; private set; }

        /// <summary>Bars connected to the node</summary>
        public List<Bar> ConnectedBars { get; private set; }

        /// <summary>Faces connected to the node</summary>
        public List<Face> ConnectedFaces { get; private set; }

        /// <summary>Valence of node</summary>
        public int Valence { get; private set; }

        /// <summary>Angles between connected bars</summary>
        public List<double> Angles { get; private set; }

        /// <summary>Coordinate system as a plane object</summary>
        public Plane CoordinateSystem { get; private set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Constructs an empty node object
        /// </summary>
        public Node()
        {
            Point = new Point();
            Number = -1;
            Name = "";
            ConnectedBars = new List<Bar>();
            ConnectedFaces = new List<Face>();
            SetBHoM_ID();
        }

        /// <summary>
        /// Constructs an empty node from a number
        /// </summary>
        /// <param name="number"></param>
        public Node(int number)
            :this()
        {
            Number = number;
        }

        /// <summary>
        /// Constructes a node from a point
        /// </summary>
        /// <param name="point"></param>
        public Node(Point point)
            : this()
        {
            Point = point.Duplicate(); 
        }

        /// <summary>
        /// Represents a three dimensional node in space. Holds results.
        /// </summary>
        /// <param name="x">The x coordinate for the node</param>
        /// <param name="y">The y coordinate for the node</param>
        /// <param name="z">The z coordinate for the node</param>
        public Node(double x, double y, double z)
            :this()
        {
            Point = new Point(x, y, z);
        }

        /// <summary>
        /// Constructes a node from coordinates and an index number
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="number"></param>
        public Node(double x, double y, double z, int number)
            :this(x,y,z)
        {
            Number = number;
        }

        /// <summary>
        /// Returns true if node is valid (number less than 0 or position is invalid)
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (Number < 0) { return false; }
                if (!Point.IsValid) { return false; }
                return true;
            }
        }

        /// <summary>
        /// Returns true if node number is greater than 0
        /// </summary>
        /// <returns></returns>
        public bool HasValidNumber()
        {
            return Number > 0; 
        }

        //////////////
        ////Methods///
        //////////////

        /// <summary>
        /// Sets the unique object ID
        /// </summary>
        private void SetBHoM_ID()
        {
            this.BHoM_ID = new Guid();
        }

        /// <summary>
        /// Sets the node number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Gets or sets the XYZ of the node position
        /// </summary>
        public double[] XYZ
        {
            get { return Point.XYZ; }
            set { Point.XYZ = value;}
        }

        /// <summary>
        /// Gets or sets the X value of the node position
        /// </summary>
        public double X
        {
            get { return Point.X; }
            set
            { 
                Point.X = value; 
            }
        }

        /// <summary>
        /// Gets or sets the Y value of the node position
        /// </summary>
        public double Y
        {
            get { return Point.Y; }
            set
            {
                Point.Y = value;
            }
        }

        /// <summary>
        /// Gets or sets the Z value of the node position
        /// </summary>
        public double Z
        {
            get { return Point.Z; }
            set
            {
                Point.Z = value;
            }
        }

        /// <summary>
        /// Calculates the distance from the input node to this
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public double DistanceTo(Node node)
        {
            double dist = 0;
            double[] target = this.XYZ;
            double[] search = node.XYZ;

            for (int i = 0; i < 3; i++)
            {
                dist += (Math.Pow((target[i] - search[i]), 2));
            }
            dist = Math.Sqrt(dist);
            return dist;
        }

        /// <summary>
        /// Sets the name of the node
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Sets the constraint of a node
        /// </summary>
        /// <param name="constraint"></param>
        public void SetConstraint(BHoM.Structural.Constraint constraint)
        {
            this.Constraint = constraint;
            this.ConstraintName = constraint.Name;
            this.IsConstrained = true;
        }

        /// <summary>
        /// Sets the constraint name of the node
        /// </summary>
        /// <param name="constraintName"></param>
        public void SetConstraintName(string constraintName)
        {
            this.ConstraintName = constraintName;
            this.IsConstrained = true;
        }

        /// <summary>
        /// Sets a default plane as coordinate system
        /// </summary>
        public void SetCoordinateSystemAsDefault()
        {
            this.CoordinateSystem = new Plane(Point);
        }

        /// <summary>
        /// Sets coordinate system as plane
        /// </summary>
        /// <param name="coordinateSystem"></param>
        public void SetCoordinateSystem(Plane coordinateSystem)
        {
            this.CoordinateSystem = coordinateSystem;
        }

        /// <summary>
        /// Resets the topology by removing connected bars and setting valence to 0
        /// </summary>
        public void ResetTopology()
        {
            this.ConnectedBars = new List<Bar>();
            Valence = 0;
        }


        /// <summary>
        /// Add a bar instance into connected bar list
        /// </summary>
        /// <param name="b"></param>
        public void AddBar(Bar b)
        {
            ConnectedBars.Add(b);
        }

        /// <summary>
        /// Add a face instance into connected face list
        /// </summary>
        /// <param name="f"></param>
        public void AddFace(Face f)
        {
            ConnectedFaces.Add(f);
        }


        /// <summary>
        /// WIP
        /// </summary>
        /// <returns></returns>
        public bool SortConnectedBars()
        {
            Valence = ConnectedBars.Count;
            if (Valence < 2) return false;


            List<Node> nodeRing = new List<Node>(Valence);
            foreach (Bar b in ConnectedBars)
                nodeRing.Add(b.GetOtherEnd(this));

            List<double> angleAccumulator = new List<double>(Valence);
            Vector v0 = nodeRing[0].Point - this.Point;
            angleAccumulator.Add(0.0);
            for (int i = 1; i < Valence; i++)
            {
                Vector v1 = nodeRing[i].Point - this.Point;
                double angle = Vector.VectorAngle(v0, v1, CoordinateSystem.Z);
                if (angle < 0) angle += 2.0 * Math.PI;
                angleAccumulator.Add(angle);
            }

            SortBarsByAngle(ConnectedBars, angleAccumulator);
            SetAngles(angleAccumulator);

            return true;
        }



        /// <summary>
        /// WIP - change to use sorted dictionary
        /// Sort the bars by angle, smallest angle first.
        /// Assumes one to one mapping of bars to angles in two lists
        /// </summary>
        /// <param name="bars"></param>
        /// <param name="angles"></param>
        /// <returns></returns>
        private static bool SortBarsByAngle(List<Bar> bars, List<double> angles)
        {
            while (true)
            {
                bool swapped = false;
                for (int i = 0; i < angles.Count - 1; i++)
                    if (angles[i] > angles[i + 1])
                    {
                        double temp = angles[i];
                        angles[i] = angles[i + 1];
                        angles[i + 1] = temp;

                        Bar tempBar = bars[i];
                        bars[i] = bars[i + 1];
                        bars[i + 1] = tempBar;

                        swapped = true;
                    }
                if (!swapped)
                    break;
            }

            return true;
        }

        /// <summary>
        /// WIP
        /// </summary>
        /// <returns></returns>
        private void SetAngles(List<double> angleAccumulator)
        {
            Angles = new List<double>(angleAccumulator.Count);
            for (int i = 1; i < angleAccumulator.Count; i++)
                Angles.Add(angleAccumulator[i] - angleAccumulator[i - 1]);

            Angles.Add(2.0 * Math.PI - angleAccumulator.Last());

        }
     }
}
    
