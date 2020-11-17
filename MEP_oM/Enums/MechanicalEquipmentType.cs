using System.ComponentModel;

namespace BH.oM.MEP.Enums
{
    /***************************************************/

    [Description("A type of mechanical equipment (air handling unit, boiler, chiller, fan coil unit.)")]
    public enum MechanicalEquipmentType
    {
        Undefined,
        AirHandlingUnit,
        AirSeparator,
        AirSourceHeatPump,
        Boiler,
        CabinetUnitHeater,
        Chiller,
        CoolingTower,
        ExpansionTankVessel,
        Fan,
        FanCoilUnit,
        HeatExchanger,
        HeatingAndVentilationUnit,
        Pump,
        UnitHeater,
        VariableAirVolumeBox,
        WaterSourceHeatPump,
        WaterStorageTank,
    }

    /***************************************************/
}
