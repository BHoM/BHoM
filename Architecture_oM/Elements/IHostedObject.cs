using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Architecture.Properties;

//using BH.oM.Environment.Interface;

namespace BH.oM.Architecture.Elements
{
    //HostObject name taken from Revit but could be named IArchitecturalObject, IPhysicalObject, IPhysical
    interface IHostObject : IBHoMObject, IElement2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        //Profile is closed PolyCurve:
        //  1. Bottom surface for Roof
        //  2. Top surface for Floor
        //  3. Mid surface for Wall
        PolyCurve Profile { get; set; }
        HostedObjectProperties HostedObjectProperties { get; set; }

        //Move IBHoMExtendedProperties to Common_oM and implement ExtendedProperties
        //public List<IBHoMExtendedProperties> ExtendedProperties { get; set; };

        /***************************************************/

        /*
        Methods to implement in BHoM_Engine

        //Query
        
        public static double Thickness(this IHostObject iHostObject)
        {
            //Add checks
        
            return HostedObjectProperties.Thickness
        }
        
        public static Plane Plane(this IHostObject iHostObject)
        {
            //Get Plane from Profile
        }
        
        public static List<oM.Geometry.ICurve> Edges(this IHostObject iHostObject)
        {
            //Use Thickness and Plane methods to calculate Edges of IHostObject
        }

        public static double Area(this IHostObject iHostObject)
        {
            //Use Profile to calculate Area
        }

        public static double BottomElevation(this IHostObject iHostObject)
        {
            //Add checks
        
            return BH.Engine.Geometry.IControlPoints(iHostObject.Profile).ConvertAll(x => x.Z).Min();
        }

        public static double TopElevation(this IHostObject iHostObject)
        {
            //Add checks
        
            return BH.Engine.Geometry.IControlPoints(iHostObject.Profile).ConvertAll(x => x.Z).Max();
        }

        */

    }
}
