using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    public class LayerReinforcement : Reinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Depth { get; set; }

        //[DisplayName("IsVertical")]
        //[Description("Set as vertical reinforcement layer")]
        public bool IsVertical { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LayerReinforcement() { }

        /***************************************************/

        public LayerReinforcement(double diameter, double depth, int count)
        {
            Diameter = diameter;
            BarCount = count;
            Depth = depth;
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
        //    //double relativeDepth = IsVertical ? property.Edges.GetBounds().Max.X - Depth : property.Edges.GetBounds().Max.Y - Depth;
        //    //double[] range = null;
        //    //double tieDiameter = property.TieDiameter;
        //    //if (property.Shape == ShapeType.Rectangle)
        //    //{
        //    //    tieDiameter = tieDiameter + Math.Cos(Math.PI / 4) * (2 * tieDiameter * (Math.Sqrt(2) - 1) + Diameter / 2) - Diameter / 2;
        //    //}
        //    //double width = 0;// IsVertical ? property.DepthAt(relativeDepth, ref range) : property.WidthAt(relativeDepth, ref range);

        //    //double spacing = (width - 2 * property.MinimumCover - Diameter - 2 * tieDiameter) / (BarCount - 1.0);
        //    //double start = range != null && range.Length > 0 ? range[0] : 0;
        //    GeometryGroup<Point> location = new GeometryGroup<Point>();
        //    //for (int i = 0; i < BarCount; i++)
        //    //{
        //    //    double x = IsVertical ? relativeDepth : property.MinimumCover + Diameter / 2 + tieDiameter + spacing * i + start;
        //    //    double y = IsVertical ? property.MinimumCover + Diameter / 2 + spacing * i + tieDiameter + start : relativeDepth;

        //    //    location.Add(new Point(x, y, 0));
        //    //}
        //    return location;
        //}
    }
}
