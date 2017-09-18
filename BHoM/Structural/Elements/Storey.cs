using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// Storey class to store information about building storeys for post processing of results
    /// </summary>
    public class Storey : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>Storey level (in metres)</summary>
        public double Elevation { get; set; }

        /// <summary>Storey height</summary>
        public double Height { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Storey() { }

        /***************************************************/

        /// <summary>
        /// Constructs a storey object using number and name. If number and/or name are not known, use 0 and "" respectively.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public Storey(string name, double elevation, double height)
            : this()
        {
            Name = name;
            Elevation = elevation;
            Height = height;
        }

    }
}



