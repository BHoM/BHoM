using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Construction
{
    [Description("A class defining the environmental impacts associated with the construction activities of a building.")]
    public class ConstructionActivities : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("List of environmental factors associated with the construction process. The default values are indicative only and should be replaced with project specific data where available. All factors stated per unit area.")]
        public virtual List<IEnvironmentalFactor> EnvironmentalFactors { get; set; } = new List<IEnvironmentalFactor>() { new ClimateChangeFossilFactor { Value = 40 }, new ClimateChangeBiogenicFactor { Value = 0 }, new ClimateChangeLandUseFactor { Value = 0 }, new ClimateChangeTotalFactor { Value = 40 }, new ClimateChangeTotalNoBiogenicFactor { Value = 40 } };

        [Area]
        [Description("The total gross internal area (GIA) of the constructed building. This is used to scale the environmental factors above.")]
        public virtual double ConstructedFloorArea { get; set; } = 0;

        /***************************************************/
    }
}
