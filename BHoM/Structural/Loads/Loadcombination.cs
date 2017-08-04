using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Loadcombination, different to loadcase as combination also contains information
    /// on the combinations of loads with load factors
    /// </summary>
    [Serializable]
    public class LoadCombination : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICase> Loadcases { get; set; } = new List<ICase>();

        public List<double> LoadFactors { get; set; } = new List<double>();

        public int Number { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LoadCombination() { }

        /***************************************************/

        public LoadCombination(string name, List<ICase> loadcases, List<double> loadfactors)
        {
            Loadcases = loadcases;
            Name = name;
            LoadFactors = loadfactors;
        }


        /***************************************************/
        /**** ICase Interface                           ****/
        /***************************************************/

        public CaseType GetCaseType()
        {
            return CaseType.Combination;
        }

    }
}
