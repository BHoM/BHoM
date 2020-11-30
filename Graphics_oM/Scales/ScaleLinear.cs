using BH.oM.Base;
using BH.oM.Data.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Scales
{
    [Description("Scale for mapping a continuous, quantitative input domain to a continuous output range.")]
    public class ScaleLinear:  IScale
    {
        public virtual Domain Domain { get; set; } = new Domain(0, 1);

        public virtual Domain Range { get; set; } = new Domain(0, 1);

        public virtual bool Clamp { get; set; } = false;

        public virtual bool Nice { get; set; } = false;

        public virtual string Name { get; set; } = "";
    }
    
}
