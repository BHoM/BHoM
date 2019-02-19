using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Common.Materials;

namespace BH.oM.Architecture.Elements
{
    public class CompoundLayer
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Material Material { get; set; } = new Material();
        public double Thickness { get; set; } = double.NaN;

        /***************************************************/

        /*
        Methods to implement in BHoM_Engine

        //Create
        
        public static CompoundLayer CompoundLayer(Material material, double thickness)
        {
            //Add checks
        
            return new CompoundLayer() 
            {
                Material = material,
                Thickness = thickness 
            };
        }
        
        */
    }
}
