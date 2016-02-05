using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;

namespace BHoM.HumanBody
{
    public class Head
    {
        public Point TrackingPoint { get; private set; }
        
        public Head()
        {
        }

        public Head(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }             

        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }
    }

    public class HandRight
    {
        public Point TrackingPoint { get; private set; }
        public Line TrackingLine { get; private set; }
        public HandStateName State { get; private set; }        

        public HandRight()
        {
        }

        public HandRight(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }

        public HandRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        public void SetState(HandStateName handState)
        {
            this.State = handState;
        }
    }
   
    public class HandLeft
    {
        public Point TrackingPoint { get; private set; }
        public Line TrackingLine { get; private set; }
        public HandStateName State { get; private set; }

        public HandLeft()
        {
        }

        public HandLeft(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }

        public HandLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        public void SetState(HandStateName handState)
        {
            this.State = handState;
        }
    }

    public class ThumbRight
    {
        public Point TrackingPoint { get; private set; }
        public Line TrackingLine { get; private set; }

        public ThumbRight()
        {
        }

        public ThumbRight(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        public ThumbRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }
    }

    public class ThumbLeft
    {
        public Point TrackingPoint { get; private set; }
        public Line TrackingLine { get; private set; }

        public ThumbLeft()
        {
        }

        public ThumbLeft(Point trackingPoint)
        {
            this.SetTrackingPoint(trackingPoint.X, trackingPoint.Y, trackingPoint.Z);
        }

        public void SetTrackingPoint(Point trackingPoint)
        {
            this.TrackingPoint = trackingPoint;
        }

        public ThumbLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        public void SetTrackingPoint(double x, double y, double z)
        {
            this.TrackingPoint = new Point(x, y, z);
        }
    }

    public class Neck
    {
        public Neck()
        {
        }

        public Neck(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }

        public Line TrackingLine {get;private set;}
        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class ShoulderRight
    {
        public Line TrackingLine {get;private set;}

        public ShoulderRight()
        {
        }

        public ShoulderRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class ShoulderLeft
    {
        public Line TrackingLine { get; private set; }

        public ShoulderLeft()
        {
        }

        public ShoulderLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class UpperArmRight
    {
        public Line TrackingLine { get; private set; }
        
        public UpperArmRight()
        {
        }

        public UpperArmRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class UpperArmLeft
    {
        public Line TrackingLine { get; private set; }
        
        public UpperArmLeft()
        {
        }

        public UpperArmLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class LowerArmRight
    {
        public Line TrackingLine { get; private set; }

        public LowerArmRight()
        {
        }

        public LowerArmRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class LowerArmLeft
    {
        public Line TrackingLine { get; private set; }
        
        public LowerArmLeft()
        {
        }

        public LowerArmLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class Spine
    {
        public Line TrackingLine { get; private set; }
        
        public Spine()
        {
        }

        public Spine(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class HipRight
    {
        public Line TrackingLine { get; private set; }
        
        public HipRight()
        {
        }

        public HipRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class HipLeft
    {
        public Line TrackingLine { get; private set; }
        
        public HipLeft()
        {
        }

        public HipLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class UpperLegRight
    {
        public Line TrackingLine { get; private set; }
        
        public UpperLegRight()
        {
        }

        public UpperLegRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class UpperLegLeft
    {
        public Line TrackingLine { get; private set; }
        
        public UpperLegLeft()
        {
        }

        public UpperLegLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class LowerLegRight
    {
        public Line TrackingLine { get; private set; }
        
        public LowerLegRight()
        {
        }

        public LowerLegRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class LowerLegLeft
    {
        public Line TrackingLine { get; private set; }
        
        public LowerLegLeft()
        {
        }

        public LowerLegLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class FootRight
    {
        public Line TrackingLine { get; private set; }
        
        public FootRight()
        {
        }

        public FootRight(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

    public class FootLeft
    {
        public Line TrackingLine { get; private set; }
        
        public FootLeft()
        {
        }

        public FootLeft(Line trackingLine)
        {
            SetTrackingLine(trackingLine);
        }

        public void SetTrackingLine(Line trackingLine)
        {
            this.TrackingLine = trackingLine;
        }
    }

 
    
}
