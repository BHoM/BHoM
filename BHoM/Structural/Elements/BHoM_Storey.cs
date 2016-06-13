using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    /// <summary>
    /// Storey class to store information about building storeys for post processing of results
    /// </summary>
    public class Storey : BHoM.Global.BHoMObject, IStructuralObject
    {
        /// <summary>Storey number</summary>
        public int Number { get; set; }

        /// <summary>Storey level (in metres)</summary>
        public double Level { get; set; }

        /// <summary>Storey name</summary>
        public string Name { get; set; }

        /// <summary>Storey height</summary>
        public double Height { get; set; }

        /// <summary>
        /// Constructs and empty storey object
        /// </summary>
        public Storey()
        {
        }

        /// <summary>
        /// Constructs a storey object using number and name. If number and/or name are not known, use 0 and "" respectively.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public Storey(int number, string name)
            : this()
        {
            this.Number = number;
            this.Name = name;
        }

    }
}
