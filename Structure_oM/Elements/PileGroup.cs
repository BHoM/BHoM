﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Spatial.Layouts;
using BH.oM.Spatial.ShapeProfiles;
using BH.oM.Structure.SectionProperties;

namespace BH.oM.Structure.Elements
{
    public class PileGroup : BHoMObject, IFoundation
    {
        [Description("The length of the piles within the PileGroup.")]
        public virtual double PileLength { get; set; }

        [Description("Section property of the PileGroup, containing all sectional constants and material as well as profile geometry and dimensions, where applicable.")]
        public virtual ISectionProperty PileSection { get; set; } = null;

        [Description("Pile Layout defining the position of the piles about the World Origin.")]
        public virtual ExplicitLayout PileLayout { get; set; } = null;

    }
}