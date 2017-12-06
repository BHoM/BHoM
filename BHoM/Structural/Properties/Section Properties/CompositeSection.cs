using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Materials;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public class CompositeSection : BHoMObject, ICrossSection, IImmutable
    {

        public SteelSection SteelSection { get; }

        public ConcreteSection ConcreteSection { get; }

        public double SteelEmbedmentDepth { get; }

        public double StudDiameter { get; }
        public double StudHeight { get;  }
        public double StudSpacing { get;  }
        public int StudsPerGroup { get;  }



        public Material Material { get; set; }

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




        //Main constructor setting all of the properties of the object
        public CompositeSection(

            SteelSection steelSection,
            ConcreteSection concreteSection,
            double steelEmbedmentDepth,
            double studDiameter,
            double studSpacing,
            int studsPerGroup,

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
            SteelSection = steelSection;
            ConcreteSection = concreteSection;
            SteelEmbedmentDepth = steelEmbedmentDepth;
            StudDiameter = studDiameter;
            StudSpacing = StudSpacing;
            StudsPerGroup = studsPerGroup;

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
            Vpz = vpz;
            Vy = vy;
            Vpy = vpy;
            Asy = asy;
            Asz = asz;
            TotalDepth = totalDepth;
            TotalWidth = totalWidth;

        }

        //public override string ToString()
        //{
        //    //return GetType().Name + ": " + SteelSection.Name + " - " + ConcreteSection.Name;
        //}

        //private void SetEdges()
        //{
        //    if (m_ConcreteSection != null && m_SteelSection != null)
        //    {
        //        double n = m_ConcreteSection.Material.YoungsModulus / m_SteelSection.Material.YoungsModulus;
        //        Group<Curve> concreteRectangle = m_ConcreteSection.Edges.DuplicateGroup();
        //        concreteRectangle.Transform(Transform.Scale(Point.Origin, new Vector(n, 1, 1)));
        //        Group<Curve> steelSection = m_SteelSection.Edges;

        //        double topSteel = steelSection.GetBounds().Max.Y;
        //        double botConcrete = concreteRectangle.GetBounds().Min.Y;
        //        double steelOffset = topSteel - botConcrete - SteelEmbedmentDepth;

        //        //TEMP UNDO steelSection.Translate(Vector.YAxis(-steelOffset));
        //        m_SteelSection.Edges = steelSection;

        //        if (SteelEmbedmentDepth > 0)
        //        {
        //            Curve perimeter = Curve.Join(steelSection)[0];
        //            if (perimeter != null)
        //            {
        //                List<Curve> curves = perimeter.Split(Plane.YZ(botConcrete), true);
        //                if (curves.Count == 2)
        //                {
        //                    if (curves[0].GetBounds().Centre.Y < botConcrete)
        //                    {
        //                        concreteRectangle.Add(curves[0]);
        //                    }
        //                    else
        //                    {
        //                        concreteRectangle.Add(curves[1]);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            concreteRectangle.AddRange(steelSection);
        //        }
        //        Edges = concreteRectangle;
        //    }
        //}
    }
}
