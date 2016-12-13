using BHoM.Base;
using BHoM.Structural.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Gravity load
    /// </summary>   

    /// <summary>
    /// Point load along a bar
    /// </summary>
    public class BarPointLoad : Load<Bar>
    {
        public double DistanceFromA { get; set; }
        public Geometry.Vector ForceVector { get; set; }
        public Geometry.Vector MomentVector { get; set; }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.BarPointLoad;
            }
        }


        public BarPointLoad() { }
        //Bar point load object - different to nodal or point load as it needs a 'position' variable
    }

    public class BarUniformlyDistributedLoad : Load<Bar>
    {
        public Geometry.Vector ForceVector { get; set; }
        public Geometry.Vector MomentVector { get; set; }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.BarUniformLoad;
            }
        }

        public BarUniformlyDistributedLoad() { }

        public BarUniformlyDistributedLoad(Loadcase loadcase, double fx, double fy, double fz)
        {
            Loadcase = loadcase;
            ForceVector = new Geometry.Vector(fx, fy, fz);
            MomentVector = Geometry.Vector.Zero;
        }
    }

    /// <summary>
    /// bar temperature load class
    /// </summary>
    public class BarTemperatureLoad : Load<Bar>
    {
        public Geometry.Vector TemperatureChange { get; set; }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.BarTemperature;
            }
        }

        public BarTemperatureLoad() { }
        //Bar temp load object. Expansion in XYZ
        public BarTemperatureLoad(Loadcase loadcase, double tx, double ty, double tz)
        {
            Loadcase = loadcase;
            TemperatureChange = new Geometry.Vector(tx, ty, tz);
        }
    }

    /// <summary>
    /// Varying load on a bar
    /// </summary>
    public class BarVaryingDistributedLoad : Load<Bar>
    {
        public double DistanceFromA { get; set; }
        public Geometry.Vector ForceVectorA { get; set; }
        public Geometry.Vector MomentVectorA { get; set; }
        public double DistanceFromB { get; set; }
        public Geometry.Vector ForceVectorB { get; set; }
        public Geometry.Vector MomentVectorB { get; set; }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.BarVaryingLoad;
            }
        }

        public BarVaryingDistributedLoad() { }
        //patch load for bars. Should include patch moments. 
    }

    /// <summary>
    /// Prestress load on a bar
    /// </summary>
    public class BarPrestressLoad : Load<Bar>
    {
        public double PrestressValue { get; set; }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.Pressure;
            }
        }

    }
}
