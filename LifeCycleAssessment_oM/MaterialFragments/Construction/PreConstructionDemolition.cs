using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Construction
{
    [Description("A class defining the environmental impacts associated with the demolition of existing buildings prior to construction of a new building.")]
    public class PreConstructionDemolition : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("List of environmental factors associated with the demolition process. The default values are indicative only and should be replaced with project specific data where available. All factors stated per unit area.")]
        public virtual List<IEnvironmentalFactor> EnvironmentalFactors { get; set; } = new List<IEnvironmentalFactor>() { new ClimateChangeFossilFactor { Value = 35 }, new ClimateChangeBiogenicFactor { Value = 0 }, new ClimateChangeLandUseFactor { Value = 0 }, new ClimateChangeTotalFactor { Value = 35 }, new ClimateChangeTotalNoBiogenicFactor { Value = 35 } };

        [Area]
        [Description("The area of floor that is demolished prior to construction of the new building. This is used to scale the environmental factors above.")]
        public virtual double DemolishedFloorArea { get; set; } = 0;

        /***************************************************/
    }
}
