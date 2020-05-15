using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;


namespace BH.oM.Structure.Elements
{
    public class Cut : BHoMObject
    {
        [Description("Profile Representing shape of cut to be extruded")]
        public virtual ICurve Curve { get; set; } = null;

        [Description("Thickness of Cut Extrusion")]
        public virtual double Thickness { get; set; } = 0;

        [Description("Object which needs cut")]
        public virtual BHoMObject CutObject { get; set; } = null;

    }

}
