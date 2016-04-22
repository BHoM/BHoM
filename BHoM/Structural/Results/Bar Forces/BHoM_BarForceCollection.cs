
using System.Collections.Generic;

namespace BHoM.Structural.Results.Bars
{
    /// <summary>
    /// Collection of bar forces, defines a set of bar forces with the
    /// ability to get and set envelopes
    /// </summary>
    public class BarForceCollection 
    {
        /// <summary>Bar force dictionary which forms the collection</summary>
        private Dictionary<string, BarForce> internalDict { get; set; }

        /// <summary>Constructs and empty bar force collection</summary>
        public BarForceCollection()
        {
            internalDict = new Dictionary<string, BarForce>();
        }
        
        /////////////////
        //// METHODS ////
        /////////////////

        /// <summary>Adds a bar force to the collection, using a key "LoadcaseNumber:BarNumber:ForcePosition"</summary>
        public void Add (BarForce barForce)
        {
            string key = 
                System.Convert.ToString(barForce.LoadcaseNumber)+ ":" +
                System.Convert.ToString(barForce.BarNumber) + ":" +
                System.Convert.ToString(barForce.Position);
            if (!internalDict.ContainsKey(key)) internalDict.Add(key, barForce);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loadcaseNumber"></param>
        /// <param name="barNumber"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public BarForce TryGetBarForce(int loadcaseNumber, int barNumber, int position)
        {
            BarForce barForce;
            internalDict.TryGetValue(
                System.Convert.ToString(loadcaseNumber) + ":" +
                System.Convert.ToString(barNumber) + ":" +
                System.Convert.ToString(position),
                out barForce);
            return barForce;
        }
    }
}
