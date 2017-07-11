using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structural.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Gravity load
    /// </summary>   

    /// <summary>
    /// Point load along a bar
    /// </summary>
    public class BarPointLoad : Load<Bar> // TODO: one class per file
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DistanceFromA { get; set; }   //TODO: define default values

        public Geometry.Vector ForceVector { get; set; }

        public Geometry.Vector MomentVector { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarPointLoad() { }

        /***************************************************/



        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarPointLoad;
        }

        //Bar point load object - different to nodal or point load as it needs a 'position' variable
    }




    public class BarUniformlyDistributedLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Geometry.Vector ForceVector { get; set; }

        public Geometry.Vector MomentVector { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarUniformlyDistributedLoad() { }

        /***************************************************/

        public BarUniformlyDistributedLoad(Loadcase loadcase, double fx, double fy, double fz)
        {
            Loadcase = loadcase;
            ForceVector = new Geometry.Vector(fx, fy, fz);
            MomentVector = new Vector(0,0,0);
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarUniformLoad;
        }

    }



    /// <summary>
    /// bar temperature load class
    /// </summary>
    public class BarTemperatureLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Geometry.Vector TemperatureChange { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarTemperatureLoad() { }

        /***************************************************/

        public BarTemperatureLoad(Loadcase loadcase, double tx, double ty, double tz)
        {
            Loadcase = loadcase;
            TemperatureChange = new Geometry.Vector(tx, ty, tz);
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarTemperature;
        }
    }





    /// <summary>
    /// Varying load on a bar
    /// </summary>
    public class BarVaryingDistributedLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DistanceFromA { get; set; }

        public Geometry.Vector ForceVectorA { get; set; }

        public Geometry.Vector MomentVectorA { get; set; }

        public double DistanceFromB { get; set; }

        public Geometry.Vector ForceVectorB { get; set; }

        public Geometry.Vector MomentVectorB { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarVaryingDistributedLoad() { }

        /***************************************************/



        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarVaryingLoad;
        }

        //patch load for bars. Should include patch moments. 
    }



    /// <summary>
    /// Prestress load on a bar
    /// </summary>
    public class BarPrestressLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double PrestressValue { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarPrestressLoad() { }

        /***************************************************/



        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.Pressure;
        }

    }
}
