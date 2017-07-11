using System;
using BH.oM.Geometry;

namespace BH.oM.Structural.Results
{
    /// <summary>
    /// Nodal Result object contains a set of coexisting forces, node reference
    /// and orientation information
    /// </summary>
    /// 
    //public class NodalResult : Result
    //{
    //    public NodalResult()
    //    {
    //        Data = new object[11];
    //    }

    //    public NodalResult(object[] data) { Data = data; }

    //    public NodalResult(int number, int loadcase, int timeStep, Vector translation, Vector rotation, Vector acceleration, Vector angularAcceleration, Vector velocity, Vector angularVelocity, Vector force, Vector moment) : this()
    //    {
    //        Name = number;
    //        TimeStep = timeStep;
    //        Loadcase = loadcase;
    //        Id = Name + ":" + loadcase + ":" + TimeStep;
    //        Translation = translation;
    //        Rotation = rotation;
    //        Acceleration = acceleration;
    //        AngularAcceleration = angularAcceleration;
    //        Velocity = velocity;
    //        AngularVelocity = angularVelocity;
    //        Force = force;
    //        Moment = moment;

    //    }

    //    public override string[] ColumnHeaders
    //    {
    //        get
    //        {
    //            return new string[] { "Id", "Name", "Loadcase", "TimeStep", "Translation", "Rotation", "Acceleration", "AngularAcceleration", "Velocity", "AngularVelocity", "Force", "Moment" };
    //        }
    //    }

    //    public Vector Translation
    //    {
    //        get
    //        {
    //            return (Vector)Data[4];
    //        }
    //        set
    //        {
    //            Data[4] = value;
    //        }
    //    }

    //    public Vector Rotation
    //    {
    //        get
    //        {
    //            return (Vector)Data[5];
    //        }
    //        set
    //        {
    //            Data[5] = value;
    //        }
    //    }

    //    public Vector Acceleration
    //    {
    //        get
    //        {
    //            return (Vector)Data[6];
    //        }
    //        set
    //        {
    //            Data[6] = value;
    //        }
    //    }

    //    public Vector AngularAcceleration
    //    {
    //        get
    //        {
    //            return (Vector)Data[7];
    //        }
    //        set
    //        {
    //            Data[7] = value;
    //        }
    //    }

    //    public Vector Velocity
    //    {
    //        get
    //        {
    //            return (Vector)Data[8];
    //        }
    //        set
    //        {
    //            Data[8] = value;
    //        }
    //    }

    //    public Vector AngularVelocity
    //    {
    //        get
    //        {
    //            return (Vector)Data[9];
    //        }
    //        set
    //        {
    //            Data[9] = value;
    //        }
    //    }

    //    public Vector Force
    //    {
    //        get
    //        {
    //            return (Vector)Data[10];
    //        }
    //        set
    //        {
    //            Data[10] = value;
    //        }
    //    }

    //    public Vector Moment
    //    {
    //        get
    //        {
    //            return (Vector)Data[11];
    //        }
    //        set
    //        {
    //            Data[11] = value;
    //        }
    //    }

    //    public override ResultType ResultType
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
}
    


    //public class NodalResult
    //{
    //    /// <summary>Associated bar number</summary>
    //    public int NodeNumber { get; set; }

    //    /// <summary>Loadcase</summary>
    //    public BH.oM.Structural.Loads.Loadcase Loadcase { get; set; }

    //    /// <summary>Associated loadcase number</summary>
    //    public int LoadcaseNumber { get; internal set; }

    //    /// <summary>Associated loadcase name</summary>
    //    public string LoadcaseName { get; internal set; }

    //    /// <summary>Translation vector</summary>
    //    public BH.oM.Geometry.Vector Translation { get; set; }

    //    /// <summary>Rotation vector</summary>
    //    public BH.oM.Geometry.Vector Rotation { get; set; }

    //    /// <summary>Acceleration vector</summary>
    //    public BH.oM.Geometry.Vector Acceleration { get; set; }

    //    /// <summary>Angular acceleration vector</summary>
    //    public BH.oM.Geometry.Vector AngularAcceleration { get; set; }

    //    /// <summary>Velocity vector</summary>
    //    public BH.oM.Geometry.Vector Velocity { get; set; }

    //    /// <summary>Angular velocity vector</summary>
    //    public BH.oM.Geometry.Vector AngularVelocity { get; set; }

    //    /// <summary>Force vector</summary>
    //    public BH.oM.Geometry.Vector Force { get; set; }

    //    /// <summary>Moment vector</summary>
    //    public BH.oM.Geometry.Vector Moment { get; set; }

    //    /// <summary>Orientation of node results</summary>
    //    public BH.oM.Geometry.Plane OrientationPlane { get; set; }

    //    /// <summary>User text field for any user data</summary>
    //    public string UserData { get; set; }

    //    //////////////////////
    //    //// CONSTRUCTORS ////
    //    //////////////////////

    //    /// <summary>Construct a nodal result</summary>
    //    public NodalResult(int nodeNumber)
    //    {
    //        this.NodeNumber = nodeNumber;
    //    }

    //    /// <summary>Construct a nodal result with orientation plane</summary>
    //    public NodalResult(int nodeNumber, BH.oM.Geometry.Plane orientationPlane)
    //    {
    //        this.NodeNumber = nodeNumber;
    //        this.OrientationPlane = orientationPlane;
    //    }
    //}
