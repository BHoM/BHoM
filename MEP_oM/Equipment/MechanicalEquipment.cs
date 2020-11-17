using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.MEP.Equipment.Parts;
using BH.oM.MEP.Enums;
using BH.oM.Geometry;

namespace BH.oM.MEP.Equipment
{
    class MechanicalEquipment
    {
        [Description("A type which describes the mechanical equipment more specifically whether it's an air handling unit, fan coil unit, boiler or chiller.")]
        public virtual MechanicalEquipmentType MechanicalEquipmentType { get; set; } = MechanicalEquipmentType.Undefined;

        [Description("A collection of the parts (Air Handling Unit, Fans, Coils, Energy Wheel, Filters, Electrical Connectors) that make up the Air Handling Unit")]
        public virtual List<IPart> Parts { get; set; } = new List<IPart>();

        [Description("The point in space for the location of the mechanical equipment.")]
        public virtual Point Position { get; set; } = new Point();
    }
}
