using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment
{
    [Description("base itnerface for all Global Warming Potential results.")]
    public interface IGlobalWarmingPotentialPhaseData : ILifeCycleAssessmentPhaseData
    {
        [Description("Amount of carbon stored (sequestered) in biological materials.")]      
        double BiogenicCarbon { get; }
    }
}
