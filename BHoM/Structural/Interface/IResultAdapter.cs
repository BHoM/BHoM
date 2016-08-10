using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Interface
{
    public interface IResultAdapter
    {
        bool GetBarForces(List<int> bars, List<int> cases, int divisions);
        bool GetBarStresses();

        bool GetNodeReactions();
        bool GetNodeDisplacements();
        bool GetNodeVelocities();
        bool GetNodeAccelerations();

        bool GetModalResults();

        bool GetPanelForces();
        bool GetPanelStress();       
    }
}
