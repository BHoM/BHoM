using BH.oM.Geometry;
using BH.oM.Materials;
using BH.oM.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{

    public class ConcreteSection : BHoMObject, ICrossSection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ReadOnlyCollection<Reinforcement> Reinforcement { get; }

        //TODO: Do we need this property or should it be a BHoM_Engine query?
        public double MinimumCover { get; }
        public Material Material { get; set; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Properties - Section dimensions           ****/
        /***************************************************/

        //TODO: Which section dimensions make sense for a concrete section?

        public ShapeType Shape { get; }

        public double B1 { get; }

        public double B2 { get; }

        public double B3 { get; }

        public double Tw { get; }

        public double Tf1 { get; }

        public double Tf2 { get; }

        public double R1 { get; }

        public double R2 { get; }

        public double Spacing { get; }



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


        /// <summary>
        /// Total Depth of the section
        /// </summary>
        public double TotalDepth { get; } = 0;

        /// <summary>
        /// Total Width of the section
        /// </summary>
        public double TotalWidth { get; } = 0;



        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/


        //Main constructor setting all of the properties of the object
        public ConcreteSection(
            Material material,
            IEnumerable<Reinforcement> reinforcement,
            double minimumCover,

            IEnumerable<ICurve> edges,

            ShapeType shape,
            double b1,
            double b2,
            double b3,
            double tw,
            double tf1,
            double tf2,
            double r1,
            double r2,
            double spacing,

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
            Material = material;
            Reinforcement = new ReadOnlyCollection<Properties.Reinforcement>(reinforcement.ToList());
            MinimumCover = minimumCover;

            Edges = new System.Collections.ObjectModel.ReadOnlyCollection<ICurve>(edges.ToList());

            Shape = shape;
            B1 = b1;
            B2 = b2;
            B3 = b3;
            Tw = tw;
            Tf1 = tf1;
            Tf2 = tf2;
            R1 = r1;
            R2 = r2;
            Spacing = spacing;

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
            CentreY = centreZ;
            Vz = vz;
            Vpz = Vpz;
            Vy = Vy;
            Vpy = Vpy;
            Asy = Asy;
            Asz = Asz;
            TotalDepth = totalDepth;
            TotalWidth = totalWidth;

        }

        //Secondary constructor for a freeform section
        public ConcreteSection(
            Material material,
            IEnumerable<Reinforcement> reinforcement,
            double minimumCover,


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

            Material = material;
            Reinforcement = new ReadOnlyCollection<Properties.Reinforcement>(reinforcement.ToList());
            MinimumCover = minimumCover;

            Edges = new System.Collections.ObjectModel.ReadOnlyCollection<ICurve>(edges.ToList());

            Shape = ShapeType.Polygon;

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
            CentreY = centreZ;
            Vz = vz;
            Vpz = Vpz;
            Vy = Vy;
            Vpy = Vpy;
            Asy = Asy;
            Asz = Asz;
            TotalDepth = totalDepth;
            TotalWidth = totalWidth;

        }



    }
}




//public double GetTieDiameter()
//{
//    foreach (Reinforcement reo in Reinforcement)
//    {
//        if (reo is TieReinforcement)
//        {
//            return reo.Diameter;
//        }
//    }
//    return 0;
//}

///***************************************************/

//public IBHoMGeometry GetReinforcementLayout(double xStart = 0, double xEnd = 1)
//{
//    GeometryGroup<IBHoMGeometry> geometry = new GeometryGroup<IBHoMGeometry>();
//    //foreach (Reinforcement reo in Reinforcement)
//    //{
//    //    IBHoMGeometry layout = reo.GetLayout(this);
//    //    if (typeof(IGroup).IsAssignableFrom(layout.GetType()))
//    //    {
//    //        foreach (IBHoMGeometry obj in ((IGroup)layout).Objects)
//    //        {
//    //            if (obj is Point)
//    //            {
//    //                geometry.Add(new Circle(reo.Diameter / 2, new Plane(obj as Point, Vector.ZAxis())));
//    //            }
//    //            else
//    //            {
//    //                geometry.Add(obj);
//    //            }                       
//    //        }
//    //    }
//    //    else
//    //    {
//    //        geometry.Add(layout);
//    //    }
//    //}
//    return geometry;
//}