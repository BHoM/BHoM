using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public abstract class GeometryBase
    {
        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }
        public abstract BoundingBox Bounds();
        public abstract void Transform(Transform t);
        public abstract void Translate(Vector v);
        public abstract void Mirror(Plane p);
        public abstract void Project(Plane p);
        public abstract void Update();
        public abstract GeometryBase Duplicate();

        public abstract string ToJSON();
        public static GeometryBase FromJSON()
        {
            return null;
        }
    }
}
