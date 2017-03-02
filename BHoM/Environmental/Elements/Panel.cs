using BHoM.Geometry;
using BHB = BHoM.Base;
using BHE = BHoM.Environmental.Elements;
using System;
using System.Reflection;
using BHoM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BHoM.Environmental.Elements
{
    /// <summary>
    /// Panel object for environmental models.
    /// </summary>
    public class Panel : BHB.BHoMObject
    {

        /////////////////
        ////Properties///
        /////////////////

        private BHoM.Geometry.Group<Curve> m_ExteriorEdges;

        public string Type { get; set; }

        public List<BHE.Space> adjSpaces { get; set; }

        private void SetEdges(BHoM.Geometry.Group<Curve> curves)
        {
            m_ExteriorEdges = new BHoM.Geometry.Group<Curve>();
            List<Curve> crvs = Curve.Join(curves);
            for (int i = 0; i < crvs.Count; i++)
            {
                if (crvs[i].IsClosed())
                {
                    m_ExteriorEdges.Add(crvs[i]);
                }
            }
        }



        public BHoM.Geometry.Group<Curve> External_Contours
        {
            set
            {
                m_ExteriorEdges = value;
            }
            get
            {
                return m_ExteriorEdges;
            }
        }

        public bool IsValid() { return m_ExteriorEdges != null; }


        ////////////////////
        ////CONSTRUCTORS////
        ////////////////////

        public Panel()
        {
            m_ExteriorEdges = new BHoM.Geometry.Group<Curve>();
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(BHoM.Geometry.Group<Curve> edges)
        {
            SetEdges(edges);
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(List<Curve> edges)
        {
            SetEdges(new BHoM.Geometry.Group<Curve>(edges));
        }

        ///////////////
        ////METHODS////
        ///////////////

        /// <summary></summary>
        public override BHoM.Geometry.GeometryBase GetGeometry()
        {
            BHoM.Geometry.Group<Curve> edges = new BHoM.Geometry.Group<Curve>();
            edges.AddRange(m_ExteriorEdges);
            return edges;
        }

        /// <summary></summary>
        public override void SetGeometry(GeometryBase geometry)
        {
            if (geometry is Curve)
            {
                Curve curve = geometry as Curve;
                BHoM.Geometry.Group<Curve> group = new BHoM.Geometry.Group<Curve>();
                group.Add(curve);
                SetEdges(group);
            }
            else if (geometry is BHoM.Geometry.Group<Curve>)
            {
                SetEdges(geometry as BHoM.Geometry.Group<Curve>);
            }
        }
    }
}