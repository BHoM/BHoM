using BHoM.Geometry;
using BHoM.Base;
using BHoM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;




namespace BHoM.Structural.Properties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>

    public abstract partial class SectionProperty : BHoMObject
    {
        /// <summary>
        /// 
        /// </summary>
        public SectionProperty() { }

        /// <summary>
        /// Geometry of the cross section
        /// </summary>

        [Browsable(false)]
        [DefaultValue(null)]
        public BHoM.Geometry.Group<Curve> Edges { get; set; }


        /// <summary>Material of the section property</summary>
        [DisplayName("Material")]
        [Description("Bar Material assigned to the bar object")]
        public BHoM.Materials.Material Material { get; set; }

        /************************************************/
        /********* Steel sections from data base ********/
        /************************************************/

      
        /// <summary>Section type</summary> /// 
        [DefaultValue(null)]
        public virtual ShapeType Shape { get; set; }

        /// <summary>
        /// Orientation
        /// </summary>
        [DefaultValue(null)]
        public virtual double Orientation
        {
            get;
            set;
        }

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


        /// <summary>Cross sectional area</summary>

        /// <summary>Torsion Constant</summary>



        public override GeometryBase GetGeometry()
        {

            return Edges;
        }

        public override string ToString()
        {
            string name = !string.IsNullOrWhiteSpace(Name) ? Name + " " : "";
            string mat = (this.Material != null && !string.IsNullOrWhiteSpace(this.Material.Name)) ? "-" + this.Material.Name : "";
            return name + "-" + mat;

        }
    }
}
