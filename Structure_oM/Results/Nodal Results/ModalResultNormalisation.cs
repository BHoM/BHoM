using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.Results.Nodal_Results
{
    public enum ModalResultNormalisation
    {
        [Description("Results normalised so that the absolute value of the maximum component of the mode shape for the mode and case is equal to 1.")]
        EigenvectorComponent,
        [Description("Results normalised so that the square root sum of squares for the displacement of the mode and case is equal to 1.")]
        EigenvectorTotal,
        [Description("Results normalised so that the absolute value of the maximum component of the mass for the mode and case is equal to 1.")]
        MassComponent,
        [Description("Results normalised so that the square root sum of squares for mass of the mode and case is equal to 1.")]
        MassTotal
    }
}
