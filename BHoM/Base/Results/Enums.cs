using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Results
{
    public enum ResultType
    {
        Undefined,
        NodeDisplacement,
        NodeReaction,
        NodeVelocity,
        NodeAcceleration,
        BarForce,
        BarStress,
        PanelForce,
        PanelStress,
        Modal,
        Utilisation,
        SlabReinforcement
    }
}
