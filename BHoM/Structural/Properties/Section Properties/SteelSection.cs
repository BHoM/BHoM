using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Materials;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structural.Properties
{

    public class SteelSection : BHoMObject, ISectionProperty, IGeometricalSection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Fabrication Fabrication { get; set; } = Fabrication.Welded;

        public PlateRestraint PlateRestraint { get; set; } = PlateRestraint.NoRestraint;

        public Material Material { get; set; } = null;

        public System.Collections.ObjectModel.ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Properties - Section dimensions           ****/
        /***************************************************/

        public ISectionDimensions SectionDimensions { get; }

        //public ShapeType Shape { get; }

        //public double B1 { get; } = 0;

        //public double B2 { get; } = 0;

        //public double B3 { get; } = 0;

        //public double Tw { get; } = 0;

        //public double Tf1 { get; } = 0;

        //public double Tf2 { get; } = 0;

        //public double R1 { get; } = 0;

        //public double R2 { get; } = 0;

        //public double Spacing { get; } = 0;



        /***************************************************/
        /**** Properties - Section constants            ****/
        /***************************************************/


        /// <summary>
        /// Gross Area of the cross section
        /// </summary>
        public double Area { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// </summary>
        public double Rgy { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// </summary>
        public double Rgz { get; } = 0;

        /// <summary>
        /// Torsion Constant
        /// </summary>
        public double J { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// </summary>
        public double Iy { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// </summary>
        public double Iz { get; } = 0;

        /// <summary>
        /// Warping Constant
        /// </summary>
        public double Iw { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// </summary>
        public double Zy { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// </summary>
        public double Zz { get; } = 0;
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// </summary>
        public double Sy { get; } = 0;

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// </summary>
        public double Sz { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// </summary>
        public double CentreZ { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// </summary>
        public double CentreY { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// </summary>
        public double Vz { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// </summary>
        public double Vpz { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// </summary>
        public double Vy { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// </summary>
        public double Vpy { get; } = 0;

        /// <summary>
        /// Shear Area in the Y direction
        /// </summary>
        public double Asy { get; } = 0;

        /// <summary>
        /// Shear Area in the Z direction
        /// </summary>
        public double Asz { get; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/


        //Main constructor setting all of the properties of the object
        public SteelSection(
            IEnumerable<ICurve> edges,
            ISectionDimensions dimensions,

            //ShapeType shape,
            //double b1,
            //double b2,
            //double b3,
            //double tw,
            //double tf1,
            //double tf2,
            //double r1,
            //double r2,
            //double spacing,

            double area,
            double rgy,
            double rgz,
            double j,
            double iy,
            double iz,
            double iw,
            double zy,
            double zz,
            double sy,
            double sz,
            double centreZ,
            double centreY,
            double vz,
            double vpz,
            double vy,
            double vpy,
            double asy,
            double asz)

        {

            Edges = new System.Collections.ObjectModel.ReadOnlyCollection<ICurve>(edges.ToList());

            SectionDimensions = dimensions;
            //Shape = shape;
            //B1 = b1;
            //B2 = b2;
            //B3 = b3;
            //Tw = tw;
            //Tf1 = tf1;
            //Tf2 = tf2;
            //R1 = r1;
            //R2 = r2;
            //Spacing = spacing;

            Area = area;
            Rgy = rgy;
            Rgz = rgz;
            J = j;
            Iy = iy;
            Iz = iz;
            Iw = iw;
            Zy = zy;
            Zz = zz;
            Sy = sy;
            Sz = sz;
            CentreZ = centreZ;
            CentreY = centreY;
            Vz = vz;
            Vpz = vpz;
            Vy = vy;
            Vpy = vpy;
            Asy = asy;
            Asz = asz;

        }

        //Secondary constructor for a freeform section
        public SteelSection(

            IEnumerable<ICurve> edges,

            double area,
            double rgy,
            double rgz,
            double j,
            double iy,
            double iz,
            double iw,
            double zy,
            double zz,
            double sy,
            double sz,
            double centreZ,
            double centreY,
            double vz,
            double vpz,
            double vy,
            double vpy,
            double asy,
            double asz,
            double totalDepth,
            double totalWidth)

        {
            Edges = new System.Collections.ObjectModel.ReadOnlyCollection<ICurve>(edges.ToList());

            SectionDimensions = new PolygonDimensions();

            Area = area;
            Rgy = rgy;
            Rgz = rgz;
            J = j;
            Iy = iy;
            Iz = iz;
            Iw = iw;
            Zy = zy;
            Zz = zz;
            Sy = sy;
            Sz = sz;
            CentreZ = centreZ;
            CentreY = centreY;
            Vz = vz;
            Vpz = vpz;
            Vy = vy;
            Vpy = vpy;
            Asy = asy;
            Asz = asz;

        }
    }
}


//public double GetGrade()
//{
//    return Material.TensileYieldStrength / 1000000;
//}