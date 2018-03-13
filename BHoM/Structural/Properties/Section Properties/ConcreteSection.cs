using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BH.oM.Common.Materials;

namespace BH.oM.Structural.Properties
{

    public class ConcreteSection : BHoMObject, ISectionProperty, IGeometricalSection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Reinforcement> Reinforcement { get; set; }

        public double MinimumCover { get; }  //TODO: Do we need this property or should it be a BHoM_Engine query?

        public Material Material { get; set; }

        public ReadOnlyCollection<ICurve> Edges { get; }


        /***************************************************/
        /**** Properties - Section dimensions           ****/
        /***************************************************/

        public ISectionDimensions SectionDimensions { get; }


        /***************************************************/
        /**** Properties - Section constants            ****/
        /***************************************************/

        /// <summary>
        /// Gross Area of the cross section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Area { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Rgy { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Rgz { get; } = 0;

        /// <summary>
        /// Torsion Constant
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double J { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Iy { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Iz { get; } = 0;

        /// <summary>
        /// Warping Constant
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Iw { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Zy { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Zz { get; } = 0;
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Sy { get; } = 0;

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Sz { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double CentreZ { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double CentreY { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vz { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vpz { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vy { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vpy { get; } = 0;

        /// <summary>
        /// Shear Area in the Y direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Asy { get; } = 0;

        /// <summary>
        /// Shear Area in the Z direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Asz { get; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ConcreteSection(             //Main constructor setting all of the properties of the object
            IEnumerable<ICurve> edges,

            ISectionDimensions sectionDimension,

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

            SectionDimensions = sectionDimension;

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

        /***************************************************/
        
        public ConcreteSection(         //Secondary constructor for a freeform section
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
            double asz)

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


        /***************************************************/
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