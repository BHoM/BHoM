namespace BH.oM.Structural.Results
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
