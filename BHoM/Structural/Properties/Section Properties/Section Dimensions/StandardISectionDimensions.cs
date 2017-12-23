using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    [Serializable] public class StandardISectionDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.ISection;

        /***************************************************/

        public double Height { get; }

        /***************************************************/

        public double Width { get; }

        /***************************************************/

        public double WebThickness { get; }

        /***************************************************/

        public double FlangeThickness { get; }

        /***************************************************/

        public double RootRadius { get; }

        /***************************************************/

        public double ToeRadius { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public StandardISectionDimensions(double height, double width, double webthickness, double flangeThickness, double rootRadius, double toeRadius)
        {
            Height = height;
            Width = width;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
        }

    }
}
