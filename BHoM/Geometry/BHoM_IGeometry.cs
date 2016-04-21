using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public interface IGeometry
    {
        Guid Id { get; }
        BoundingBox Bounds();
        void Transform(Transform t);
        void Translate(Vector v);
        void Mirror(Plane p);
        void Project(Plane p);
        void Update();
        IGeometry Duplicate();        
    }
}
