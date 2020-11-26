using BH.oM.Base;
using BH.oM.Data.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Scales
{
    public class ScaleOrdinal :  IScale
    {
        public virtual List<string> Domain { get; set; } = new List<string>();

        public virtual List<object> Range { get; set; } = new List<object>();

        public virtual string Name { get; set; } = "";

    }
}
