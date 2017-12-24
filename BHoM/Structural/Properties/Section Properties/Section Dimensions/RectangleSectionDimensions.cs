using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class RectangleSectionDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Rectangle;

        /***************************************************/

        public double Height { get; }

        /***************************************************/

        public double Width { get; }

        /***************************************************/

        public double CornerRadius { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public RectangleSectionDimensions(double height, double width, double cornerRadius)
        {
            Height = height;
            Width = width;
            CornerRadius = cornerRadius;
        }

    }
}
