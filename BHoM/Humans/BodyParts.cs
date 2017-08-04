using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;

namespace BH.oM.HumanBody
{
    /// <summary>
    /// BHoM Human head object
    /// </summary>
    public class Head // Sort out this collection of classes (can we generalise them?)
    {
        /// <summary>Point at centre of head</summary>
        public Point TrackingPoint { get; private set; }
        
        /// <summary>
        /// Construct an empty head object
        /// </summary>
        public Head()
        {
        }

        /// <summary>
        /// Construct a head using a point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public Head(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }             

        /// <summary>
        /// Set the tracking point of a head using a point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        /// <summary>
        /// Set the tracking point of a head by coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }
    }

    /// <summary>
    /// BHoM Human right hand object
    /// </summary>
    public class HandRight
    {
        /// <summary>hand tracking centre point</summary>
        public Point TrackingPoint { get; private set; }
        /// <summary>hand tracking centre line</summary>
        public Line TrackingLine { get; private set; }
        /// <summary>Hand state (open/closed/tracked)</summary>
        public HandStateName State { get; private set; }        

        /// <summary>
        /// Constructs an empty right hand object
        /// </summary>
        public HandRight()
        {
        }

        /// <summary>
        /// Constructs a right hand using a point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public HandRight(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        /// <summary>
        /// Sets the tracking centre point of a right hand using a point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        /// <summary>
        /// Sets the tracking centre point of a right hand using coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }

        /// <summary>
        /// Constructs a left hand using a tracking centreline
        /// </summary>
        /// <param name="trackingLine"></param>
        public HandRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centreline using a line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        /// <summary>
        /// Sets the hand state
        /// </summary>
        /// <param name="handState"></param>
        public void SetState(HandStateName handState)
        {
            this.State = handState;
        }
    }
   
    /// <summary>
    /// BHoM Human left hand object
    /// </summary>
    public class HandLeft
    {
        /// <summary>Left hand tracking centre point</summary>
        public Point TrackingPoint { get; private set; }
        /// <summary>Left hand tracking cenre line</summary>
        public Line TrackingLine { get; private set; }
        /// <summary>Left hand state (open/closed/tracked)</summary>
        public HandStateName State { get; private set; }

        /// <summary>
        /// Constructs an empty left hand object
        /// </summary>
        public HandLeft()
        {
        }

        /// <summary>
        /// Constructs a left hand using a point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public HandLeft(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        /// <summary>
        /// Sets the left hand tracking centre point using a point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        /// <summary>
        /// Sets the left hand tracking centre point using coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }

        /// <summary>
        /// Constructs a left hand using a tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public HandLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line of a left hand using a line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        /// <summary>
        /// Sets the state of a left hand
        /// </summary>
        /// <param name="handState"></param>
        public void SetState(HandStateName handState)
        {
            this.State = handState;
        }
    }

    /// <summary>
    /// BHoM Human right thumb object
    /// </summary>
    public class ThumbRight
    {
        /// <summary>Right thumb tracking centre point</summary>
        public Point TrackingPoint { get; private set; }
        /// <summary>Right thumb tracking centre line</summary>
        public Line TrackingLine { get; private set; }

        /// <summary>
        /// Constructs an empty right thumb object
        /// </summary>
        public ThumbRight()
        {
        }

        /// <summary>
        /// Constructs a right thumb using tracking point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public ThumbRight(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        /// <summary>
        /// Sets the tracking point of a right thumb
        /// </summary>
        /// <param name="trackingPoint"></param>
        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        /// <summary>
        /// Constructs a right thumb using the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public ThumbRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking line of a right thumb
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        /// <summary>
        /// Sets the tracking point of a right thumb using coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }
    }

    /// <summary>
    /// BHoM Human left thumb object
    /// </summary>
    public class ThumbLeft
    {
        /// <summary>Lefth thumb tracking point</summary>
        public Point TrackingPoint { get; private set; }
        /// <summary>Left thumb tracking centre line</summary>
        public Line TrackingLine { get; private set; }

        /// <summary>
        /// Constructs an empty left thumb object
        /// </summary>
        public ThumbLeft()
        {
        }

        /// <summary>
        /// Constructs a left thumb by tracking point
        /// </summary>
        /// <param name="trackingPoint"></param>
        public ThumbLeft(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        /// <summary>
        /// Sets the tracking point of a left thumb
        /// </summary>
        /// <param name="trackingPoint"></param>
        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        /// <summary>
        /// Constructs a left thumb using a tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public ThumbLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line of a left thumb
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        /// <summary>
        /// Sets the left thumb tracking point using coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }
    }

    /// <summary>
    /// BHoM Human neck object
    /// </summary>
    public class Neck
    {
        /// <summary>
        /// The tracking centre line of a neck
        /// </summary>
        public Line TrackingLine {get;private set;}

        /// <summary>
        /// Constructs an empty neck object
        /// </summary>
        public Neck()
        {
        }

        /// <summary>
        /// Constructs a neck using a tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public Neck(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
        
        /// <summary>
        /// Sets the tracking centre line of a neck
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human right shoulder object
    /// </summary>
    public class ShoulderRight
    {
        /// <summary>
        /// Tracking centre line of the shoulder
        /// </summary>
        public Line TrackingLine {get;private set;}

        /// <summary>
        /// Constructs an empty right shoulder
        /// </summary>
        public ShoulderRight()
        {
        }

        /// <summary>
        /// Constructs a right should using a tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public ShoulderRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line of the shoulder
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human left shoulder object
    /// </summary>
    public class ShoulderLeft
    {
        /// <summary>
        /// Tracking centre line of the left shoulder
        /// </summary>
        public Line TrackingLine { get; private set; }

        /// <summary>
        /// Constructs an empty left shoulder object
        /// </summary>
        public ShoulderLeft()
        {
        }

        /// <summary>
        /// Constructs a left shoulder using a tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public ShoulderLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line of a left shoulder
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human upper right arm
    /// </summary>
    public class UpperArmRight
    {
        /// <summary>
        /// Tracking centre line of the upper arm
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs and empty upper right arm
        /// </summary>
        public UpperArmRight()
        {
        }

        /// <summary>
        /// Constructs an upper right arm by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public UpperArmRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line of the upper right arm
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human left arm object
    /// </summary>
    public class UpperArmLeft
    {
        /// <summary>
        /// Tracking centre line of the upper left arm
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty upper left arm object
        /// </summary>
        public UpperArmLeft()
        {
        }

        /// <summary>
        /// Constructs an upper left arm by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public UpperArmLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line of the upper left arm
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human lower right arm object
    /// </summary>
    public class LowerArmRight
    {
        /// <summary>
        /// Tracking centre line of the lower right arm
        /// </summary>
        public Line TrackingLine { get; private set; }

        /// <summary>
        /// Constructs an empty lower right arm
        /// </summary>
        public LowerArmRight()
        {
        }

        /// <summary>
        /// Constructs a lower righ arm by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public LowerArmRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human lower left arm
    /// </summary>
    public class LowerArmLeft
    {
        /// <summary>
        /// Tracking centre line of the lower left arm
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty lower left arm 
        /// </summary>
        public LowerArmLeft()
        {
        }

        /// <summary>
        /// Constructs a lower left arm by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public LowerArmLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human spine object
    /// </summary>
    public class Spine
    {
        /// <summary>
        /// Tracking centre line of the spine
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty spine
        /// </summary>
        public Spine()
        {
        }

        /// <summary>
        /// Constructs a spine by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public Spine(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human right hip object
    /// </summary>
    public class HipRight
    {
        /// <summary>
        /// Tracking centre line
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty right hip
        /// </summary>
        public HipRight()
        {
        }

        /// <summary>
        /// Constructs a right hip by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public HipRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human left hip object
    /// </summary>
    public class HipLeft
    {
        /// <summary>
        /// Tracking centre line of left hip
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty left hip
        /// </summary>
        public HipLeft()
        {
        }

        /// <summary>
        /// Constructs a left hip by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public HipLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM upper right leg object
    /// </summary>
    public class UpperLegRight
    {
        /// <summary>
        /// Tracking centre line of upper right leg
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty upper right leg
        /// </summary>
        public UpperLegRight()
        {
        }

        /// <summary>
        /// Constructs an upper right leg by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public UpperLegRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human upper left leg
    /// </summary>
    public class UpperLegLeft
    {
        /// <summary>
        /// Tracking centre line of upper left leg
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty upper left leg
        /// </summary>
        public UpperLegLeft()
        {
        }

        /// <summary>
        /// Constructs an upper left leg by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public UpperLegLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human lower right leg
    /// </summary>
    public class LowerLegRight
    {
        /// <summary>
        /// Tracking centre line of lower right leg
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty lower right leg
        /// </summary>
        public LowerLegRight()
        {
        }

        /// <summary>
        /// Constructs a lower right leg by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public LowerLegRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human lower left leg object
    /// </summary>
    public class LowerLegLeft
    {
        /// <summary>
        /// Tracking centre line of the lower left leg
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty lower left leg
        /// </summary>
        public LowerLegLeft()
        {
        }

        /// <summary>
        /// Constructs a lower left leg by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public LowerLegLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human right foot object
    /// </summary>
    public class FootRight
    {
        /// <summary>
        /// Tracking centre line of right foot
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty right foot
        /// </summary>
        public FootRight()
        {
        }

        /// <summary>
        /// Constructs a right foot by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public FootRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    /// <summary>
    /// BHoM Human left foot object
    /// </summary>
    public class FootLeft
    {
        /// <summary>
        /// Tracking centre line of left foot
        /// </summary>
        public Line TrackingLine { get; private set; }
        
        /// <summary>
        /// Constructs an empty left foot object
        /// </summary>
        public FootLeft()
        {
        }

        /// <summary>
        /// Constructs a left foot by tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public FootLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        /// <summary>
        /// Sets the tracking centre line
        /// </summary>
        /// <param name="trackingLine"></param>
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }
}
