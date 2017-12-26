using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    [Serializable]
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
            ForceVector = new Geometry.Vector { X = fx, Y = fy, Z = fz };
            MomentVector = new Vector { X = 0, Y = 0, Z = 0 };
        }


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarUniformLoad;
        }

    }
}
