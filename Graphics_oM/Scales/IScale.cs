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
    [Description("Base interface for all graphics scales.")]
    public interface IScale : IObject
    {
        string Name { get; set; }
    }
}
