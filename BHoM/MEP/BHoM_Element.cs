using BHoM.Global;
using BHoM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.MEP
{
    /// <summary>
    /// Jakub - please fill this in
    /// </summary>
    public class Element : BHoMObject
    {
        private Location pLocation;
        private Shell pShell;

        /// <summary>
        /// Jakub - please fill this in
        /// </summary>
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

        public Element(Location Location, SpatialBoundary spatialBoundary)
        {
            Initialize();
            pLocation = Location;
        }

        public Element(Location Location, Shell Shell)
        {
            Initialize();
            pLocation = Location;
            pShell = Shell;
        }

        private void Initialize()
        {
            SetBHoMGuid();

        }

        public override string JSON()
        {
            string aNestedJSON = ",";
            aNestedJSON += string.Format("\"{0}\": {1}", "Shell", "");
            aNestedJSON += pShell.JSON();
            aNestedJSON += ",";
            aNestedJSON += string.Format("\"{0}\": {1}", "Location", "");
            aNestedJSON += pLocation.JSON();
            if (aNestedJSON.Last() == ',')
                aNestedJSON = aNestedJSON.Substring(0, aNestedJSON.Length - 1);
            aNestedJSON += "";
            return JSON(aNestedJSON);
        }
    }
}
