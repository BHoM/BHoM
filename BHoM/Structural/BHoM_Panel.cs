using BHoM.Global;
using BHoM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    /// <summary>
    /// Panel Class
    /// </summary>
    public class Panel : BHoMObject
    {
        private Group<Curve> m_Edges;

        /// <summary>
        /// A group of curves which define the perimeter of panel object
        /// </summary>
        public Group<Curve> Edges
        {
            get
            {
                return m_Edges;
            }
            set
            {
                List<Curve> curve = Curve.Join(value);
                if (curve.Count == 1 && curve[0].IsClosed())
                {
                    m_Edges = new Group<Curve>(curve);
                }
            }
        }

        public ThicknessProperty ThicknessProperty { get; set; }

        public Materials.Material Material { get; set; }

        public int Number { get; set; }

        public bool IsValid() { return Edges != null; }

        internal Panel() { }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(Group<Curve> edges, int number)
        {            
            Edges = edges;            
            Name = number.ToString();
            Number = number;
        }

    }
}
