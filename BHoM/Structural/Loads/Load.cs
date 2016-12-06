using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Base;
using System.ComponentModel;

namespace BHoM.Structural.Loads
{

    public enum LoadAxis
    {
        Global,
        Local,
    }

    /// <summary>
    /// Interface implemented by all loading related classes
    /// </summary>
    public interface ILoad : IBase
    {
        LoadType LoadType { get; }
        /// <summary>Loadcase as BHoM object</summary>
        BHoM.Structural.Loads.Loadcase Loadcase { get; set; }
        LoadAxis Axis { get; set; }
        bool Projected { get; set; }
    }

    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public abstract class Load<T> : BHoMObject, ILoad where T : IBase
    {
        private Loadcase m_Loadcase;
        private BHoM.Base.Group<T> m_Objects;

        internal Load() { m_Objects = new BHoM.Base.Group<T>(); }

        [DefaultValue(LoadAxis.Global)]
        public LoadAxis Axis
        {
            get; set;
        }
        [DefaultValue(false)]
        public bool Projected { get; set; }
        /// <summary>Loadcase as BHoM object</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase
        {
            get
            {
                return m_Loadcase;
            }
            set
            {            
                if (m_Loadcase != null && m_Loadcase.LoadRecords!= null) m_Loadcase.LoadRecords.Remove(this);                
                m_Loadcase = value;
                if (m_Loadcase != null && m_Loadcase.LoadRecords != null) m_Loadcase.LoadRecords.Add(this);
            }
        }

        public abstract LoadType LoadType { get; }

        /// <summary>A list of structural elements that the nodal load is applicable to</summary>
        public BHoM.Base.Group<T> Objects
        {
            get { return m_Objects; }
            set { m_Objects = value; }
        } 

    }
}
