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
    public class FloorDesign : BHoMObject, IImmutable
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("Name of the FloorSystem.")]
        public override string Name { get; set; } = null;

        [Description("Configuration data for the floor.")]
        public virtual IFloorConfiguration FloorConfiguration { get; } = null;

        [Description("Configuration data for the floor.")]
        public virtual ColumnData ColumnConfiguration { get; } = null;

        [Description("Length of the primary beam or local X dimension.")]
        [Length]
        public virtual double SpanX { get; } = 0;

        [Description("Length of the secondary beam or local Y dimension.")]
        [Length]
        public virtual double SpanY { get; } = 0;

        [Description("Uniformly applied super-imposed dead load on the floor area.")]
        [Pressure]
        public virtual double LoadSDL { get; } = 0;

        [Description("Uniformly applied live load on the floor area.")]
        [Pressure]
        public virtual double LoadLL { get; } = 0;

        [Description("Total floor depth from top of slab to bottom of deepest beam.")]
        [Length]
        public virtual double Depth { get; } = 0;

        [Description("Mass of the floor bay per area.")]
        [MassPerUnitArea]
        public virtual double Mass { get; } = 0;

        [Description("Structural fire rating requirement.")]
        [Time]
        public virtual double FireRating { get; } = 0;

        [Description("Floor bay design edge condition. Default as interior")]
        public virtual EdgeCondition EdgeCondition { get; } = EdgeCondition.Interior;

        [Description("Structural engineering code to which the floor bay has been designed.")]
        public virtual string DesignCode { get; } = null;

        [Description("Design assumptions and additional information.")]
        public virtual string DesignNotes { get; } = null;

        /***************************************************/
        /****            Public Constructors            ****/
        /***************************************************/

        public FloorDesign(IFloorConfiguration floorConfiguration,
                            ColumnData columnConfiguration,
                            double spanX,
                            double spanY,
                            double loadSDL,
                            double loadLL,
                            double depth,
                            double mass,
                            EdgeCondition edgeCondition,
                            double fireRating,
                            string designCode,
                            string designNotes
                            )
        {
            FloorConfiguration = floorConfiguration;
            ColumnConfiguration = columnConfiguration;
            SpanX = spanX;
            SpanY = spanY;
            LoadSDL = loadSDL;
            LoadLL = loadLL;
            Depth = depth;
            Mass = mass;
            FireRating = fireRating;
            EdgeCondition = edgeCondition;
            DesignCode = designCode;
            DesignNotes = designNotes;
        }

        /***************************************************/


    }
}
