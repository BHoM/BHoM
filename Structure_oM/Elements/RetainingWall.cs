using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.Reinforcement;

namespace BH.oM.Structure.Elements
{
    public class RetainingWall : BHoMObject //Question if this should be a bhomobject or a compisiteobject. Cant be both. 
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("RetainingWallStem object defining the stem.")]
        public virtual RetainingWallStem Stem { get; set; } = new RetainingWallStem();

        [Description("RetainingWallToe object defining the toe of the base.")]
        public virtual RetainingWallToe Toe { get; set; } = new RetainingWallToe();

        [Description("RetainingWallFloor object defining the heel of the base.")]
        public virtual RetainingWallHeel Heel { get; set; } = new RetainingWallHeel();

        [Description("The retained height of the wall. From Ground to top of wall.")] // Definition of this number. Where does it measure from. 
        public virtual double RetainedHeight { get; set; } = 0.0;

        [Description("The distance from top of base to surfacelevel. Shortest distance")]
        public virtual double CoverDepth { get; set; } = 0.0;

        [Description("")]
        public virtual double GroundWaterLevel { get; set; } = 0.0;

        [Description("Angle of retention between wall and ground. Measured at top of wall in degrees.")] //Does BHoM have convetion for using radians or degrees. Double check this 
        public virtual double RetentionAngle { get; set; } = 0.0;

        [Description("Rebar intent")] //This should possibly be divided out to the diff retaining wall sub-objects feeding in... 
        public virtual IRebarIntent RebarIntent { get; set; } = null;


        /***************************************************/
    }
}