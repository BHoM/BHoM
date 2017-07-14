using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Structural.Loads
{

    public enum LoadAxis
    {
        Global,
        Local,
    }

    /// <summary>
    /// Interface implemented by all loading related classes
    /// </summary>
    public interface ILoad : IObject        //TODO: Write this on a separate file
    {
        LoadType GetLoadType();
        /// <summary>Loadcase as BHoM object</summary>
        BH.oM.Structural.Loads.Loadcase Loadcase { get; set; }
        LoadAxis Axis { get; set; }
        bool Projected { get; set; }
    }




    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public abstract class Load<T> : BHoMObject, ILoad where T : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Loadcase Loadcase { get; set; }

        public List<T> Objects { get; set; } = new List<T>();

        public LoadAxis Axis { get; set; } = LoadAxis.Global;

        public bool Projected { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public abstract LoadType GetLoadType();





        //internal Load() { m_Objects = new BHoMList<T>(); }


        ///// <summary>Loadcase as BHoM object</summary>
        //public BH.oM.Structural.Loads.Loadcase Loadcase
        //{
        //    get
        //    {
        //        return m_Loadcase;
        //    }
        //    set
        //    {            
        //        if (m_Loadcase != null && m_Loadcase.LoadRecords!= null) m_Loadcase.LoadRecords.Remove(this);                
        //        m_Loadcase = value;
        //        if (m_Loadcase != null && m_Loadcase.LoadRecords != null && !m_Loadcase.LoadRecords.Contains(this)) m_Loadcase.LoadRecords.Add(this);
        //    }
        //}





    }
}
