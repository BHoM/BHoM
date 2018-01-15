using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environmental.Interface;
using BH.oM.Structural.Elements;

namespace BH.oM.Environmental.Elements
{
    public abstract class Equipment : BHoMObject, IBuildingObject
    {
        public Storey Storey;
        public abstract IEquipmentProperties EquipmentProperties { get; set; }
    }
}
