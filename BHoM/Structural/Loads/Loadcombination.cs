using BH.oM.Base;
using System;
using System.Collections.Generic;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Loadcombination, different to loadcase as combination also contains information
    /// on the combinations of loads with load factors
    /// </summary>
    public class LoadCombination : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Tuple<double, ICase>> LoadCases { get; set; } = new List<Tuple<double, ICase>>();

        public int Number { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LoadCombination() { }

        /***************************************************/

        public LoadCombination(string name, List<Tuple<double, ICase>> loadCases)
        {
            LoadCases = loadCases;
            Name = name;
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
