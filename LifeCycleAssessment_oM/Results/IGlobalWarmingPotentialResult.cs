using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("base itnerface for all Global Warming Potential results.")]
    public interface IGlobalWarmingPotentialResult : ILifeCycleAssesmentResult
    {
        [Description("")]      
        double BiogenicCarbon { get; }
    }
}
