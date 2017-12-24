using BH.oM.Geometry;
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Structural.Loads
{
    public class GeometricalLineLoad : BHoMObject, ILoad
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Line Location { get; set; }

        /// <summary>Force - fx, fy, fz defined as a BH.oM.Geometry.Vector</summary>
        public Geometry.Vector ForceA { get; set; }

        public Geometry.Vector ForceB { get; set; }

        public Geometry.Vector MomentA { get; set; }

        public Geometry.Vector MomentB { get; set; }

        [DefaultValue(LoadAxis.Global)]
        public LoadAxis Axis { get; set; } = LoadAxis.Global;

        public bool Projected { get; set; } = false;

        public Loadcase Loadcase { get; set; } = new Loadcase();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeometricalLineLoad() { }

        /***************************************************/

        public GeometricalLineLoad(BH.oM.Geometry.Line line, Geometry.Vector force, Geometry.Vector moment = null)
        {
            Location = line;
            ForceA = force;
            ForceB = force;
            MomentA = moment == null ? new Vector(0, 0, 0) : moment;
            MomentB = moment == null ? new Vector(0, 0, 0) : moment;
        }


        /***************************************************/
        public GeometricalLineLoad(BH.oM.Geometry.Line line, Vector forceA, Vector forceB, Vector momentA = null, Vector momentB = null)
        {
            Location = line;
            ForceA = forceA;
            ForceB = forceB;
            MomentA = momentA == null ? new Vector(0, 0, 0) : momentA;
            MomentB = momentB == null ? new Vector(0, 0, 0) : momentB;
        }


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public LoadType GetLoadType()
        {
            return LoadType.Geometrical;
        }



        //public Loadcase Loadcase
        //{
        //    get
        //    {
        //        return m_Loadcase;
        //    }
        //    set
        //    {
        //        if (m_Loadcase != null && m_Loadcase.LoadRecords != null) m_Loadcase.LoadRecords.Remove(this);
        //        m_Loadcase = value;
        //        if (m_Loadcase != null && m_Loadcase.LoadRecords != null) m_Loadcase.LoadRecords.Add(this);
        //    }
        //}



    }
}
