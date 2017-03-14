using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;

namespace BHoM.MEP
{
    public abstract class Geometry
    {

    }

    //Added to 
    public class PolyLoop
    { }


    public class ClosedShell : Geometry
    {
        // private List<PolyLoop> pPolyLoops;    //Never assigned to

        /*public List<PolyLoop> PolyLoops
        {
            get
            {
                return pPolyLoops;
            }

       }*/
    }

    public class SpatialBoundary : Geometry
    {
        //private Element pElement;   //Never assigned to
        // private List<PolyLoop> pPolyLoops;   //Never used

        /*public Element Element
        {
            get
            {
                return pElement;
            }
        }*/

        /*public List<PolyLoop> PolyLoops
        {
            get
            {
                return pPolyLoops;
            }

        }*/
    }
}
