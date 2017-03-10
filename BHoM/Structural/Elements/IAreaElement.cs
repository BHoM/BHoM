using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Structural.Properties;
using BHoM.Base;

namespace BHoM.Structural.Elements
{

    public enum AreaElementType
    {
        Panel,
        Mesh
    }

    public interface IAreaElement : IObject
    {
        PanelProperty PanelProperty { get; set; }
        AreaElementType ElementType { get; }
    }
}
