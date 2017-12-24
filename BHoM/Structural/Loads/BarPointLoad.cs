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
    [Serializable]
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
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarPointLoad;
        }

        //Bar point load object - different to nodal or point load as it needs a 'position' variable
    }
}
