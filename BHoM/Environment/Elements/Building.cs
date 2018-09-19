using System;
using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environment.Interface;
using BH.oM.Environment.Properties;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environment.Elements
{
    public class Building : BHoMObject, IBuilding
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;
        public double Elevation { get; set; } = 0.0;

        public Point Location { get; set; } = new Point();
        /*public List<IEquipment> Equipments { get; set; } = new List<IEquipment>();
        public List<Space> Spaces { get; set; } = new List<Space>();
        public List<Level> Levels { get; set; } = new List<Level>();
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<InternalCondition> InternalConditions { get; set; } = new List<InternalCondition>();
        public List<IEquipmentProperties> EquipmentProperties { get; set; } = new List<IEquipmentProperties>();
        public List<BuildingElementProperties> BuildingElementProperties { get; set; } = new List<BuildingElementProperties>();
        public List<BuildingElement> BuildingElements { get; set; } = new List<BuildingElement>();*/

        /***************************************************/
    }
}
