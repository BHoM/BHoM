using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Structural.Elements;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class Building : BHoMObject, IBuilidng
    {
        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;
        public double Elevation { get; set; } = 0.0;

        public Point Location { get; set; } = new Point();
        public List<IEquipment> Equipments { get; set; } = new List<IEquipment>();
        public List<Space> Spaces { get; set; } = new List<Space>();
        public List<Storey> Storeys { get; set; } = new List<Storey>();
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<InternalCondition> InternalConditions { get; set; } = new List<InternalCondition>();
        public List<IEquipmentProperties> EquipmentProperties { get; set; } = new List<IEquipmentProperties>();
    }
}
