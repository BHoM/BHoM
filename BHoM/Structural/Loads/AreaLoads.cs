using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Uniformly distributed area load
    /// </summary>
    [Serializable]
    public class AreaUniformalyDistributedLoad : Load<IAreaElement>  //TODO: one class per file
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public BH.oM.Geometry.Vector Pressure { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AreaUniformalyDistributedLoad() { }

        /***************************************************/

        public AreaUniformalyDistributedLoad(Loadcase loadcase, double px, double py, double pz)
        {
            Pressure = new Geometry.Vector(px, py, pz);
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.AreaUniformLoad;
        }

        
        //Perhaps we can have one area load object for all 'area' type objects - panels, walls, floors, finite elements
    }




    /// <summary>
    /// Varying load distributed over an area
    /// </summary>
    public class AreaVaryingDistributedLoad
    {

        //Varying loads on area based objects
    }




    /// <summary>
    /// bar temperature load class
    /// </summary>
    public class AreaTemperatureLoad : Load<IAreaElement>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double TemperatureChange { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AreaTemperatureLoad() { }

        /***************************************************/

        public AreaTemperatureLoad(Loadcase loadcase, double t)
        {
            Loadcase = loadcase;
            TemperatureChange = t;
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
}
