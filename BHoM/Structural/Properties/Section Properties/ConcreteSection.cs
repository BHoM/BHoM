using BH.oM.Geometry;
using BH.oM.Geometry.Curve;
using BH.oM.Materials;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties  //TODO: Only one class per file
{
    public enum ReoPattern
    {
        Equispaced,
        Horizontal,
        Vertical
    }


    public abstract class Reinforcement : BH.oM.Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Diameter { get; set; }
        public int BarCount { get; set; }

        public Material Material { get; set; }

        [DisplayName("StartLocation")]
        [Description("location of the beginning of the reinforcement as a ratio of the bar length")]
        public double StartLocation { get; set; } = 0;

        [DisplayName("EndLocation")]
        [Description("location of the end of the reinforcement as a ratio of the bar length")]
        public double EndLocation { get; set; } = 1;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Reinforcement() { }

        /***************************************************/

        public Reinforcement(double diameter, int barCount)
        {
            Diameter = diameter;
            BarCount = barCount;
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        public abstract bool IsLongitudinal();

        /***************************************************/

        public abstract IBHoMGeometry GetLayout(ConcreteSection property, bool extrude = false);

        /***************************************************/

        public virtual List<double> Location(ConcreteSection property, double location, double axis)
        {
            List<double> result = new List<double>();
            if (location >= StartLocation && location <= EndLocation)
            {
                GeometryGroup<Point> geom = GetLayout(property, false) as GeometryGroup<Point>;
                foreach (Point p in geom.Elements)
                {
                    if (axis == 0)
                    {
                        result.Add(p.X);
                    }
                    else
                    {
                        result.Add(p.Y);
                    }
                }
            }
            return result;
        }
    }



    public class LayerReinforcement : Reinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Depth { get; set; }

        [DisplayName("IsVertical")]
        [Description("Set as vertical reinforcement layer")]
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


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** Override Reinforcement                    ****/
        /***************************************************/

        public override bool IsLongitudinal()
        {
            return true;
        }

        /***************************************************/

        public override IBHoMGeometry GetLayout(ConcreteSection property, bool extrude = false)
        {
            //double relativeDepth = IsVertical ? property.Edges.GetBounds().Max.X - Depth : property.Edges.GetBounds().Max.Y - Depth;
            //double[] range = null;
            //double tieDiameter = property.TieDiameter;
            //if (property.Shape == ShapeType.Rectangle)
            //{
            //    tieDiameter = tieDiameter + Math.Cos(Math.PI / 4) * (2 * tieDiameter * (Math.Sqrt(2) - 1) + Diameter / 2) - Diameter / 2;
            //}
            //double width = 0;// IsVertical ? property.DepthAt(relativeDepth, ref range) : property.WidthAt(relativeDepth, ref range);

            //double spacing = (width - 2 * property.MinimumCover - Diameter - 2 * tieDiameter) / (BarCount - 1.0);
            //double start = range != null && range.Length > 0 ? range[0] : 0;
            GeometryGroup<Point> location = new GeometryGroup<Point>();
            //for (int i = 0; i < BarCount; i++)
            //{
            //    double x = IsVertical ? relativeDepth : property.MinimumCover + Diameter / 2 + tieDiameter + spacing * i + start;
            //    double y = IsVertical ? property.MinimumCover + Diameter / 2 + spacing * i + tieDiameter + start : relativeDepth;

            //    location.Add(new Point(x, y, 0));
            //}
            return location;
        }
    }






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


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** Override Reinforcement                    ****/
        /***************************************************/

        public override bool IsLongitudinal()
        {
            return true;
        }

        /***************************************************/

        public override IBHoMGeometry GetLayout(ConcreteSection property, bool extrude = false)
        {
            //double d = property.TotalDepth;
            //double w = property.TotalWidth;
            //double tieDiameter = property.TieDiameter;
            GeometryGroup<Point> location = new GeometryGroup<Point>();
            //if (property.Shape == ShapeType.Rectangle) //Rectangle
            //{
            //    int topCount = 0;
            //    int sideCount = 0;
            //    double tieOffset = tieDiameter + Math.Cos(Math.PI/ 4) * (2 * tieDiameter * (Math.Sqrt(2) - 1) + Diameter / 2) - Diameter / 2;
            //    switch (Pattern)
            //    {
            //        case ReoPattern.Equispaced:
            //            topCount = (int)(BarCount * w / (2 * w + 2 * d) + 1);
            //            sideCount = (BarCount - 2 * topCount) / 2 + 2;
            //            break;
            //        case ReoPattern.Horizontal:
            //            topCount = BarCount / 2;
            //            sideCount = 2;
            //            break;
            //        case ReoPattern.Vertical:
            //            topCount = 2;
            //            sideCount = BarCount / 2;
            //            break;                        
            //    }
            //    double verticalSpacing = (d - 2 * property.MinimumCover - Diameter - 2 * tieOffset) / (sideCount - 1);
            //    double depth = property.MinimumCover + Diameter / 2 + tieOffset;
            //    for (int i = 0; i < sideCount; i++)
            //    {
            //        int count = topCount;
            //        double currentDepth = depth + i * verticalSpacing;
            //        if (i > 0 && i < sideCount - 1)
            //        {
            //            count = 2;
            //        }
            //        Group<Point> layout = new LayerReinforcement(Diameter, currentDepth, count).GetLayout(property) as Group<Point>;

            //        location.AddRange(layout);
            //    }
            //}
            //else if (property.Shape == ShapeType.Circle) //Circular
            //{
            //    double angle = Math.PI * 2 / BarCount;
            //    double startAngle = 0;
            //    double radius = d / 2 - property.MinimumCover - Diameter / 2;
            //    switch (Pattern)
            //    {
            //        case ReoPattern.Horizontal:
            //            startAngle = angle / 2;
            //            break;
            //    }
            //    for (int i = 0; i < BarCount; i++)
            //    {
            //        double x = Math.Cos(startAngle + angle * i) * radius;
            //        double y = Math.Sin(startAngle + angle * i) * radius;
            //        location.Add(new Point(x, y, 0));
            //    }

            //}
            return location;
        }
    }





    public class TieReinforcement : Reinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Spacing { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** Override Reinforcement                    ****/
        /***************************************************/

        public override bool IsLongitudinal()
        {
            return false;
        }

        /***************************************************/

        public override IBHoMGeometry GetLayout(ConcreteSection property, bool extrude = false)
        {
            double tieDiameter = property.GetTieDiameter();
            switch (property.Shape)
            {
                case ShapeType.Rectangle:
                    double X = property.TotalWidth / 2 - property.MinimumCover - tieDiameter * 3;
                    double Y = property.TotalDepth / 2 - property.MinimumCover - tieDiameter * 3;
                    double yIn = property.TotalDepth / 2 - property.MinimumCover - tieDiameter / 2;
                    double xIn = property.TotalWidth / 2 - property.MinimumCover - tieDiameter / 2;
                    /*TEMP****************

                    Group<Curve> curves = new Group<Curve>();
                    curves.Add(new Line(new Point(-X, yIn, 0), new Point(X, yIn, 0)));
                    curves.Add(new Line(new Point(-X, -yIn, 0), new Point(X, -yIn, 0)));
                    curves.Add(new Line(new Point(xIn, -Y, 0), new Point(xIn, Y, -tieDiameter)));
                    curves.Add(new Line(new Point(-xIn, -Y, 0), new Point(-xIn, Y, 0)));
                    Plane p = new Plane(new Point(-X, -Y, 0), Vector.ZAxis());
                    curves.Add(new Arc(Math.PI * 3 / 2, Math.PI, tieDiameter * 2.5, p));
                    p = new Plane(new Point(-X, Y, 0), Vector.ZAxis());
                    curves.Add(new Arc(Math.PI, Math.PI / 2, tieDiameter * 2.5, p));
                    p = new Plane(new Point(X, Y, 0), Vector.ZAxis());
                    Vector lap = new Vector(-tieDiameter * 3.5, -tieDiameter * 3.5, 0);
                    Arc a1 = new Arc(Math.PI / 2, -Math.PI / 4, tieDiameter * 2.5, p);
                    curves.Add(a1);
                    curves.Add(new Line(a1.EndPoint, a1.EndPoint + lap));
                    p = new Plane(new Point(X, Y, -tieDiameter), Vector.ZAxis());
                    Arc a2 = new Arc(0, 3 * Math.PI / 4, tieDiameter * 2.5, p);
                    curves.Add(a2);
                    curves.Add(new Line(a2.EndPoint, a2.EndPoint + lap));
                    p = new Plane(new Point(X, -Y, 0), Vector.ZAxis());
                    curves.Add(new Arc(0, -Math.PI / 2, tieDiameter * 2.5, p));

                    Curve c = Curve.Join(curves)[0];

                    double width = property.TotalWidth - 2 * property.MinimumCover - tieDiameter;
                    double spacing = width / (BarCount - 1);
                    Curve singleTie = null;
                    if (BarCount > 2)
                    {
                        List<Curve> crvs = new List<Curve>();
                        double startAngle = 0;
                        double endAngle = Math.PI * 3 / 4;                       
                        Vector lap2 = lap.DuplicateVector();
                        p = new Plane(new Point(0, property.TotalDepth / 2 - property.MinimumCover - 3 * tieDiameter, -tieDiameter), Vector.ZAxis());
                        a1 = new Arc(startAngle, endAngle, 2.5 * tieDiameter, p);
                        a2 = a1.DuplicateCurve() as Arc;
                        a2.Mirror(Plane.XZ());
                        lap2.Mirror(Plane.XZ());
                        crvs.Add(new Line(a1.StartPoint, a2.StartPoint));
                        crvs.Add(new Line(a1.EndPoint, a1.EndPoint + lap));
                        crvs.Add(new Line(a2.EndPoint, a2.EndPoint + lap2));
                        crvs.Add(a1);
                        crvs.Add(a2);
                        singleTie = Curve.Join(crvs)[0];
                    }

                    Group<Pipe> bars = new Group<Pipe>();
                    bars.Add(new Pipe(c, tieDiameter / 2));
                    for (int i = 0; i < BarCount - 2; i++)
                    {
                        c = singleTie.DuplicateCurve();
                        double location = -width / 2 + (i + 1) * spacing;
                        //if (location < 0)
                        //{
                        //    c.Mirror(Plane.YZ());
                        //}
                        //TEMP UNDO c.Translate(Vector.XAxis(location));
                        bars.Add(new Pipe(c, tieDiameter / 2));
                    }
                    */
                    return null;//temp bars;

                    //double X = property.TotalWidth / 2 - property.MinimumCover - tieDiameter * 3;
                    //double Y = property.TotalDepth / 2 - property.MinimumCover - tieDiameter * 3;
                    //double yIn = property.TotalDepth / 2 - property.MinimumCover - tieDiameter;
                    //double yOut = property.TotalDepth / 2 - property.MinimumCover;
                    //double xIn = property.TotalWidth / 2 - property.MinimumCover - tieDiameter;
                    //double xOut = property.TotalWidth / 2 - property.MinimumCover;

                    //Group<Curve> curves = new Group<Curve>();
                    //curves.Add(new Line(new Point(-X, yIn, 0), new Point(X, yIn, 0)));
                    //curves.Add(new Line(new Point(-X, -yIn, 0), new Point(X, -yIn, 0)));
                    //curves.Add(new Line(new Point(-X, yOut, 0), new Point(X, yOut, 0)));
                    //curves.Add(new Line(new Point(-X, -yOut, 0), new Point(X, -yOut, 0)));
                    //curves.Add(new Line(new Point(xIn, -Y, 0), new Point(xIn, Y, 0)));
                    //curves.Add(new Line(new Point(-xIn, -Y, 0), new Point(-xIn, Y, 0)));
                    //curves.Add(new Line(new Point(xOut, -Y, 0), new Point(xOut, Y, 0)));
                    //curves.Add(new Line(new Point(-xOut, -Y, 0), new Point(-xOut, Y, 0)));
                    //Plane p = new Plane(new Point(-X,-Y,0), Vector.ZAxis());
                    //curves.Add(new Arc(Math.PI * 3 / 2, Math.PI, tieDiameter * 2, p));
                    //curves.Add(new Arc(Math.PI * 3 / 2, Math.PI, tieDiameter * 3, p));
                    //p = new Plane(new Point(-X, Y, 0), Vector.ZAxis());
                    //curves.Add(new Arc(Math.PI, Math.PI / 2, tieDiameter * 2, p));
                    //curves.Add(new Arc(Math.PI, Math.PI / 2, tieDiameter * 3, p));
                    //p = new Plane(new Point(X, Y, 0), Vector.ZAxis());
                    //curves.Add(new Arc(Math.PI / 2, 0, tieDiameter * 2, p));
                    //curves.Add(new Arc(Math.PI / 2, 0, tieDiameter * 3, p));
                    //p = new Plane(new Point(X, -Y, 0), Vector.ZAxis());
                    //curves.Add(new Arc(0, -Math.PI / 2, tieDiameter * 2, p));
                    //curves.Add(new Arc(0, -Math.PI / 2, tieDiameter * 3, p));
                    //return new Group<Curve>(Curve.Join(curves));
            }

            return null;
        }

    }



    

    public class ConcreteSection : SectionProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Reinforcement> Reinforcement { get; set; } = new List<Properties.Reinforcement>();
        public double MinimumCover { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ConcreteSection() { }

        /***************************************************/

        /// <summary>
        /// Create a section property from a list of edges, shape type and material
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="sType"></param>
        /// <param name="mType"></param>
        public ConcreteSection(IEnumerable<ICurve> edges, ShapeType sType) : this()
        {
            Edges = edges.ToList();
            Shape = sType;
            //SectionMaterial = mType;
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        public double GetTieDiameter()
        {
            foreach(Reinforcement reo in Reinforcement)
            {
                if (reo is TieReinforcement)
                {
                    return reo.Diameter;
                }
            }
            return 0;
        }

        /***************************************************/

        public IBHoMGeometry GetReinforcementLayout(double xStart = 0, double xEnd = 1)
        {
            GeometryGroup<IBHoMGeometry> geometry = new GeometryGroup<IBHoMGeometry>();
            //foreach (Reinforcement reo in Reinforcement)
            //{
            //    IBHoMGeometry layout = reo.GetLayout(this);
            //    if (typeof(IGroup).IsAssignableFrom(layout.GetType()))
            //    {
            //        foreach (IBHoMGeometry obj in ((IGroup)layout).Objects)
            //        {
            //            if (obj is Point)
            //            {
            //                geometry.Add(new Circle(reo.Diameter / 2, new Plane(obj as Point, Vector.ZAxis())));
            //            }
            //            else
            //            {
            //                geometry.Add(obj);
            //            }                       
            //        }
            //    }
            //    else
            //    {
            //        geometry.Add(layout);
            //    }
            //}
            return geometry;
        }


        /***************************************************/
        /**** Override BHoMObject                       ****/
        /***************************************************/

        public override IBHoMGeometry GetGeometry()
        {
            return new GeometryGroup<IBHoMGeometry>(new List<IBHoMGeometry> {
                GetReinforcementLayout(),
                base.GetGeometry()
            });
        }
    }
}
