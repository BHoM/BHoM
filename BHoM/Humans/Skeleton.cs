using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;

namespace BH.oM.HumanBody
{
    /// <summary>
    /// BHoM Human skeleton class
    /// </summary>
    public class Skeleton : BH.oM.Base.BHoMObject
    {
        /// <summary>
        /// Constructs an empty skeleton object
        /// </summary>
        public Skeleton()
        {
            this.TrackingPoints = new Dictionary<JointName, Point>();
            this.TrackingLines = new Dictionary<string, Line>();
        }

        /// <summary>Head</summary>
        public Head Head { get; private set; }
        /// <summary>Right hand</summary>
        public HandRight HandRight { get; private set; }
        /// <summary>Left hand</summary>
        public HandLeft HandLeft { get; private set; }
        /// <summary>Right thumb</summary>
        public ThumbRight ThumbRight { get; private set; }
        /// <summary>Left thumb</summary>
        public ThumbLeft ThumbLeft { get; private set; }
        /// <summary>Neck</summary>
        public Neck Neck { get; private set; }
        /// <summary>Right shoulder</summary>
        public ShoulderRight ShoulderRight { get; private set; }
        /// <summary>Left shoulder</summary>
        public ShoulderLeft ShoulderLeft { get; private set; }
        /// <summary>Spine</summary>
        public Spine Spine { get; private set; }
        /// <summary>Right hip</summary>
        public HipRight HipRight { get; private set; }
        /// <summary>Left hip</summary>
        public HipLeft HipLeft { get; private set; }
        /// <summary>Upper right arm</summary>
        public UpperArmRight UpperArmRight { get; private set; }
        /// <summary>Upper left arm</summary>
        public UpperArmLeft UpperArmLeft { get; private set; }
        /// <summary>Lower right arm</summary>
        public LowerArmRight LowerArmRight { get; private set; }
        /// <summary>Lower left arm</summary>
        public LowerArmLeft LowerArmLeft { get; private set; }
        /// <summary>Upper right leg</summary>
        public UpperLegRight UpperLegRight { get; private set; }
        /// <summary>Upper left leg</summary>
        public UpperLegLeft UpperLegLeft { get; private set; }
        /// <summary>Lower right leg</summary>
        public LowerLegRight LowerLegRight { get; private set; }
        /// <summary>Lower left leg</summary>
        public LowerLegLeft LowerLegLeft { get; private set; }
        /// <summary>Right foot</summary>
        public FootRight FootRight { get; private set; }
        /// <summary>Left foot</summary>
        public FootLeft FootLeft { get; private set; }

        /// <summary>Dictionary of points with joint names as keys</summary>
        public Dictionary<JointName, Point> TrackingPoints { get; set; }
        /// <summary>Dictionary of tracking lines with string keys</summary>
        public Dictionary<string, Line> TrackingLines { get; private set; }       

        /// <summary>
        /// Sets the body parts using tracking points. Try loops used for all actions 
        /// in case body part tracking points are not detected
        /// </summary>
        public void SetBodyPartsbyTrackingPoints()
        {   
            Dictionary<JointName, Point> TP = this.TrackingPoints;
            try { this.Head = new Head(TP[JointName.Head]);} catch{}
            try { this.HandRight = new HandRight(new Line(TP[JointName.WristRight], TP[JointName.HandRight]));} catch{}
            try { this.HandLeft = new HandLeft(new Line(TP[JointName.WristLeft], TP[JointName.HandLeft]));} catch{}
            try { this.ThumbRight = new ThumbRight(new Line(TP[JointName.HandRight], TP[JointName.ThumbRight]));} catch{}
            try { this.ThumbLeft = new ThumbLeft(new Line(TP[JointName.HandLeft], TP[JointName.ThumbLeft]));} catch{}
            try { this.Neck = new Neck(new Line(TP[JointName.Head], TP[JointName.SpineShoulder]));} catch{}
            try { this.ShoulderRight = new ShoulderRight(new Line(TP[JointName.SpineShoulder], TP[JointName.ShoulderRight]));} catch{}
            try { this.ShoulderLeft = new ShoulderLeft(new Line(TP[JointName.SpineShoulder], TP[JointName.ShoulderLeft]));} catch{}
            try { this.Spine = new Spine(new Line(TP[JointName.SpineShoulder], TP[JointName.SpineBase]));} catch{}
            try { this.HipRight = new HipRight(new Line(TP[JointName.SpineBase], TP[JointName.HipRight]));} catch{}
            try { this.HipLeft = new HipLeft(new Line(TP[JointName.SpineBase], TP[JointName.HipLeft]));} catch{}
            try { this.UpperArmRight = new UpperArmRight(new Line(TP[JointName.ShoulderRight], TP[JointName.ElbowRight]));} catch{}
            try { this.UpperArmLeft = new UpperArmLeft(new Line(TP[JointName.ShoulderLeft], TP[JointName.ElbowLeft]));} catch{}
            try { this.LowerArmRight = new LowerArmRight(new Line(TP[JointName.ElbowRight], TP[JointName.WristRight]));} catch{}
            try { this.LowerArmLeft = new LowerArmLeft(new Line(TP[JointName.ElbowLeft], TP[JointName.WristLeft]));} catch{}
            try { this.UpperLegRight = new UpperLegRight(new Line(TP[JointName.HipRight], TP[JointName.KneeRight]));} catch{}
            try { this.UpperLegLeft = new UpperLegLeft(new Line(TP[JointName.HipLeft], TP[JointName.KneeLeft]));} catch{}
            try { this.LowerLegRight = new LowerLegRight(new Line(TP[JointName.KneeRight], TP[JointName.AnkleRight]));} catch{}
            try { this.LowerLegLeft = new LowerLegLeft(new Line(TP[JointName.KneeLeft], TP[JointName.AnkleLeft]));} catch{}
            try { this.FootRight = new FootRight(new Line(TP[JointName.AnkleRight], TP[JointName.FootRight]));} catch{}
            try { this.FootLeft = new FootLeft(new Line(TP[JointName.AnkleLeft], TP[JointName.FootLeft]));} catch{}
        }

        /// <summary>
        /// Get all the tracking lines from the skeleton
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Line> GetAllTrackingLines()
        {
            this.TrackingLines.Add("Neck", this.Neck.TrackingLine);
            this.TrackingLines.Add("ShoulderRight", this.ShoulderRight.TrackingLine);
            this.TrackingLines.Add("ShoulderLeft", this.ShoulderLeft.TrackingLine);
            this.TrackingLines.Add("UppperArmRight", this.UpperArmRight.TrackingLine);
            this.TrackingLines.Add("UpperArmLeft", this.UpperArmLeft.TrackingLine);
            this.TrackingLines.Add("LowerArmRight", this.LowerArmRight.TrackingLine);
            this.TrackingLines.Add("LowerArmLeft", this.LowerArmLeft.TrackingLine);
            this.TrackingLines.Add("HandRight", this.HandRight.TrackingLine);
            this.TrackingLines.Add("HandLeft", this.HandLeft.TrackingLine);
            this.TrackingLines.Add("ThumbRight", this.ThumbRight.TrackingLine);
            this.TrackingLines.Add("ThumbLeft", this.ThumbLeft.TrackingLine);
            this.TrackingLines.Add("Spine", this.Spine.TrackingLine);
            this.TrackingLines.Add("HipRight", this.HipRight.TrackingLine);
            this.TrackingLines.Add("HipLeft", this.HipLeft.TrackingLine);
            this.TrackingLines.Add("UpperLegRight", this.UpperLegRight.TrackingLine);
            this.TrackingLines.Add("LowerLegRight", this.LowerLegRight.TrackingLine);
            this.TrackingLines.Add("UpperLegLeft", this.UpperLegLeft.TrackingLine);
            this.TrackingLines.Add("LowerLegLeft", this.LowerLegLeft.TrackingLine);
            this.TrackingLines.Add("FootRight", this.FootRight.TrackingLine);
            this.TrackingLines.Add("FootLeft", this.FootLeft.TrackingLine);
            return this.TrackingLines;
        }
    }

    /// <summary>
    /// Joint names
    /// </summary>
    public enum JointName
    {
        /// <summary>Head</summary>
        Head = 0,
        /// <summary>Upper spine</summary>
        SpineShoulder,
        /// <summary>Right shoulder</summary>  
        ShoulderRight,
        /// <summary>Left shoulder</summary>
        ShoulderLeft,
        /// <summary>Neck</summary>
        Neck,
        /// <summary>Right elbow</summary>
        ElbowRight,
        /// <summary>Left elbow</summary>
        ElbowLeft,
        /// <summary>Right hand</summary>
        HandRight,
        /// <summary>Left hand</summary>
        HandLeft,
        /// <summary>Tip of the right hand</summary>
        HandTipRight,
        /// <summary>Tip of the left hand</summary>
        HandTipLeft,
        /// <summary>Right thumb</summary>
        ThumbRight,
        /// <summary>Left thumb</summary>
        ThumbLeft,
        /// <summary>Right wrist</summary>
        WristRight,
        /// <summary>Left wrist</summary>
        WristLeft,
        /// <summary>Mid spine</summary>
        SpineMid,
        /// <summary>Spine base</summary>
        SpineBase,
        /// <summary>Right hip</summary>
        HipRight,
        /// <summary>Left hip</summary>
        HipLeft,
        /// <summary>Right knee</summary>
        KneeRight,
        /// <summary>Left knee</summary>
        KneeLeft,
        /// <summary>Right ankle</summary>
        AnkleRight,
        /// <summary>Left ankle</summary>
        AnkleLeft,
        /// <summary>Right foot</summary>
        FootRight,
        /// <summary>Left foot</summary>
        FootLeft
     }

    /// <summary>
    /// Hand state values
    /// </summary>
    public enum HandStateName
    {
        /// <summary>Close</summary>
        Closed = 0,
        /// <summary>Lasso</summary>
        Lasso,
        /// <summary>Not tracked</summary>
        NotTracked,
        /// <summary>Open</summary>
        Open,
        /// <summary>Not known</summary>
        Unknown
    }
}
