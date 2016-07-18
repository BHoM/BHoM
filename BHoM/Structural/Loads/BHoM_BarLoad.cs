﻿using BHoM.Global;
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
    public class BarGravityLoad : Load<Bar>
    {
       // internal BarGravityLoad() { }
    }

    /// <summary>
    /// Point load along a bar
    /// </summary>
    public class BarPointLoad : Load<Bar>
    {
        public double DistanceFromA { get; set; }
        public Geometry.Vector ForceVector { get; set; }
        public Geometry.Vector MomentVector { get; set; }

        public BarPointLoad() { }
        //Bar point load object - different to nodal or point load as it needs a 'position' variable
    }

    /// <summary>
    /// Uniform load on bar
    /// </summary>
    public class BarUniformlyDistributedLoad : Load<Bar>
    {
        public Geometry.Vector ForceVector { get; set; }
        public BarUniformlyDistributedLoad() { }
    }

    /// <summary>
    /// bar temperature load class
    /// </summary>
    public class BarTemperatureLoad : Load<Bar>
    {
        public double TemperatureChange { get; set; }
        public BarTemperatureLoad() { }
        //Bar temp load object. Expansion in XYZ
    }

    /// <summary>
    /// Varying load on a bar
    /// </summary>
    public class BarVaryingDistributedLoad : Load<Bar>
    {
        public double DistanceFromA { get; set; }
        public Geometry.Vector ForceVectorA { get; set; }
        public double DistanceFromB { get; set; }
        public Geometry.Vector ForceVectorB { get; set; }
        public BarVaryingDistributedLoad() { }
        //patch load for bars. Should include patch moments. 
    }

    /// <summary>
    /// Prestress load on a bar
    /// </summary>
    public class BarPrestressLoad : Load<Bar>
    {
        public double PrestressValue { get; set; }
        //public BarPrestressLoad() { }
    }
}
