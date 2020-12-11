using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    public class FontConfig : IObject
    {
        public virtual double Height { get; set; } = 1;

        public virtual Font Font { get; set; } = Font.Arial;

        public virtual Color Colour { get; set; } = Color.FromArgb(80, 255, 41, 105);

        public virtual bool Bold { get; set; } = false;

        public virtual bool Italic { get; set; } = false;
    }
}
