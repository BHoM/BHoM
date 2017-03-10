using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BHoM.Geometry
{
    public enum GeometryType  // Why do we need this?
    {
        Point,
        Vector,
        Plane,
        Mesh,
        Arc,
        Circle,
        Line,
        Polyline,
        PolyCurve,
        NurbCurve,
        Surface,
        Loft,
        Pipe,
        Extrusion,
        PolySurface,
        Group
    }

    public abstract class BHoMGeometry
    {
        //public Guid Id { get; set; }
        public abstract GeometryType GeometryType { get; }        
        internal BHoMGeometry() { /*Id = Guid.NewGuid();*/ }

        public abstract Geometry.BoundingBox Bounds();
        public abstract void Update();
        public abstract BHoMGeometry Duplicate();

        /// <summary>Create a shallow copy of the object</summary>
        public BHoMGeometry ShallowClone()
        {
            return (BHoMGeometry)this.MemberwiseClone();
        }
    }
}
