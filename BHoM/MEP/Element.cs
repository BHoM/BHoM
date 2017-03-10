using BHoM.Base;
using BHoM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.MEP
{
    public abstract class Element : BHoMObject
    {
        private Location pLocation;
        private Geometry pGeometry;

        public Location Location
        {
            get
            {
                return pLocation;
            }
            set
            {
                pLocation = value;
            }
        }

        public Element(Location Location, Geometry Geometry)
        {
            Initialize();
            pLocation = Location;
            pGeometry = Geometry;
        }

        private void Initialize()
        {
            //SetBHoMGuid();
        }
    }
}
