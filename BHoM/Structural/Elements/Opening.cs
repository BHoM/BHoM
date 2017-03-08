using BHoM.Geometry;
using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Elements
{
    public class Opening : BHoMObject
    {
        private BHoM.Geometry.Group<Curve> m_Edges;
        /// <summary>
        /// A group of curves which define the perimeter of panel object
        /// </summary>
        public BHoM.Geometry.Group<Curve> Edges
        {
            get
            {
                return m_Edges;
            }
            set
            {
                m_Edges = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Opening()
        {
            Edges = new Geometry.Group<Curve>();
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Opening(BHoM.Geometry.Group<Curve> edges)
        {
            Edges = edges;
        }

        public Opening(Curve edges)
        {
            BHoM.Geometry.Group<Curve> group = new BHoM.Geometry.Group<Curve>();
            group.Add(edges);
            Edges = group;
        }
    }
}
