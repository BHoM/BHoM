//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BH.oM.Base;
//using BH.oM.Geometry;

//namespace BH.oM.Structural.Properties
//{
//    public class FreeFormSectionProperty : BHoMObject, IGeometricalPropertyDefinition, IImmutable
//    {
//        /***************************************************/
//        /**** Properties                                ****/
//        /***************************************************/

//        public System.Collections.ObjectModel.ReadOnlyCollection<ICurve> Edges { get; }

//        /***************************************************/


//        /// <summary>
//        /// Gross Area of the cross section
//        /// </summary>
//        public double Area { get; } = 0;

//        /// <summary>
//        /// Radius of Gyration about the Y-Axis
//        /// </summary>
//        public double Rgy { get; } = 0;

//        /// <summary>
//        /// Radius of Gyration about the Z-Axis
//        /// </summary>
//        public double Rgz { get; } = 0;

//        /// <summary>
//        /// Torsion Constant
//        /// </summary>
//        public double J { get; } = 0;

//        /// <summary>
//        /// Moment of Inertia about the Y-Axis
//        /// </summary>
//        public double Iy { get; } = 0;

//        /// <summary>
//        /// Moment of Inertia about the Z-Axis
//        /// </summary>
//        public double Iz { get; } = 0;

//        /// <summary>
//        /// Warping Constant
//        /// </summary>
//        public double Iw { get; } = 0;

//        /// <summary>
//        /// Elastic Modulus of the section about the Y-Axis
//        /// </summary>
//        public double Zy { get; } = 0;

//        /// <summary>
//        /// Elastic Modulus of the section about the Z-Axis
//        /// </summary>
//        public double Zz { get; } = 0;
//        /// <summary>
//        /// Plastic Modulus of the section about the Y-Axis
//        /// </summary>
//        public double Sy { get; } = 0;

//        /// <summary>
//        /// Plastic Modulus of the section about the Z-Axis
//        /// </summary>
//        public double Sz { get; } = 0;
//        /// <summary>
//        /// Geometric centre of the section in the Z direction
//        /// </summary>
//        public double CentreZ { get; } = 0;
//        /// <summary>
//        /// Geometric centre of the section in the Y direction
//        /// </summary>
//        public double CentreY { get; } = 0;

//        /// <summary>
//        /// Z Distance from the centroid of the section to top edge of the section
//        /// </summary>
//        public double Vz { get; } = 0;

//        /// <summary>
//        /// Z Distance from the centroid of the section to bottom edge of the section
//        /// </summary>
//        public double Vpz { get; } = 0;
//        /// <summary>
//        /// Y Distance from the centroid of the section to right edge of the section
//        /// </summary>
//        public double Vy { get; } = 0;
//        /// <summary>
//        /// Y Distance from the centroid of the section to Left edge of the section
//        /// </summary>
//        public double Vpy { get; } = 0;

//        /// <summary>
//        /// Shear Area in the Y direction
//        /// </summary>
//        public double Asy { get; } = 0;

//        /// <summary>
//        /// Shear Area in the Z direction
//        /// </summary>
//        public double Asz { get; } = 0;


//        /// <summary>
//        /// Total Depth of the section
//        /// </summary>
//        public double TotalDepth { get; } = 0;

//        /// <summary>
//        /// Total Width of the section
//        /// </summary>
//        public double TotalWidth { get; } = 0;


//        /***************************************************/
//        /**** Constructors                              ****/
//        /***************************************************/

//        //TODO: Not sure if necessary. Creates and unmodifieable FreeFormSectionProperty with all properties set to default values...
//        public FreeFormSectionProperty()
//        {
//            //Constants = new SectionConstants();
//            Edges = new System.Collections.ObjectModel.ReadOnlyCollection<ICurve>(new List<ICurve>());
//        }

//        /***************************************************/

//        //public FreeFormSectionProperty(IEnumerable<ICurve> edges, SectionConstants constants)
//        //{
//        //    //Constants = constants;
//        //    Edges = new System.Collections.ObjectModel.ReadOnlyCollection<ICurve>(edges.ToList());
//        //}

//        //Main constructor setting all of the properties of the object
//        public FreeFormSectionProperty(
//            IEnumerable<ICurve> edges,
//            double area,
//            double rgy,
//            double rgz,
//            double j,
//            double iy,
//            double iz,
//            double iw,
//            double zy,
//            double zz,
//            double sy,
//            double sz,
//            double centreZ,
//            double centreY,
//            double vz,
//            double vpz,
//            double vy,
//            double vpy,
//            double asy,
//            double asz,
//            double totalDepth,
//            double totalWidth)

//        {

//            Edges = new System.Collections.ObjectModel.ReadOnlyCollection<ICurve>(edges.ToList());


//            Area = area;
//            Rgy = rgy;
//            Rgz = rgz;
//            J = j;
//            Iy = iy;
//            Iz = iz;
//            Iw = iw;
//            Zy = zy;
//            Zz = zz;
//            Sy = sy;
//            Sz = sz;
//            CentreZ = centreZ;
//            CentreY = centreZ;
//            Vz = vz;
//            Vpz = Vpz;
//            Vy = Vy;
//            Vpy = Vpy;
//            Asy = Asy;
//            Asz = Asz;
//            TotalDepth = totalDepth;
//            TotalWidth = totalWidth;

//        }

//    }
//}
