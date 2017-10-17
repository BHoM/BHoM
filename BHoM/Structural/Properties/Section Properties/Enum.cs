using BH.oM.Geometry;
using System;

namespace BH.oM.Structural.Properties
{
    public enum ShapeType
    {
        Rectangle = 0,
        Box = 1,
        Angle = 2,
        ISection = 3,
        Tee = 4,
        Channel = 5,
        Tube = 6,
        Circle = 7,
        Zed = 8,
        Polygon = 9,

        DoubleAngle = 22,
        DoubleISection = 23,
        DoubleChannel = 25,

        //Maybe should move elsewhere
        Cable = 30,
    }
    
}
