using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Simple Loadcase class
    /// </summary>
    [Serializable]
    public class Loadcase : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadNature Nature { get; set; } = LoadNature.Other;
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