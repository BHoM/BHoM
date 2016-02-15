
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
        private Dictionary<string, BarForce> barForceDictionary { get; set; }

        /// <summary>Constructs and empty bar force collection</summary>
        public BarForceCollection()
        {
            barForceDictionary = new Dictionary<string, BarForce>();
        }

        /// <summary>Generates a key from a bar force object</summary>
        private string GenerateKey (BarForce barForce)
        {
            string key = barForce.BarNumber.ToString() + ":" + barForce.LoadcaseNumber.ToString() + ":" + barForce.ForcePosition;
            return key;
        }

        /// <summary>Add a bar force to a collection</summary>
        public void Add (BarForce barForce)
        {
            barForceDictionary.Add(GenerateKey(barForce), barForce);
        }



    }
}
