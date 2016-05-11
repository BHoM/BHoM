using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Loadcase class 
    /// </summary>
    public abstract class Loadcase : BHoMObject
    {
        /// <summary>Loadcase number</summary>
        public int Number { get; set; }

        /// <summary>
        /// Case Type
        /// </summary>
        public abstract CaseType CaseType { get; }
    }

    /// <summary>
    /// Simple Loadcase class
    /// </summary>
    public class SimpleCase : Loadcase
    {
        /// <summary>
        /// Gets or Sets the loading nature of the loadcase
        /// </summary>
        public LoadNature Nature { get; set; }

        /// <summary>
        /// Gets or sets the selfweight multiplier of the loadcase
        /// </summary>
        public double SelfWeightMultiplier { get; set; }


        /// <summary>
        /// Gets the Case type of loadcase
        /// </summary>
        public override CaseType CaseType
        {
            get
            {
                return CaseType.Simple;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">LC number</param>
        /// <param name="name">LC name</param>
        /// <param name="nature">Loading nature</param>
        /// <param name="selfWeightMultiplier"></param>
        public SimpleCase(int number, string name, LoadNature nature, double selfWeightMultiplier = 0)
        {
            Number = number;
            Name = name;
            Nature = nature;
            SelfWeightMultiplier = selfWeightMultiplier;
        }
    }
}
