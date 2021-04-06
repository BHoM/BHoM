using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Humans.ViewQuality
{
    [Description("Parameters defining the Field Of Vision used in Avalue analysis. For the default values see:  Nixdorf, S. Physiology of viewing. In Stadium Atlas:" +
        "Technical Recommendations for Grandstands in Modern Stadia, edited by Stephen Nixdorf, Wiley, London, UK. 2008, 130 - 139.")]
    public class EffectiveBinocularFieldOfVision : BHoMObject
    {
        [Description("Angle defining the vertical upper limit of the Field Of Vision. Measured from line of sight when the eye is at rest and typically limited by the brow ridge, or supraorbital ridge. Default value is 25 degrees approximately 0.44 radians.")]
        public virtual double EyeUpwardsAngle { get; set; } = 0.436332;

        [Description("Angle defining the horizontal limits of the Field Of Vision. Measured from line of sight when the eye is at rest to the left and right. Default value is 30 degrees approximately 0.52 radians.")]
        public virtual double EyeLeftRightAngle { get; set; } = 0.523599;

        [Description("Angle defining the vertical lower limit of the Field Of Vision. Measured from line of sight when the eye is at rest and typically limited by the cheek bones. Default value is 40 degrees approximately 0.7 radians.")]
        public virtual double EyeDownwardsAngle { get; set; } = 0.698132;

        [Description("Angle defining the permitted sweep angle of the head. If greater than zero a dynamic Field Of Vision is defined. Measured from line of sight when the eye is at rest to the left and right. Default value is 0 radians. 30 degrees (0.52 radians) is considered a comfortable sweep angle")]
        public virtual double HeadSweepLeftRightAngle { get; set; } = 0;
    }
}
