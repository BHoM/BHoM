using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class ConstantThickness : Property2D
    {
        public ConstantThickness() { }
        public ConstantThickness(string name) : base(name) { Type = PanelType.Undefined; }
        public ConstantThickness(string name, double thickness, PanelType type) : this(name)
        {
            Thickness = thickness;
            Type = type;
        }
    }
}
