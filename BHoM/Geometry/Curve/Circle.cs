using BH.oM.Base;
using BH.oM.Geometry.Curve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class Circle : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Centre { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector(0, 0, 1);

        public double Radius { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Circle() { }

        /***************************************************/

        public Circle(Point centre, double radius = 0)
        {
            Centre = centre;
            Radius = radius;
        }

        /***************************************************/

        public Circle(Point centre, Vector normal, double radius = 0)
        {
            Centre = centre;
            Normal = normal.Normalise();
            Radius = radius;
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Circle;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            return new BoundingBox(Centre - Radius * Normal, Centre + Radius * Normal);
        }

        /***************************************************/

        public object Clone()
        {
            return new Circle(Centre.Clone() as Point, Normal.Clone() as Vector, Radius);
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new Circle(Centre + t, Normal.Clone() as Vector, Radius);
        }


        /***************************************************/
        /**** ICurve Interface                          ****/
        /***************************************************/

        public Point GetStart()
        {
            if (Normal.X == 0 && Normal.Y == 0)
                return new Point(Centre.X + Radius * Normal.Z, Centre.Y, Centre.Z);
            else
                return new Point(Centre.X + Radius * Normal.Y, Centre.Y - Radius * Normal.X, Centre.Z);
        }

        /***************************************************/

        public Point GetEnd()
        {
            return GetStart();
        }

        /***************************************************/

        public Vector GetStartDir()
        {
            throw new NotImplementedException(); //TODO: get start dir of circle (would require cross product
        }

        /***************************************************/

        public Vector GetEndDir()
        {
            throw new NotImplementedException(); //TODO: get end dir of circle (would require cross product
        }

        /***************************************************/

        public bool IsClosed()
        {
            return true;
        }



        //public override void Update()
        //{
        //    base.Update();
        //}
    }
}
