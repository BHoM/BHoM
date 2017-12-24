using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class TubeDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Tube;

        /***************************************************/

        public double Diameter { get; }

        /***************************************************/

        public double Thickness { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TubeDimensions(double diameter, double thickness)
        {
            Diameter = diameter;
            Thickness = thickness;
        }

    }
}
