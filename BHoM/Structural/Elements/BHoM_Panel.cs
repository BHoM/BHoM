using BHoM.Global;
using BHoM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
                m_Edges = new Group<Curve>();
                for (int i = 0; i < curve.Count; i++)
                {
                    m_Edges.Add(curve[i]);
                }

                //m_Edges = value;
            }
        }

        public Curve External_Contour
        {
            get
            {
                return m_Edges[0];
            }
        }

        public Group<Curve> Internal_Contours
        {
            get
            {
                Group<Curve> internalCurves = new Group<Curve>();
                for (int i = 1; i < m_Edges.Count; i++)
                {
                    internalCurves.Add(m_Edges[i]);
                }
                return internalCurves;
            }
        }

        public ThicknessProperty ThicknessProperty { get; set; }

        public Materials.Material Material { get; set; }

        public bool IsValid() { return Edges != null; }

        internal Panel() { }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(Group<Curve> edges)
        {
            Edges = edges;
        }
    }
}
