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
        private List<PolyLoop> pPolyLoops;

        public List<PolyLoop> PolyLoops
        {
            get
            {
                return pPolyLoops;
            }

       }
    }

    public class SpatialBoundary : Geometry
    {
        private Element pElement;
        private List<PolyLoop> pPolyLoops;

        public Element Element
        {
            get
            {
                return pElement;
            }
        }

        public List<PolyLoop> PolyLoops
        {
            get
            {
                return pPolyLoops;
            }

        }
    }
}
