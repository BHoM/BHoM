using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class PointMatrix
    {
        /***************************************/
        /****  Constructors                 ****/
        /***************************************/

        public PointMatrix(double cellSize)
        {
            m_cellSize = cellSize;
            m_Matrix = new Dictionary<CompositeKey, List<CompositeValue>>();
        }


        /***************************************/
        /****  Public Methods               ****/
        /***************************************/

        public void AddPoint(Point point, object data = null)
        {
            CompositeKey key = GetKey(point);
            if (!m_Matrix.ContainsKey(key))
                m_Matrix[key] = new List<CompositeValue>();
            m_Matrix[key].Add(new CompositeValue(point, data));
        }

        /***************************************/

        public List<CompositeValue> GetClosePoints(Point refPt, double maxDist)
        {
            // Collect all the points within cells in range
            Vector range = new Vector(maxDist, maxDist, maxDist);
            List<CompositeValue> inCells = GetSubMatrixPoints(GetKey(refPt - range), GetKey(refPt + range));

            // Keep only points within maxDist distance of refPt
            List<CompositeValue> result = new List<CompositeValue>();
            foreach (CompositeValue tuple in inCells)
            {
                if (tuple.Point.DistanceTo(refPt) < maxDist)
                    result.Add(tuple);
            }

            // Return final result
            return result;
        }

        /***************************************/

        public List<Tuple<CompositeValue, CompositeValue>> GetRelatedPairs(double minDist, double maxDist)
        {
            int range = (int)Math.Ceiling(maxDist / m_cellSize);

            List<Tuple<CompositeValue, CompositeValue>> result = new List<Tuple<CompositeValue, CompositeValue>>();
            foreach (KeyValuePair<CompositeKey, List<CompositeValue>> kvp in m_Matrix)
            {
                CompositeKey k = kvp.Key;
                List<CompositeValue> closePoints = GetSubMatrixPoints(
                    new CompositeKey(k.X - range, k.Y - range, k.Z - range),
                    new CompositeKey(k.X + range, k.Y + range, k.Z + range));
                
                foreach(CompositeValue value in kvp.Value)
                {
                    foreach(CompositeValue other in closePoints)
                    {
                        double dist = value.Point.DistanceTo(other.Point);
                        if (dist < maxDist && dist > minDist)
                            result.Add(new Tuple<CompositeValue, CompositeValue>(value, other));
                    }
                }

            }

            return result;
        }


        /***************************************/
        /****  Private Fields               ****/
        /***************************************/

        double m_cellSize;
        Dictionary<CompositeKey, List<CompositeValue>> m_Matrix;


        /***************************************/
        /****  Private Methods              ****/
        /***************************************/

        private CompositeKey GetKey(Point point)
        {
            return new CompositeKey((int)Math.Floor(point.X / m_cellSize), (int)Math.Floor(point.Y / m_cellSize), (int)Math.Floor(point.Z / m_cellSize));
        }

        /***************************************/

        private List<CompositeValue> GetSubMatrixPoints(CompositeKey minKey, CompositeKey maxKey)
        {
            List<CompositeValue> inCells = new List<CompositeValue>();
            for (int x = minKey.X; x <= maxKey.X; x++)
            {
                for (int y = minKey.Y; y <= maxKey.Y; y++)
                {
                    for (int z = minKey.Z; z <= maxKey.Z; z++)
                    {
                        CompositeKey key = new CompositeKey(x, y, z);
                        if (m_Matrix.ContainsKey(key))
                        {
                            foreach (CompositeValue comp in m_Matrix[key])
                                inCells.Add(comp);
                        }
                    }
                }
            }

            return inCells;
        }

        /***************************************/
        /****  Private Subclass             ****/
        /***************************************/

        private struct CompositeKey
        {
            public int X;
            public int Y;
            public int Z;

            public CompositeKey(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj is CompositeKey)
                {
                    CompositeKey other = (CompositeKey)obj;
                    return ((this.X == other.X) && (this.Y == other.Y) && (this.Z == other.Z));
                }
                return false;
            }
        }

        /***************************************/

        public struct CompositeValue
        {
            public Point Point;
            public object Data;

            public CompositeValue(Point point, object data = null)
            {
                Point = point;
                Data = data;
            }
        }
    }
}
