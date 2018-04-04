using System.Collections.Generic;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Environmental.Interface;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environmental.Elements
{
    public class Space : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Level Level { get; set; } = new Level();
        public Point Location { get; set; } = new Point();
        //TODO: remove BuildingElements from Space
        /// <summary> 
        /// BuidlingElements will be depreciated. Link between Space and Building moved to AdjacenSpaces in Building Element.
        /// </summary>
        public List<BuildingElement> BuildingElements { get; set; } = new List<BuildingElement>();
        public List<IBuildingObject> BuildingObjects { get; set; } = new List<IBuildingObject>();
        public List<InternalCondition> InternalConditions { get; set; } = new List<InternalCondition>();
        public List<IEquipmentProperties> EquipmentProperties { get; set; } = new List<IEquipmentProperties>();

        public string Number { get; set; } = "";

        /***************************************************/
    }
}
