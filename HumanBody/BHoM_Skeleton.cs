using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;

namespace BHoM.HumanBody
{
    public class Skeleton
    {
        public Skeleton()
        {
            this.TrackingPoints = new Dictionary<JointName, Point>();
            this.TrackingLines = new Dictionary<string, Line>();
        }

        public Head Head { get; private set; }
        public HandRight HandRight { get; private set; }
        public HandLeft HandLeft { get; private set; }
        public ThumbRight ThumbRight { get; private set; }
        public ThumbLeft ThumbLeft { get; private set; }
        public Neck Neck { get; private set; }
        public ShoulderRight ShoulderRight { get; private set; }
        public ShoulderLeft ShoulderLeft { get; private set; }
        public Spine Spine { get; private set; }
        public HipRight HipRight { get; private set; }
        public HipLeft HipLeft { get; private set; }
        public UpperArmRight UpperArmRight { get; private set; }
        public UpperArmLeft UpperArmLeft { get; private set; }
        public LowerArmRight LowerArmRight { get; private set; }
        public LowerArmLeft LowerArmLeft { get; private set; }
        public UpperLegRight UpperLegRight { get; private set; }
        public UpperLegLeft UpperLegLeft { get; private set; }
        public LowerLegRight LowerLegRight { get; private set; }
        public LowerLegLeft LowerLegLeft { get; private set; }
        public FootRight FootRight { get; private set; }
        public FootLeft FootLeft { get; private set; }

        public Dictionary<JointName, Point> TrackingPoints { get; set; }
        public Dictionary<string, Line> TrackingLines { get; private set; }       

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


        

    public enum JointName
    {
        Head = 0,
        SpineShoulder,     
        ShoulderRight,
        ShoulderLeft,
        Neck,
        ElbowRight,
        ElbowLeft,
        HandRight,
        HandLeft,
        HandTipRight,
        HandTipLeft,
        ThumbRight,
        ThumbLeft,
        WristRight,
        WristLeft,
        SpineMid,
        SpineBase,
        HipRight,
        HipLeft,
        KneeRight,
        KneeLeft,
        AnkleRight,
        AnkleLeft,
        FootRight,
        FootLeft
     }

    public enum HandStateName
    {
        Closed = 0,
        Lasso,
        NotTracked,
        Open,
        Unknown
    }
}
