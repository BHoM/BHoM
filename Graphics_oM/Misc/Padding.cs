using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Misc
{
    public class Padding : BHoMObject
    {
        public virtual double Top { get; set; } = 20;

        public virtual double Bottom { get; set; } = 50;

        public virtual double Left { get; set; } = 50;

        public virtual double Right { get; set; } = 20;
    }
}
