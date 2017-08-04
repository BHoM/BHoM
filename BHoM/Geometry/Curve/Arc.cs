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

        public Arc(Point start, Point end, Point middle)
        {
            Start = start;
            End = end;
            Middle = middle;
        }

    }
}









///***************************************************/
///**** ICurve Interface                          ****/
///***************************************************/

//public Point GetStart()
//{
//    return Start;
//}

///***************************************************/

//public Point GetEnd()
//{
//    return End;
//}

///***************************************************/

//public Vector GetStartDir()
//{
//    throw new NotImplementedException(); //TODO: get start dir of arc
//}

///***************************************************/

//public Vector GetEndDir()
//{
//    throw new NotImplementedException(); //TODO: get end dir of arc
//}

///***************************************************/

//public bool IsClosed()
//{
//    return Start == End;
//}



