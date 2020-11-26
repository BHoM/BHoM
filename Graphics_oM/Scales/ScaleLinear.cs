using BH.oM.Base;
using BH.oM.Data.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Scales
{
    public class ScaleLinear:  IScale
    {
        public virtual Domain Domain { get; set; } = new Domain(0, 1);

        public virtual Domain Range { get; set; } = new Domain(0, 1);

        public virtual bool Clamp { get; set; } = false;

        public virtual bool Nice { get; set; } = false;

        public virtual string Name { get; set; } = "";
    }
    
}
