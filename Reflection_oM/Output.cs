using BH.oM.Base;
using BH.oM.Reflection.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection
{
    /***************************************************/

    public class Output<T> : BHoMObject, IOutput
    {
        public T Item1 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2> : BHoMObject, IOutput
    {
        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3> : BHoMObject, IOutput
    {
        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public T3 Item3 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4> : BHoMObject, IOutput
    {
        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public T3 Item3 { get; set; }

        public T4 Item4 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4, T5> : BHoMObject, IOutput
    {
        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public T3 Item3 { get; set; }

        public T4 Item4 { get; set; }

        public T5 Item5 { get; set; }
    }

    /***************************************************/
}
