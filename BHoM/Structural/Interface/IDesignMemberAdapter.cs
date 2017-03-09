using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Structural.Elements;
using BHoM.Base.Results;
using BHoM.Structural.Results;

namespace BHoM.Structural.Interface
{
    /// <summary>
    /// Interface for setting elements to be designed in an external application
    /// </summary>
    public interface IDesignMemberAdapter
    {
        bool SetBarDesignElement(List<Bar> bars, out List<string> ids);

        List<string> GetBarDesignElement(out List<Bar> bars, List<string> ids = null);

    }
}
