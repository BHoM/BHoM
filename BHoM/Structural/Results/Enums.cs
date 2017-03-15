using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
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
        SlabReinforcement,
        NodeCoordinates,
        BarCoordinates
    }
    public enum ResultOrder
    {
        Name,
        Loadcase,
        TimeStep,
        None
    }
}
