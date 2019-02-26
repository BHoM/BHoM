using System.Collections.Generic;

using BH.oM.Base;

namespace BH.oM.Common.Properties
{
    public class Object2DProperties : BHoMObject
    {
        public List<CompoundLayer> CompoundLayers { get; set; } = new List<CompoundLayer>();

        /*
        Methods to implement in BHoM_Engine
        
        //Query
        
        public static double Thickness(this Object2DProperties object2DProperties)
        {
            if(object2DProperties == null || object2DProperties.CompoundLayers == null)
                return double.NaN
                
            double aResult = 0;
             object2DProperties.CompoundLayers.ForEach(x => aResult += x.Thickness)

            return aResult;
        }

        //Modify

        public static Object2DProperties AddCompoundLayer(this Object2DProperties object2DProperties, Material material, double thickness)
        {
            object2DProperties.CompoundLayers.Add(Create.CompoundLayer(material, thickness));
        }

        */
    }
}
