//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BH.oM.Base;
//using BH.oM.Materials;

//namespace BH.oM.Structural.Properties
//{
//    public class ExplicitSectionProperty : BHoMObject, IPropertyDefinition
//    {
//        /***************************************************/
//        /**** Properties                                ****/
//        /***************************************************/

//        /// <summary>
//        /// Gross Area of the cross section
//        /// </summary>
//        public double Area { get; set; } = 0;

//        /// <summary>
//        /// Radius of Gyration about the Y-Axis
//        /// </summary>
//        public double Rgy { get; set; } = 0;

//        /// <summary>
//        /// Radius of Gyration about the Z-Axis
//        /// </summary>
//        public double Rgz { get; set; } = 0;

//        /// <summary>
//        /// Torsion Constant
//        /// </summary>
//        public double J { get; set; } = 0;

//        /// <summary>
//        /// Moment of Inertia about the Y-Axis
//        /// </summary>
//        public double Iy { get; set; } = 0;

//        /// <summary>
//        /// Moment of Inertia about the Z-Axis
//        /// </summary>
//        public double Iz { get; set; } = 0;

//        /// <summary>
//        /// Warping Constant
//        /// </summary>
//        public double Iw { get; set; } = 0;

//        /// <summary>
//        /// Elastic Modulus of the section about the Y-Axis
//        /// </summary>
//        public double Zy { get; set; } = 0;

//        /// <summary>
//        /// Elastic Modulus of the section about the Z-Axis
//        /// </summary>
//        public double Zz { get; set; } = 0;
//        /// <summary>
//        /// Plastic Modulus of the section about the Y-Axis
//        /// </summary>
//        public double Sy { get; set; } = 0;

//        /// <summary>
//        /// Plastic Modulus of the section about the Z-Axis
//        /// </summary>
//        public double Sz { get; set; } = 0;
//        /// <summary>
//        /// Geometric centre of the section in the Z direction
//        /// </summary>
//        public double CentreZ { get; set; } = 0;
//        /// <summary>
//        /// Geometric centre of the section in the Y direction
//        /// </summary>
//        public double CentreY { get; set; } = 0;

//        /// <summary>
//        /// Z Distance from the centroid of the section to top edge of the section
//        /// </summary>
//        public double Vz { get; set; } = 0;

//        /// <summary>
//        /// Z Distance from the centroid of the section to bottom edge of the section
//        /// </summary>
//        public double Vpz { get; set; } = 0;
//        /// <summary>
//        /// Y Distance from the centroid of the section to right edge of the section
//        /// </summary>
//        public double Vy { get; set; } = 0;
//        /// <summary>
//        /// Y Distance from the centroid of the section to Left edge of the section
//        /// </summary>
//        public double Vpy { get; set; } = 0;

//        /// <summary>
//        /// Shear Area in the Y direction
//        /// </summary>
//        public double Asy { get; set; } = 0;

//        /// <summary>
//        /// Shear Area in the Z direction
//        /// </summary>
//        public double Asz { get; set; } = 0;


//        /// <summary>
//        /// Total Depth of the section
//        /// </summary>
//        public double TotalDepth { get; set; } = 0;

//        /// <summary>
//        /// Total Width of the section
//        /// </summary>
//        public double TotalWidth { get; set; } = 0;

//        /***************************************************/

//        public ExplicitSectionProperty()
//        {

//        }

//        /***************************************************/
//        /**** Constructors                              ****/
//        /***************************************************/

//        //public ExplicitSectionProperty(SectionConstants constants)
//        //{
//        //    //Constants = constants;
//        //}

//        /***************************************************/

//    }
//}
