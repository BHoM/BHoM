﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environmental.Interface;
using BH.oM.Environmental.Properties;

namespace BH.oM.Environmental.Elements
{
    public class AirHandlingUnit : Equipment
    {
        public AirHandlingUnitProperties AHUProperties;

        public override IEquipmentProperties EquipmentProperties
        {
            get
            {
                return AHUProperties;
            }

            set
            {
                AHUProperties = value as AirHandlingUnitProperties;
            }
        }
    }
}
