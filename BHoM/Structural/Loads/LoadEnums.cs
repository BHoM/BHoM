namespace BH.oM.Structural.Loads
{
    public enum CaseType
    {
        Simple = 0,
        Mobile,
        Combination,
        Envelope
    }

    /***************************************************/

    public enum LoadNature
    {
        Dead = 0,
        SuperDead,
        Live,
        Wind,
        Seismic,
        Temperature,
        Snow,
        Accidental,
        Prestress,
        Other
    }

    /***************************************************/

    public enum LoadType
    {
        Selfweight = 0,
        PointForce,
        PointDisplacement,
        PointVelocity,
        PointAcceleration,
        PointMass,
        BarPointLoad,
        BarUniformLoad,
        BarVaryingLoad,
        BarTemperature,
        AreaUniformLoad,
        AreaVaryingLoad,
        AreaTemperature,
        Pressure,
        Geometrical
    }

    /***************************************************/

    public enum LoadAxis 
    {
        Global,
        Local,
    }
}
