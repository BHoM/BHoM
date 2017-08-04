using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structural.Elements;
using BH.oM.Structural.Results;

namespace BH.oM.Structural.Interface
{
    /// <summary>
    /// Interface for setting elements to be designed in an external application
    /// </summary>
    public interface IDesignMemberAdapter //TODO: Probably needs to be deleted or moved to BHoM_Adapter
    {
        bool SetBarDesignElement(List<Bar> bars, out List<string> ids);

        List<string> GetBarDesignElement(out List<Bar> bars, List<string> ids = null);

    }
}
