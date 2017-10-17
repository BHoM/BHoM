using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>

    public abstract partial class SectionProperty : BHoMObject  
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Edges { get; set; } = new List<ICurve>();

        public Material Material { get; set; } = new Material();

        public virtual ShapeType Shape { get; set; } = new ShapeType();

        public virtual double Orientation { get; set; } // TODO: Defien all the default values;

        /// <summary>
        /// Gross Area of the cross section
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// </summary>
        public double Rgy { get; set; }

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// </summary>
        public double Rgz { get; set; }

        /// <summary>
        /// Torsion Constant
        /// </summary>
        public double J { get; set; }

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// </summary>
        public virtual double Iy { get; set; }

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// </summary>
        public virtual double Iz { get; set; }

        /// <summary>
        /// Warping Constant
        /// </summary>
        public double Iw { get; set; }

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// </summary>
        public virtual double Zy { get; set; }

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// </summary>
        public virtual double Zz { get; set; }
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// </summary>
        public virtual double Sy { get; set; }

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// </summary>
        public virtual double Sz { get; set; }
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// </summary>
        public virtual double CentreZ { get; set; }
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// </summary>
        public virtual double CentreY { get; set; }

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// </summary>
        public virtual double Vz { get; set; }

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// </summary>
        public virtual double Vpz { get; set; }
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// </summary>
        public virtual double Vy { get; set; }
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// </summary>
        public virtual double Vpy { get; set; }

        /// <summary>
        /// Shear Area in the Y direction
        /// </summary>
        public virtual double Asy { get; set; }

        /// <summary>
        /// Shear Area in the Z direction
        /// </summary>
        public virtual double Asz { get; set; }


        /// <summary>
        /// Total Depth of the section
        /// </summary>
        public double TotalDepth { get; set; }

        /// <summary>
        /// Total Width of the section
        /// </summary>
        public double TotalWidth { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SectionProperty() { }
        
    }
}


/***************************************************/



//public override string ToString()     // That needs to be json
//{
//    string name = !string.IsNullOrWhiteSpace(Name) ? Name + " " : "";
//    string mat = (this.Material != null && !string.IsNullOrWhiteSpace(this.Material.Name)) ? "-" + this.Material.Name : "";
//    return name + "-" + mat;

//}


///***************************************************/
///**** Override BHoMObject                       ****/
///***************************************************/

//public override IBHoMGeometry GetGeometry()
//{
//    return new GeometryGroup<ICurve> (Edges);
//}

