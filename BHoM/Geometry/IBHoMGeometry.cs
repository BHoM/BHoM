using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BH.oM.Geometry
{
    public interface IBHoMGeometry : ICloneable
    {
        GeometryType GetGeometryType();      

        BoundingBox GetBounds();

        IBHoMGeometry GetTranslated(Vector v);

        /// <summary>Create a shallow copy of the object</summary>
        //public IBHoMGeometry ShallowClone()
        //{
        //    return (IBHoMGeometry)this.MemberwiseClone();
        //}
    }
}
