using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public class SpatialRelation : Relation, IRelation, IElement1D
    {
        public virtual ICurve Curve { get; set; }

    }
}
