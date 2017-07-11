using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Loadcase class 
    /// </summary>
    public interface ICase : IObject
    {
        /// <summary>Loadcase number</summary>
        int Number { get; set; }

        /// <summary>
        /// Case Type
        /// </summary>
        CaseType CaseType { get; }
    }

    /// <summary>
    /// Simple Loadcase class
    /// </summary>
    public class Loadcase : BHoMObject, ICase
    {
        private List<ILoad> m_Loads;

        /// <summary>
        /// Gets or Sets the loading nature of the loadcase
        /// </summary>
        public LoadNature Nature { get; set; }

        /// <summary>
        /// Gets or sets the selfweight multiplier of the loadcase
        /// </summary>
        public double SelfWeightMultiplier { get; set; }

        /// <summary>
        /// Collection of nodes that are applied under this loadcase
        /// </summary>
        /// <returns></returns>
        public List<ILoad> LoadRecords
        {
            get { return m_Loads; }
        }

        /// <summary>
        /// Gets the Case type of loadcase
        /// </summary>
        public CaseType CaseType
        {
            get
            {
                return CaseType.Simple;
            }
        }

        public int Number
        {
            get; set;
        }

        public Loadcase()
        {
            m_Loads = new List<ILoad>();
            Nature = LoadNature.Other;
            SelfWeightMultiplier = 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">LC number</param>
        /// <param name="name">LC name</param>
        /// <param name="nature">Loading nature</param>
        /// <param name="selfWeightMultiplier"></param>
        public Loadcase(string name, LoadNature nature, double selfWeightMultiplier = 0) : this()
        {
            Name = name;
            Nature = nature;
            SelfWeightMultiplier = selfWeightMultiplier;
        }
    }

}
