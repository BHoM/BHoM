﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;
using System.Threading;

namespace BH.oM.Acoustic
{
    [Serializable]
    public class Panel : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Mesh Geometry { get; set; } = new Mesh();

        public static int PanelID { get; set; } = 0;

        public Dictionary<Frequency, double> R { get; set; } = new Dictionary<Frequency, double>
        {
            { Frequency.Hz63, 1 }, { Frequency.Hz125, 1 }, { Frequency.Hz250, 1 }, { Frequency.Hz500, 1 }, { Frequency.Hz1000, 1 },
            { Frequency.Hz2000, 1 }, { Frequency.Hz4000, 1 }, { Frequency.Hz8000, 1 }, { Frequency.Hz16000, 1 },
        };
    }
}
