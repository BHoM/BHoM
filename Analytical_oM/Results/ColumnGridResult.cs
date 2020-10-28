using BH.oM.Base;
using BH.oM.Analytical.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public class ColumnGridResult : ProcessResult
    {
        public virtual double Distance { get; set; } = 0;

        public virtual bool Passed { get; set; } = false;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/
        public ColumnGridResult(IComparable objectId, IComparable resultCase, double timeStep, double distance, bool passed) : base(objectId, resultCase, timeStep)
        {
            Distance = distance;
            Passed = passed;
        }
    }
}