using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class StandardBoxDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Box;

        /***************************************************/

        public double Height { get; }

        /***************************************************/

        public double Width { get; }

        /***************************************************/

        public double Thickness { get; }

        /***************************************************/

        public double OuterRadius { get; }

        /***************************************************/

        public double InnerRadius { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public StandardBoxDimensions(double height, double width, double thickness, double outerRadius, double innerRadius)
        {
            Height = height;
            Width = width;
            Thickness = thickness;
            OuterRadius = outerRadius;
            InnerRadius = innerRadius;
        }

    }
}
