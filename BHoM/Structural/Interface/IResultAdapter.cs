using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Interface
{
    public interface IResultAdapter
    {
        bool GetBarForces(List<string> bars, List<string> cases, int divisions, ResultOrder orderBy, out Dictionary<string, ResultSet<BarForce>> results);
        bool GetBarStresses();

        bool GetNodeReactions(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, ResultSet<NodeReaction>> results);
        bool GetNodeDisplacements();
        bool GetNodeVelocities();
        bool GetNodeAccelerations();

        bool GetModalResults();

        bool GetPanelForces();
        bool GetPanelStress();
    }
}

