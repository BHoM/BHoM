using BHoM.MEP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.MEP
{
    public class Space : Element
    {
        //private string pName;
        private string pNumber;

        public Space(string Name, string Number, SpatialBoundary SpatialBoundary, Location Location)
            : base(Location, SpatialBoundary)
        {
            this.Name = Name;
            pNumber = Number;
        }

        /*public string Name
        {
            get
            {
                return pName;
            }
            set
            {
                pName = value;
            }
        }*/

        public string Number
        {
            get
            {
                return pNumber;
            }
            set
            {
                pNumber = value;
            }
        }

    }
}
