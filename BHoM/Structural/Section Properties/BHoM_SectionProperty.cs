

using System;

namespace BHoM.Structural.Sections
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>
    public class SectionProperty : BHoM.Global.BHoMObject, ISteelBoxSection, ISteelISection
    {
        /// <summary>Mass per metre based on section properties</summary>
        public double MassPerMetre { get; set; }

        /// <summary>Section type</summary>
        public ShapeType ShapeType { get; set; }

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

        /// <summary></summary>
        public double BottomFlangeThickness { get; set; }

        /// <summary></summary>
        public double BottomFlangeWidth { get; set; }

        /// <summary></summary>
        public double Depth { get; set; }

        /// <summary></summary>
        public double RootRadius { get; set; }

        /// <summary></summary>
        public double TopFlangeThickness { get; set; }

        /// <summary></summary>
        public double TopFlangeWidth { get; set; }

        /// <summary></summary>
        public double WebThickness { get; set; }

        /// <summary></summary>
        public double WebThicknessLeft { get; set; }

        /// <summary></summary>
        public double WebThicknessRight { get; set; }

        /// <summary></summary>
        public double Width { get; set; }

        internal SectionProperty(ShapeType shapeType, string name)
        {
            this.Name = name;
            this.ShapeType = shapeType;
        }
    }
}