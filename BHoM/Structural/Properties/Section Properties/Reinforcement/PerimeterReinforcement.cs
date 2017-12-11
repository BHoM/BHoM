using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Perimeter Reinforcement is aimed at columns and is only valid on rectangular and circular sections
    /// </summary>
    public class PerimeterReinforcement : Reinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ReoPattern Pattern { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PerimeterReinforcement()
        {

        }

        public PerimeterReinforcement(double diameter, int count, ReoPattern pattern)
        {
            Diameter = diameter;
            BarCount = count;
            Pattern = pattern;
        }


        ///***************************************************/
        ///**** Override Reinforcement                    ****/
        ///***************************************************/

        //public override bool IsLongitudinal()
        //{
        //    return true;
        //}

        ///***************************************************/

        //public override IBHoMGeometry GetLayout(ConcreteSection property, bool extrude = false)
        //{
        //    //double d = property.TotalDepth;
        //    //double w = property.TotalWidth;
        //    //double tieDiameter = property.TieDiameter;
        //    GeometryGroup<Point> location = new GeometryGroup<Point>();
        //    //if (property.Shape == ShapeType.Rectangle) //Rectangle
        //    //{
        //    //    int topCount = 0;
        //    //    int sideCount = 0;
        //    //    double tieOffset = tieDiameter + Math.Cos(Math.PI/ 4) * (2 * tieDiameter * (Math.Sqrt(2) - 1) + Diameter / 2) - Diameter / 2;
        //    //    switch (Pattern)
        //    //    {
        //    //        case ReoPattern.Equispaced:
        //    //            topCount = (int)(BarCount * w / (2 * w + 2 * d) + 1);
        //    //            sideCount = (BarCount - 2 * topCount) / 2 + 2;
        //    //            break;
        //    //        case ReoPattern.Horizontal:
        //    //            topCount = BarCount / 2;
        //    //            sideCount = 2;
        //    //            break;
        //    //        case ReoPattern.Vertical:
        //    //            topCount = 2;
        //    //            sideCount = BarCount / 2;
        //    //            break;                        
        //    //    }
        //    //    double verticalSpacing = (d - 2 * property.MinimumCover - Diameter - 2 * tieOffset) / (sideCount - 1);
        //    //    double depth = property.MinimumCover + Diameter / 2 + tieOffset;
        //    //    for (int i = 0; i < sideCount; i++)
        //    //    {
        //    //        int count = topCount;
        //    //        double currentDepth = depth + i * verticalSpacing;
        //    //        if (i > 0 && i < sideCount - 1)
        //    //        {
        //    //            count = 2;
        //    //        }
        //    //        Group<Point> layout = new LayerReinforcement(Diameter, currentDepth, count).GetLayout(property) as Group<Point>;

        //    //        location.AddRange(layout);
        //    //    }
        //    //}
        //    //else if (property.Shape == ShapeType.Circle) //Circular
        //    //{
        //    //    double angle = Math.PI * 2 / BarCount;
        //    //    double startAngle = 0;
        //    //    double radius = d / 2 - property.MinimumCover - Diameter / 2;
        //    //    switch (Pattern)
        //    //    {
        //    //        case ReoPattern.Horizontal:
        //    //            startAngle = angle / 2;
        //    //            break;
        //    //    }
        //    //    for (int i = 0; i < BarCount; i++)
        //    //    {
        //    //        double x = Math.Cos(startAngle + angle * i) * radius;
        //    //        double y = Math.Sin(startAngle + angle * i) * radius;
        //    //        location.Add(new Point(x, y, 0));
        //    //    }

        //    //}
        //    return location;
        //}
    }


}
