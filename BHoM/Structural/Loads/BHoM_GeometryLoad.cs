using BHoM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    public class GeometricalAreaLoad : BHoM.Global.BHoMObject, ILoad
    {
        public Curve Contour { get; set; }
        private Loadcase m_Loadcase;
        /// <summary>Force - fx, fy, fz defined as a BHoM.Geometry.Vector</summary>
        public Geometry.Vector Force { get; set; }

        public LoadType LoadType
        {
            get
            {
                return LoadType.Geometrical;
            }
        }

        public Loadcase Loadcase
        {
            get
            {
                return m_Loadcase;
            }
            set
            {
                if (m_Loadcase != null && m_Loadcase.LoadRecords != null) m_Loadcase.LoadRecords.Remove(this);
                m_Loadcase = value;
                if (m_Loadcase != null && m_Loadcase.LoadRecords != null) m_Loadcase.LoadRecords.Add(this);
            }
        }

        public GeometricalAreaLoad(BHoM.Geometry.Curve contour, Geometry.Vector force)
        {
            Contour = contour;
            Force = force;
        }
    }

    public class GeometricalLineLoad : BHoM.Global.BHoMObject, ILoad
    {
        public Line Location { get; set; }
        private Loadcase m_Loadcase;
        /// <summary>Force - fx, fy, fz defined as a BHoM.Geometry.Vector</summary>
        public Geometry.Vector ForceA { get; set; }
        public Geometry.Vector ForceB { get; set; }

        public Geometry.Vector MomentA { get; set; }
        public Geometry.Vector MomentB { get; set; }

        public LoadType LoadType
        {
            get
            {
                return LoadType.Geometrical;
            }
        }

        public Loadcase Loadcase
        {
            get
            {
                return m_Loadcase;
            }
            set
            {
                if (m_Loadcase != null && m_Loadcase.LoadRecords != null) m_Loadcase.LoadRecords.Remove(this);
                m_Loadcase = value;
                if (m_Loadcase != null && m_Loadcase.LoadRecords != null) m_Loadcase.LoadRecords.Add(this);
            }
        }

        public GeometricalLineLoad(BHoM.Geometry.Line line, Geometry.Vector force, Geometry.Vector moment = null)
        {
            Location = line;
            ForceA = force;
            ForceB = force;
            MomentA = moment == null ? Vector.Zero : moment;
            MomentB = moment == null ? Vector.Zero : moment;
        }

        public GeometricalLineLoad(BHoM.Geometry.Line line, Vector forceA, Vector forceB, Vector momentA = null, Vector momentB = null)
        {
            Location = line;
            ForceA = forceA;
            ForceB = forceB;
            MomentA = momentA == null ? Vector.Zero : momentA;
            MomentB = momentB == null ? Vector.Zero : momentB;
        }

    }

}
