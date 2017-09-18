using BH.oM.Geometry;
using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Elements
{
    public class Grid : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Plane Plane { get; set; }

        public Line Line { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Grid() { }

        /***************************************************/

        public Grid(Plane plane, Line line)
        {
            Line = line;
            Plane = plane;
        }

    }
}
