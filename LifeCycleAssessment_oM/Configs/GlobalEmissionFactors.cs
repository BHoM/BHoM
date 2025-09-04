using BH.oM.Base;
using BH.oM.LifeCycleAssessment.MaterialFragments.Construction;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.Configs
{
    public class GlobalEmissionFactors : BHoMObject, IEvaluationConfig
    {
        [Description("The demolition activities associated with the pre-construction process, which will increase the emissions associated with the construction phase of the building lifecycle. The impact on the final element will be scaled according to its part of the total mass of the building.")]
        public virtual PreConstructionDemolition PreConstructionDemolition { get; set; } = null;

        [Description("The construction activities associated with the construction process, which will increase the emissions associated with the construction phase of the building lifecycle. The impact on the final element will be scaled according to its part of the total mass of the building.")]
        public virtual ConstructionActivities ConstructionActivities { get; set; } = null;

        [Mass]
        [Description("The total mass of the building. When evaluating an element, its part impact for pre-construction demolition as well as site activities will be scaled by this factor.")]
        public virtual double TotalBuildingMass { get; set; }

        [Description("Boolean that indicates if the provided mass is only the mass of the structure (true) or the total mass of the building including non-structural elements (false). This is relevant for scaling the pre-construction demolition and construction activities emissions which are provided per unit area.")]
        public virtual bool StructuresOnlyMass { get; set; } = false;
    }
}
