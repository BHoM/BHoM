using BHoM.Structural;
using BHoM.Structural.Loads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    public interface BHoM_IO
    {
        bool GetNodes(out List<Node> nodes, string option = "");
        bool GetBars(out List<Bar> bars, string option = "");
        bool GetPanels(out List<Panel> panels, string option = "");
        //bool GetMesh<TKey>(out ObjectManager<TKey, FEMesh> mesh, string option = "");
        //bool GetOpenings<TKey>(out ObjectManager<TKey, >)
        bool GetLoads(out List<ILoad> loads, string option = "");
        bool GetLoadcases(out List<ICase> cases);
    }
}
