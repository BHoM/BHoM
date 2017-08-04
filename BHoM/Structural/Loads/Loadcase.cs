using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Simple Loadcase class
    /// </summary>
    public class Loadcase : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadNature Nature { get; set; } = LoadNature.Other;

        public double SelfWeightMultiplier { get; set; } = 1.0;

        /// <summary>
        /// Collection of nodes that are applied under this loadcase
        /// </summary>
        public List<ILoad> LoadRecords { get; set; } = new List<ILoad>();

        public int Number { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Loadcase() { }

        /***************************************************/

        public Loadcase(string name, LoadNature nature, double selfWeightMultiplier = 0)
        {
            Name = name;
            Nature = nature;
            SelfWeightMultiplier = selfWeightMultiplier;
        }


        /***************************************************/
        /**** ICase Interface                           ****/
        /***************************************************/

        public CaseType GetCaseType() //TODO: Do we need this?
        {
            return CaseType.Simple;
        }
 
    }

}


//private List<ILoad> m_Loads;