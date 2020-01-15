using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry.ShapeProfiles;

namespace BH.oM.Structure.SectionProperties
{
    public interface IGeometricalSection : ISectionProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        IProfile SectionProfile { get; }

        /***************************************************/
    }
}
