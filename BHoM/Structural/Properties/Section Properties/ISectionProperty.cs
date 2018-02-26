using BH.oM.Base;
using BH.oM.Common.Materials;

namespace BH.oM.Structural.Properties
{
    public interface ISectionProperty : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        Material Material { get; set; }

        /// <summary>
        /// Gross Area of the cross section
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// </summary>
        double Rgy { get; }

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// </summary>
        double Rgz { get; }

        /// <summary>
        /// Torsion Constant
        /// </summary>
        double J { get; }

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// </summary>
        double Iy { get; }

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// </summary>
        double Iz { get; }

        /// <summary>
        /// Warping Constant
        /// </summary>
        double Iw { get; }

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// </summary>
        double Zy { get; }

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// </summary>
        double Zz { get; }
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// </summary>
        double Sy { get; }

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// </summary>
        double Sz { get; }
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// </summary>
        double CentreZ { get; }
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// </summary>
        double CentreY { get; }

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// </summary>
        double Vz { get; }

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// </summary>
        double Vpz { get; }
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// </summary>
        double Vy { get; }
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// </summary>
        double Vpy { get; }

        /// <summary>
        /// Shear Area in the Y direction
        /// </summary>
        double Asy { get; }

        /// <summary>
        /// Shear Area in the Z direction
        /// </summary>
        double Asz { get; }

        /***************************************************/
    }
}
