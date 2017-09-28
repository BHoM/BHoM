﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Acoustic
{
    public class AcousticRASTIParameters : Parameter
    {
        // Hard coded AcousticParameters, discuss further with M. Harrison
        public AcousticRASTIParameters()
        {
            Frequencies = new List<double> { 1.0, 2.0, 4.0, 8.0, 0.7, 1.4, 2.8, 5.6, 11.2 };    // Are the frequencies replicated at each octave?
            Octaves = new List<double> { 500, 2000 };
        }
    }
}