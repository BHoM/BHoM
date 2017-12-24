using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
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
            MomentVector = new Vector(0, 0, 0);
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
