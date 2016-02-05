using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Geometry;

namespace BHoM.Structural
{
    [Serializable]
    public class Node
    {
        public int Number { get; private set; }
        public Point Position { get; private set; }
        public Constraint Constraint { get; private set; }
        public bool IsRestrained { get; private set; }
        public string ConstraintName { get; private set; }
        public string Name { get; private set;}
        public List<Bar> ConnectedBars { get; private set; }
        public List<Face> ConnectedFaces { get; private set; }
        public int Valence { get; private set; }
        public List<double> Angles { get; private set; }
        public Plane CoordinateSystem { get; private set; }
        
        public Node()
        {
            Position = new Point();
            Number = -1;
            Name = "";
            ConnectedBars = new List<Bar>();
            ConnectedFaces = new List<Face>();
        }
        
        public Node(int index)
            :this()
        {
            Number = index;
        }
        
        public Node(Point pos)
            : this()
        {
            Position = pos.Duplicate(); ;
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
            Position = new Point(x, y, z);       
        }

        public Node(double x, double y, double z, int index)
            :this(x,y,z)
        {
            Number = index;
        }

  
        public bool IsValid
        {
            get
            {
                if (Number < 0) { return false; }
                if (!Position.IsValid) { return false; }
                return true;
            }
        }

        public bool HasValidNumber()
        {
            return Number > 0; 
        }

        public void SetNumber(int i)
        {
            this.Number = i;
        }

        public double[] XYZ
        {
            get { return Position.XYZ; }
            set { Position.XYZ = value;}
        }

        public double X
        {
            get { return Position.X; }
            set
            { 
                Position.X = value; 
            }
        }

        public double Y
        {
            get { return Position.Y; }
            set
            {
                Position.Y = value;
            }
        }

        public double Z
        {
            get { return Position.Z; }
            set
            {
                Position.Z = value;
            }
        }

               
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

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetConstraint(Constraint constraint)
        {
            this.Constraint = constraint;
            this.ConstraintName = constraint.Name;
            this.IsRestrained = true;
        }

        public void SetConstraintName(string constraintName)
        {
            this.ConstraintName = constraintName;
            this.IsRestrained = true;
        }

        public void SetCoordinateSystemAsDefault()
        {
            this.CoordinateSystem = new Plane(Position);
        }

        public void SetCoordinateSystem(Plane coordinateSystem)
        {
            this.CoordinateSystem = coordinateSystem;
        }

        /// <summary>
        /// 
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
            Vector v0 = nodeRing[0].Position - this.Position;
            angleAccumulator.Add(0.0);
            for (int i = 1; i < Valence; i++)
            {
                Vector v1 = nodeRing[i].Position - this.Position;
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
    
