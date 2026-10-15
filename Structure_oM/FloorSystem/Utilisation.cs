using System.Collections.Generic;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Reinforcement;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Structure.Elements;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.FloorSystem
{
    public class Utilisation : BHoMObject, IImmutable
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/
        [Description("Name of the structural element.")]
        public virtual string Element { get; } = null;

        [Description("Utilisation ratio of the structural element.")]
        public virtual double Ratio { get; } = 0;

        [Description("The failure mode corresponding to the utilisation ratio.")]
        public virtual string LimitState { get; } = null;

        [Description("Design assumptions to determine the element's utilisation.")]
        public virtual string Assumptions { get; } = null;

        [Description("Utilisations of constitutive elements, i.e. non-governing limit states.")]
        public virtual IReadOnlyList<Utilisation> Utilisations { get; } = null;

        /***************************************************/

        public Utilisation(string element, double ratio, string limitState, string assumptions, IReadOnlyList<Utilisation> utilisations)
        {
            Element = element;
            Ratio = ratio;
            LimitState = limitState;
            Assumptions = assumptions;
            Utilisations = utilisations;
        }

    }
}
