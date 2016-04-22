
using System.Collections.Generic;

namespace BHoM.Structural.Results.Nodes
{
    /// <summary>
    /// Collection of bar forces, defines a set of bar forces with the
    /// ability to get and set envelopes
    /// </summary>
    public class NodalResultCollection 
    {
        /// <summary>Nodal result dictionary which forms the collection</summary>
        private Dictionary<string, NodalResult> internalDict { get; set; }

        /// <summary>Constructs and empty nodal result collection</summary>
        public NodalResultCollection()
        {
            internalDict = new Dictionary<string, NodalResult>();
        }
        
        /////////////////
        //// METHODS ////
        /////////////////

        /// <summary>Adds a nodal result to the collection, using a key "NodeNumber:timeStep"</summary>
        public void Add (NodalResult nodalResult, double timeStep)
        {
            string key = 
                System.Convert.ToString(nodalResult.NodeNumber) + ":" +
                System.Convert.ToString(timeStep);
            if (!internalDict.ContainsKey(key)) internalDict.Add(key, nodalResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeNumber"></param>
        /// <param name="timeStep"></param>
        /// <returns></returns>
        public NodalResult TryGetNodalResult(int nodeNumber, double timeStep)
        {
            NodalResult nodalResult;
            internalDict.TryGetValue(
                System.Convert.ToString(nodeNumber) + ":" +
                System.Convert.ToString(timeStep),
                out nodalResult);
            return nodalResult;
        }
    }
}
