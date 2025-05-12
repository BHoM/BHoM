using BH.oM.Analytical.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.Results
{
    public interface IMaterialResult : IResultItem, IEnvironmentalResult
    {
        [Description("Name of the physical material evaluated.")]
        string MaterialName { get; }

        [Description("Name of the Environmental Product Declaration evaluated.")]
        string EnvironmentalProductDeclarationName { get;}

    }
}
