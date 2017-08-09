using System;

using System.Collections.Generic;
using BH.oM.Base;


namespace BH.oM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    public class Arc : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Start { get; set; } = new Point();

        public Point End { get; set; } = new Point();

        public Point Middle { get; set; } = new Point();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Arc() { }

        /***************************************************/

        public Arc(Point start, Point middle, Point end)
        {
            Start = start;
            End = end;
            Middle = middle;
        }

    }
}



