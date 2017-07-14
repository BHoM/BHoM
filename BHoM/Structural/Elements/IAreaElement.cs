using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structural.Properties;
using BH.oM.Base;

namespace BH.oM.Structural.Elements
{

    public enum AreaElementType     // TODO: only one class/enum/intefrace per file. 
    {
        Panel,
        Mesh
    }

    public interface IAreaElement : IObject
    {
        PanelProperty PanelProperty { get; set; }


        //AreaElementType GetElementType(); //TODO: We should probably get rid of this
    }
}
