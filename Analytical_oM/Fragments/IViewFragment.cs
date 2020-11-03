using BH.oM.Base;
using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    [Description("Interface common to all ViewFragments.")]
    public interface IViewFragment : IFragment
    {
        Point Position { get; set; }
    }
}
