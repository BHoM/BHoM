using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    [Serializable] public class PolygonDimensions : BHoMObject, ISectionDimensions, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Polygon;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PolygonDimensions() { }
    }
}
