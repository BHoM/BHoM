

using BHoM.Geometry;
using BHoM.Global;
using System;

namespace BHoM.Structural.SectionProperties
{


    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>
    public abstract class SectionProperty : BHoM.Global.BHoMObject
    {
        public SectionProperty() { }

        public Group<Curve> Edges { get; private set; }

        /// <summary>Mass per metre based on section properties</summary>
        public double MassPerMetre { get; set; }

        public static SectionProperty LoadFromDB(string name)
        {
            object[] values = Project.ActiveProject.Structure.SectionDatabase.SectionProperties(name);
            if (values != null)
            {
                //SectionTableColumn.
            }
            return null;
        }


        /// <summary>Section type</summary>
        public ShapeType Type { get; set; }

        ///public MaterialType

        /// <summary>Cross sectional area</summary>
        public double GrossArea { get; set; }

        /// <summary>Second moment of inertia - x axis</summary>
        public double Ix { get; set; }

        /// <summary>Second moment of inertia - y axis</summary>
        public double Iy { get; set; }

        /// <summary>Second moment of inertia - z axis</summary>
        public double Iz { get; set; }

        /// <summary>Information regarding section property type for the user</summary>
        public string Description { get; set; }

        /// <summary>Section material</summary>
        public BHoM.Materials.Material Material {get; set;}

            
    }
}