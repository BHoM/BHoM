using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BH.oM.Test.Results
{
    [Description("")]
    public enum InputOutputComparisonDiffingType
    {
        Equal,
        NoAvailableReferenceSet,
        IntroducedDifference,
        RemovedDifference,
        InputDataChanged,
        Difference,
        Improvement,
        Deterioration,
        RemovedException,
        IntroducedException,
        DataOnlyAvailableInReference
    }
}
