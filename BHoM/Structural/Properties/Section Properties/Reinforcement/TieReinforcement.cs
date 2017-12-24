using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class TieReinforcement : Reinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Spacing { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TieReinforcement() { }

        public TieReinforcement(double diameter, double spacing, int count)
        {
            Diameter = diameter;
            Spacing = spacing;
            BarCount = count;
        }

        ///***************************************************/
        ///**** Override Reinforcement                    ****/
        ///***************************************************/

        //public override bool IsLongitudinal()
        //{
        //    return false;
        //}

        ///***************************************************/

        //public override IBHoMGeometry GetLayout(ConcreteSection property, bool extrude = false)
        //{
        //    double tieDiameter = property.GetTieDiameter();
        //    switch (property.Shape)
        //    {
        //        case ShapeType.Rectangle:
        //            double X = property.TotalWidth / 2 - property.MinimumCover - tieDiameter * 3;
        //            double Y = property.TotalDepth / 2 - property.MinimumCover - tieDiameter * 3;
        //            double yIn = property.TotalDepth / 2 - property.MinimumCover - tieDiameter / 2;
        //            double xIn = property.TotalWidth / 2 - property.MinimumCover - tieDiameter / 2;
        //            /*TEMP****************

        //            Group<Curve> curves = new Group<Curve>();
        //            curves.Add(new Line(new Point(-X, yIn, 0), new Point(X, yIn, 0)));
        //            curves.Add(new Line(new Point(-X, -yIn, 0), new Point(X, -yIn, 0)));
        //            curves.Add(new Line(new Point(xIn, -Y, 0), new Point(xIn, Y, -tieDiameter)));
        //            curves.Add(new Line(new Point(-xIn, -Y, 0), new Point(-xIn, Y, 0)));
        //            Plane p = new Plane(new Point(-X, -Y, 0), Vector.ZAxis());
        //            curves.Add(new Arc(Math.PI * 3 / 2, Math.PI, tieDiameter * 2.5, p));
        //            p = new Plane(new Point(-X, Y, 0), Vector.ZAxis());
        //            curves.Add(new Arc(Math.PI, Math.PI / 2, tieDiameter * 2.5, p));
        //            p = new Plane(new Point(X, Y, 0), Vector.ZAxis());
        //            Vector lap = new Vector(-tieDiameter * 3.5, -tieDiameter * 3.5, 0);
        //            Arc a1 = new Arc(Math.PI / 2, -Math.PI / 4, tieDiameter * 2.5, p);
        //            curves.Add(a1);
        //            curves.Add(new Line(a1.EndPoint, a1.EndPoint + lap));
        //            p = new Plane(new Point(X, Y, -tieDiameter), Vector.ZAxis());
        //            Arc a2 = new Arc(0, 3 * Math.PI / 4, tieDiameter * 2.5, p);
        //            curves.Add(a2);
        //            curves.Add(new Line(a2.EndPoint, a2.EndPoint + lap));
        //            p = new Plane(new Point(X, -Y, 0), Vector.ZAxis());
        //            curves.Add(new Arc(0, -Math.PI / 2, tieDiameter * 2.5, p));

        //            Curve c = Curve.Join(curves)[0];

        //            double width = property.TotalWidth - 2 * property.MinimumCover - tieDiameter;
        //            double spacing = width / (BarCount - 1);
        //            Curve singleTie = null;
        //            if (BarCount > 2)
        //            {
        //                List<Curve> crvs = new List<Curve>();
        //                double startAngle = 0;
        //                double endAngle = Math.PI * 3 / 4;                       
        //                Vector lap2 = lap.DuplicateVector();
        //                p = new Plane(new Point(0, property.TotalDepth / 2 - property.MinimumCover - 3 * tieDiameter, -tieDiameter), Vector.ZAxis());
        //                a1 = new Arc(startAngle, endAngle, 2.5 * tieDiameter, p);
        //                a2 = a1.DuplicateCurve() as Arc;
        //                a2.Mirror(Plane.XZ());
        //                lap2.Mirror(Plane.XZ());
        //                crvs.Add(new Line(a1.StartPoint, a2.StartPoint));
        //                crvs.Add(new Line(a1.EndPoint, a1.EndPoint + lap));
        //                crvs.Add(new Line(a2.EndPoint, a2.EndPoint + lap2));
        //                crvs.Add(a1);
        //                crvs.Add(a2);
        //                singleTie = Curve.Join(crvs)[0];
        //            }

        //            Group<Pipe> bars = new Group<Pipe>();
        //            bars.Add(new Pipe(c, tieDiameter / 2));
        //            for (int i = 0; i < BarCount - 2; i++)
        //            {
        //                c = singleTie.DuplicateCurve();
        //                double location = -width / 2 + (i + 1) * spacing;
        //                //if (location < 0)
        //                //{
        //                //    c.Mirror(Plane.YZ());
        //                //}
        //                //TEMP UNDO c.Translate(Vector.XAxis(location));
        //                bars.Add(new Pipe(c, tieDiameter / 2));
        //            }
        //            */
        //            return null;//temp bars;

        //            //double X = property.TotalWidth / 2 - property.MinimumCover - tieDiameter * 3;
        //            //double Y = property.TotalDepth / 2 - property.MinimumCover - tieDiameter * 3;
        //            //double yIn = property.TotalDepth / 2 - property.MinimumCover - tieDiameter;
        //            //double yOut = property.TotalDepth / 2 - property.MinimumCover;
        //            //double xIn = property.TotalWidth / 2 - property.MinimumCover - tieDiameter;
        //            //double xOut = property.TotalWidth / 2 - property.MinimumCover;

        //            //Group<Curve> curves = new Group<Curve>();
        //            //curves.Add(new Line(new Point(-X, yIn, 0), new Point(X, yIn, 0)));
        //            //curves.Add(new Line(new Point(-X, -yIn, 0), new Point(X, -yIn, 0)));
        //            //curves.Add(new Line(new Point(-X, yOut, 0), new Point(X, yOut, 0)));
        //            //curves.Add(new Line(new Point(-X, -yOut, 0), new Point(X, -yOut, 0)));
        //            //curves.Add(new Line(new Point(xIn, -Y, 0), new Point(xIn, Y, 0)));
        //            //curves.Add(new Line(new Point(-xIn, -Y, 0), new Point(-xIn, Y, 0)));
        //            //curves.Add(new Line(new Point(xOut, -Y, 0), new Point(xOut, Y, 0)));
        //            //curves.Add(new Line(new Point(-xOut, -Y, 0), new Point(-xOut, Y, 0)));
        //            //Plane p = new Plane(new Point(-X,-Y,0), Vector.ZAxis());
        //            //curves.Add(new Arc(Math.PI * 3 / 2, Math.PI, tieDiameter * 2, p));
        //            //curves.Add(new Arc(Math.PI * 3 / 2, Math.PI, tieDiameter * 3, p));
        //            //p = new Plane(new Point(-X, Y, 0), Vector.ZAxis());
        //            //curves.Add(new Arc(Math.PI, Math.PI / 2, tieDiameter * 2, p));
        //            //curves.Add(new Arc(Math.PI, Math.PI / 2, tieDiameter * 3, p));
        //            //p = new Plane(new Point(X, Y, 0), Vector.ZAxis());
        //            //curves.Add(new Arc(Math.PI / 2, 0, tieDiameter * 2, p));
        //            //curves.Add(new Arc(Math.PI / 2, 0, tieDiameter * 3, p));
        //            //p = new Plane(new Point(X, -Y, 0), Vector.ZAxis());
        //            //curves.Add(new Arc(0, -Math.PI / 2, tieDiameter * 2, p));
        //            //curves.Add(new Arc(0, -Math.PI / 2, tieDiameter * 3, p));
        //            //return new Group<Curve>(Curve.Join(curves));
        //    }

        //    return null;
        //}

    }


}
