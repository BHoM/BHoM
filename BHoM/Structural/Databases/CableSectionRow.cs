using BHoM.Base.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Databases
{


    public class CableSectionRow : IDataRow
    {
        public string Name
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public int Id { get; set; }

        public double Diameter { get; set; }
        public double BreakingLoad { get; set; }
        public double LimitTension { get; set; }
        public double Area { get; set; }
        public double Weight { get; set; }
        public double AxialStiffness { get; set; }
        public string Construction { get; set; }
        public double SelfWeightEnd { get; set; }
        public double AdjustableSpeltFork { get; set; }
    }
}

