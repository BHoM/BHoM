using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class CircleDimensions : BHoMObject, ISectionDimensions, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Circle;

        /***************************************************/

        public double Diameter { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public CircleDimensions(double diameter)
        {
            Diameter = diameter;
        }

    }
}
