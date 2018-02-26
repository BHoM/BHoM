namespace BH.oM.Structural.Properties
{
    public enum PanelModifier
    {
        //In plane axial stiffness in the local X direction
        f11 = 0,
        //In plane axial stiffness in the local XY direction
        f12,
        //In plane axial stiffness in the local Y direction
        f22,
        //In plane flexural stiffness in the local X direction
        m11,
        //In plane flexural stiffness in the local XY direction
        m12,
        //In plane flexural stiffness in the local Y direction
        m22,
        //Shear stiffness in the X - normal direction
        v13,
        //Shear stiffness in the Y - normal direction
        v23,
        //Mass modifier
        Mass,
        //weight modifier
        Weight
    }   
}
