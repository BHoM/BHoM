using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Base;
using System.Reflection;

namespace BHoM.Geometry
{
    public enum GeometryType
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

    public abstract class GeometryBase
    {
        public Guid Id { get; set; }
        public abstract GeometryType GeometryType { get; }        
        internal GeometryBase() { Id = Guid.NewGuid(); }

        public abstract BoundingBox Bounds();
        public abstract void Update();
        public abstract GeometryBase Duplicate();

        /// <summary>Create a shallow copy of the object</summary>
        public GeometryBase ShallowClone()
        {
            return (GeometryBase)this.MemberwiseClone();
        }
    }
}
