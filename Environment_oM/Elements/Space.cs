/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

using BH.oM.Environment.Fragments;
using BH.oM.Environment.SpaceCriteria;
using BH.oM.Architecture.Elements;

using BH.oM.Geometry;
using System.ComponentModel;

using BH.oM.Dimensional;
using BH.oM.Analytical.Elements;

namespace BH.oM.Environment.Elements
{
    [Description("A space object is an analytical depiction of a room defined by its environmental conditions (internal gains)")]
    public class Space : BHoMObject, IEnvironmentObject, IRegion, IElement2D
    {
        [Description("Zones denotes the list of zones that this particular space is associated with. Zones are collections of spaces with similar internal gains and exterior envelope conditions.")]
        public virtual List<string> Zones { get; set; } = new List<string>();

        [Description("Lighting gains are objects that are defined as the amount of heat contributed by light fixtures within the space")]
        public virtual List<SpaceCriteria.Lighting> LightingGain { get; set; } = new List<SpaceCriteria.Lighting>();

        [Description("Equipment gains are objects that are defined as the amount of heat contributed by equipment within the space")]
        public virtual List<SpaceCriteria.Equipment> EquipmentGain { get; set; } = new List<SpaceCriteria.Equipment>();

        [Description("People gains are objects that are defined as the amount of heat contributed by people based on their assumed activity level within the space (dancing, sitting, etc)")]
        public virtual List<SpaceCriteria.People> PeopleGain { get; set; } = new List<SpaceCriteria.People>();

        [Description("Infiltration gains are objects that are defined as the amount of heat or heat loss contributed by cracks in the exterior envelope of the building which allow unconditioned outside air to be introduced to the space")]
        public virtual List<SpaceCriteria.Infiltration> Infiltration { get; set; } = new List<SpaceCriteria.Infiltration>();

        [Description("Ventilation are objects that define the amount of outside air that should be introduced to a space, which is typically based on the number of occupants breathing the air and the area of the space.")]
        public virtual List<SpaceCriteria.Ventilation> Ventilation { get; set; } = new List<SpaceCriteria.Ventilation>();

        [Description("Exhaust are objects that define the amount of air that should be extracted from a space, which is either based on the objects within the space (toilets, showers) or the space type (kitchen, bathroom).")]
        public virtual List<SpaceCriteria.Exhaust> Exhaust { get; set; } = new List<SpaceCriteria.Exhaust>();

        [Description("Occupant Density is an object that defines the area occupied by each individual in a space (2 m2 per person).")]
        public virtual Occupancy OccupantDensity { get; set; } = new Occupancy();

        [Description("Acoustics for an Environments Space define the noise within the space, by noise created by the velocity of the air within the ducts in the space, the Noise Rating, and decibel.")]
        public virtual SpaceCriteria.Acoustics Acoustics { get; set; } = new SpaceCriteria.Acoustics();

        [Description("The plumbing attributes of a space are indicative of the amount of cold water, hot water and waste required by a space, as well as requirements for vent, floor drains, hose bibs or natural gas.")]
        public virtual SpaceCriteria.Plumbing Plumbing { get; set; } = new SpaceCriteria.Plumbing();

        [Description("The fire protection attributes of a space are indicative of the hazard level of the space (which influences the sprinkler count), the sprinkler system type required, and the presence of combustible materials or sloped ceilings.")]
        public virtual SpaceCriteria.FireProtection FireProtection { get; set; } = new SpaceCriteria.FireProtection();

        [Description("Project Space Type is a string that defines how the space is used on a given project (Museum, Corridor, etc)")]
        public virtual string ProjectSpaceType { get; set; } = "";

        [Description("Space Type is an enum that defines how the space is used (Museum, Corridor, etc)")]
        public virtual SpaceType SpaceType { get; set; } = SpaceType.Undefined;

        [Description("A point in 3D space providing a location point of the space")]
        public virtual Point Location { get; set; } = new Point();

        [Description("A 2D curve defining the external boundaries of the floor of the space")]
        public virtual ICurve Perimeter { get; set; } = new Polyline();
    }
}



