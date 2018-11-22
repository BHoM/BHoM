using BH.oM.Base;
using BH.oM.Humans.BodyParts;

namespace BH.oM.Humans
{    public class Skeleton : BHoMObject, IHumanRole
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Head Head { get; set; } = new Head();

        public RightHand RightHand { get; set; } = new RightHand();

        public LeftHand LeftHand { get; set; } = new LeftHand();

        public RightThumb RightThumb { get; set; } = new RightThumb();

        public LeftThumb LeftThumb { get; set; } = new LeftThumb();

        public Neck Neck { get; set; } = new Neck();

        public RightShoulder RightShoulder { get; set; } = new RightShoulder();

        public LeftShoulder LeftShoulder { get; set; } = new LeftShoulder();

        public Spine Spine { get; set; } = new Spine();

        public RightHip RightHip { get; set; } = new RightHip();

        public LeftHip LeftHip { get; set; } = new LeftHip();

        public RightUpperArm RightUpperArm { get; set; } = new RightUpperArm();

        public LeftUpperArm LeftUpperArm { get; set; } = new LeftUpperArm();

        public RightLowerArm RightLowerArm { get; set; } = new RightLowerArm();

        public LeftLowerArm LeftLowerArm { get; set; } = new LeftLowerArm();

        public RightUpperLeg RightUpperLeg { get; set; } = new RightUpperLeg();

        public LeftUpperLeg LeftUpperLeg { get; set; } = new LeftUpperLeg();

        public RightLowerLeg RightLowerLeg { get; set; } = new RightLowerLeg();

        public LeftLowerLeg LeftLowerLeg { get; set; } = new LeftLowerLeg();

        public RightFoot RightFoot { get; set; } = new RightFoot();

        public LeftFoot LeftFoot { get; set; } = new LeftFoot();


        /***************************************************/
    }

}
