using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHB = BH.oM.Base;
using BHG = BH.oM.Geometry;

namespace BH.oM.Structural.Loads
{
    public class GravityLoad : Load<BHB.BHoMObject>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public BHG.Vector GravityDirection { get; set; } = new BHG.Vector(0, 0, -1);


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GravityLoad() { }

        /***************************************************/

        public GravityLoad(Loadcase loadcase, double Gx, double gy, double gz)
        {
            GravityDirection = new Geometry.Vector(Gx, gy, gz);
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.Selfweight;
        }
    }
}
