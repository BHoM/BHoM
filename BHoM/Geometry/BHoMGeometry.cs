using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BHoM.Geometry
{
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
