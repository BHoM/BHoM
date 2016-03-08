using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Loadcase class 
    /// </summary>
    public class Loadcase : BHoM.Global.BHoMObject
    {

        /// <summary>
        /// Constructs a loadcase by number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        internal Loadcase(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

    }
}
