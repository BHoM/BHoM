﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structural.Properties;
using BH.oM.Base;

namespace BH.oM.Structural.Elements
{
    public interface IAreaElement : IObject
    {
        PanelProperty PanelProperty { get; set; }
    }
}
