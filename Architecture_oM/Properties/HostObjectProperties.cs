using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Architecture.Elements;

namespace BH.oM.Architecture.Properties
{
    //HostedObject prefix taken from Revit but could be named IArchitecturalObjectProperties, IPhysicalObjectProperties, IPhysicalProperties
    public class HostObjectProperties : BHoMObject
    {
        public List<CompoundLayer> CompoundLayers { get; set; } = new List<CompoundLayer>();

        /*
        Methods to implement in BHoM_Engine
        
        //Query
        
        public static double Thickness(this HostedObjectProperties hostedObjectProperties)
        {
            if(hostedObjectProperties == null || hostedObjectProperties.CompoundLayers == null)
                return double.NaN
                
            double aResult = 0;
             hostedObjectProperties.CompoundLayers.ForEach(x => aResult += x.Thickness)

            return aResult;
        }

        //Modify

        public static HostedObjectProperties AddCompoundLayer(this HostedObjectProperties hostedObjectProperties, Material material, double thickness)
        {
            hostedObjectProperties.CompoundLayers.Add(Create.CompoundLayer(material, thickness));
        }

        */
    }
}
