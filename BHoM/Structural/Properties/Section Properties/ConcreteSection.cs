using BHoM.Geometry;
using BHoM.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public class ConcreteSection : SectionProperty
    {
        public ConcreteSection()
        {
            Material = BHoM.Materials.Material.Default(MaterialType.Concrete);
        }
        /// <summary>
        /// Create a section property from a list of edges, shape type and material
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="sType"></param>
        /// <param name="mType"></param>
        public ConcreteSection(BHoM.Geometry.Group<Curve> edges, ShapeType sType) : this()
        {
            Edges = edges;
            Shape = sType;
            //SectionMaterial = mType;
        }
    }
}
