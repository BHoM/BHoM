using BH.oM.Geometry;
using BH.oM.Base;


namespace BH.oM.Structural.Loads
{
    public class GeometricalAreaLoad : BHoMObject, ILoad  
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Contour { get; set; }

        public Loadcase Loadcase { get; set; } = new Loadcase();

        /// <summary>Force - fx, fy, fz defined as a BH.oM.Geometry.Vector</summary>
        public Geometry.Vector Force { get; set; }

        public LoadAxis Axis { get; set; } = LoadAxis.Global;

        public bool Projected { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeometricalAreaLoad() { }

        /***************************************************/

        public GeometricalAreaLoad(ICurve contour, Geometry.Vector force)
        {
            Contour = contour;
            Force = force;
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
