using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Construction
{
    [Description("ConstructionEmissions defines the emissions associated with the construction phase of the building lifecycle, including pre-construction demolition activities, construction activities, waste rates and whether the material is reused on site.")]
    public class ConstructionEmissions : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The waste rate associated with the construction process, which will increase the amount of material required to be ordered and processed to account for waste. This factor is used to compute A5.3 emissions based on outputs available from either EPD and/or transport as well as disposal factors.")]
        public virtual WasteRate WasteRate { get; set; } = null;

        [Description("Whether the material is reused on site, which would reduce the emissions associated with transport and processing. Controls wether the C2 factor for the material should be included or not when computing the emissions based on the A5.3 (waste) factor. Defaults to false, meaning the C2 factor is included.")]
        public virtual bool ResuedOnSite { get; set; } = false;

        /***************************************************/
    }
}
