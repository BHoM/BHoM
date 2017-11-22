﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Geometry;
using System.Threading;

namespace BH.oM.Acoustic
{
    public class Receiver : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Location { get; set; } = new Point();

        public string Category { get; set; } = "Omni";

        public int ReceiverID { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Receiver() { }

        /***************************************************/

        public Receiver(Point location)
        {
            Location = location;
        }

        /***************************************************/

        public Receiver(Point position, string category, int receiverID)
        {
            Location = position;
            Category = category;
            ReceiverID = Interlocked.Increment(ref globalInstanceCount);
        }


        /***************************************************/
        /**** Static shared fields                      ****/
        /***************************************************/

        public static int globalInstanceCount = -1;
    }
}
