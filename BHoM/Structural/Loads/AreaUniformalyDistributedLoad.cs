using System;
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
            Pressure = new Geometry.Vector { X = px, Y = py, Z = pz };
        }


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.AreaUniformLoad;
        }


        //Perhaps we can have one area load object for all 'area' type objects - panels, walls, floors, finite elements
    }
}
