using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class SurfaceArray : IGeometry
    {
        public BoundingBox Bounds()
        {
            throw new NotImplementedException();
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGeometry Duplicate()
        {
            throw new NotImplementedException();
        }

        public void Mirror(Plane p)
        {
            throw new NotImplementedException();
        }

        public void Project(Plane p)
        {
            throw new NotImplementedException();
        }

        public void Transform(Transform t)
        {
            throw new NotImplementedException();
        }

        public void Translate(Vector v)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
