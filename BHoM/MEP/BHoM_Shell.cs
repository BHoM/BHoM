using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;

namespace BHoM.MEP
{
    public abstract class Shell
    {
        public abstract Mesh Mesh
        {
            get;
        }

        public virtual string JSON()
        {
            Mesh aMesh = Mesh;
            string aResult = "{";
            aResult += string.Format("\"{0}\": \"{1}\", ", "primitive", "mesh");
            aResult += string.Format("\"{0}\": {1}", "vertices", "[");
            foreach (Point aVertice in aMesh.Vertices)
            {
                aResult += string.Format("[{0},{1},{2}],", aVertice.X, aVertice.Y, aVertice.Z);
            }
            if (aResult.Last() == ',')
                aResult = aResult.Substring(0, aResult.Length - 1);
            aResult += "], ";
            aResult += string.Format("\"{0}\": {1}", "faces", "[");
            foreach (int[] aFace in aMesh.Faces)
            {
                aResult += "[";
                foreach (int aIndex in aFace)
                {
                    aResult += (aIndex - 1).ToString() + ",";
                }
                if (aResult.Last() == ',')
                    aResult = aResult.Substring(0, aResult.Length - 1);
                aResult += "],";
            }
            if (aResult.Last() == ',')
                aResult = aResult.Substring(0, aResult.Length - 1);
            aResult += "]";
            aResult += "}";
            return aResult;
        }
    }

    public class ClosedShell : Shell
    {
        private Mesh pMesh;

        public ClosedShell(Mesh Mesh)
        {
            pMesh = Mesh;
        }

        public override Mesh Mesh
        {
            get
            {
                return pMesh;
            }
       }
    }

    public class SpatialShell : Shell
    {
        private List<SpatialBoundary> pSpatialBoundaries;

        public SpatialShell()
        {
            pSpatialBoundaries = new List<SpatialBoundary>();
        }

        public void Add(SpatialBoundary SpatialBoundary)
        {
            pSpatialBoundaries.Add(SpatialBoundary);
        }

        public List<SpatialBoundary> SpatialBoundaries
        {
            get
            {
                return pSpatialBoundaries;
            }
        }

        public override Mesh Mesh
        {
            get
            {
                Mesh aResult = new Mesh();
                List<List<Point>> aTriangleList = new List<List<Point>>();
                foreach(SpatialBoundary aSpatialBoundary in pSpatialBoundaries)
                {
                    Mesh aMesh = aSpatialBoundary.Mesh;
                    foreach(int[] aFaces in aMesh.GetFaces())
                    {
                        List<Point> aPointList = new List<Point>();
                        foreach (int aIndex in aFaces)
                        {
                            aPointList.Add(aMesh.Vertices[aIndex - 1]);
                        }
                        aTriangleList.Add(aPointList);
                    }
                }
                for (int i = 0; i < aTriangleList.Count; i++)
                {
                    aResult.AddVertice(aTriangleList[i][0]);
                    aResult.AddVertice(aTriangleList[i][1]);
                    aResult.AddVertice(aTriangleList[i][2]);

                    aResult.AddFace(new int[] { (i * 3) + 1, (i * 3) + 2, (i * 3) + 3 });
                }
                return aResult;
            }
        }
    }

    public class SpatialBoundary
    {
        private Element pElement;
        private Mesh pMesh;

        public SpatialBoundary(Element Element, Mesh Mesh)
        {
            pElement = Element;
            pMesh = Mesh;
        }

        public Element Element
        {
            get
            {
                return pElement;
            }
        }

        public Mesh Mesh
        {
            get
            {
                return pMesh;
            }
        }
    }
}
