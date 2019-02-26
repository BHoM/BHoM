using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Common.Properties;

//using BH.oM.Environment.Interface;

namespace BH.oM.Common.Interface
{
    public interface IObject2D : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        //  1. Bottom surface for Roof
        //  2. Top surface for Floor
        //  3. Mid surface for Wall
        ISurface Surface { get; set; }
        Object2DProperties Properties { get; set; }

        //Move IBHoMExtendedProperties to Common_oM and implement ExtendedProperties
        //public List<IBHoMExtendedProperties> ExtendedProperties { get; set; };

        /***************************************************/

        /*
        Methods to implement in BHoM_Engine

        //Query
        
        public static double Thickness(this IObject2D object2D)
        {
            //Add checks
        
            return object2D.Properties.Thickness
        }
        
        public static List<oM.Geometry.ICurve> Edges(this IObject2D object2D)
        {
            //Use Thickness and Plane methods to calculate Edges of IObject2D
        }

        public static double Area(this IObject2D object2D)
        {
            //Use Surface to calculate Area
        }

        public static double BottomElevation(this IObject2D object2D)
        {
            //Get Bottom Elevation from ISurface
            
        }

        public static double TopElevation(this IObject2D object2D)
        {
           //Get Bottom Elevation from ISurface
        }

        */

    }
}
