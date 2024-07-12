using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;

namespace BH.oM.Structure.Elements
{
    public class RetainingWall : BHoMObject, IElementM //Question if this should be a bhomobject or a compisiteobject. Cant be both. Settled on BHoMObject for now.
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Stem of the retaining wall.")]
        public virtual Stem Stem { get; set; } = new Stem();

        [Description("Footing of the retaining wall.")]
        public virtual Footing Footing { get; set; } = new Footing();

        [Description("The retained height of the wall. From Ground to top of wall.")] // Definition of this number. Where does it measure from. 
        public virtual double RetainedHeight { get; set; } = 0.0;

        [Description("Shortest distance from top of footing to surfacelevel.")]
        public virtual double CoverDepth { get; set; } = 0.0;

        [Description("Shortest distance from bottom of footing to ground water level.")] // Should this number be subjective to the object or objective. Distance to or a objevtive elevation from datum/sealevel??
        public virtual double GroundWaterLevel { get; set; } = 0.0;

        [Description("Angle of retention between wall and ground. Measured at top of wall in radians.")] 
        public virtual double RetentionAngle { get; set; } = 0.0;

        /***************************************************/
    }
}