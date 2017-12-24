﻿using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structural.Loads
{
    public class GravityLoad : Load<BHoMObject>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector GravityDirection { get; set; } = new Vector(0, 0, -1);


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
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.Selfweight;
        }
    }
}
