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
using System.ComponentModel;

namespace BH.oM.Environment.SpaceCriteria
{
    [Description("The fire protection attributes of a space are indicative of the hazard level of the space (which influences the sprinkler count), the sprinkler system type required, and the presence of combustible materials or sloped ceilings.")]
    public class FireProtection : BHoMObject
    {

        [Description("Hazard Type indicates the combustibility of the materials within the space (Light, Ordinary or Extra). The indication of hazard type also determines the density of sprinklers required within the space.")]
        public virtual HazardType HazardType { get; set; } = HazardType.Undefined;

        [Description("Sprinkler System Type indicates whether the system will need to accommodate spaces that are subject to freezing (dry system type, commonly used in loading docks and parking garages), spaces that contain materials that when on fire would be spread further by water (foam system type, commonly used in a diesel generator room), spaces that contain precious materials that would be ruined by a false trip of the sprinkler system (preaction, commonly used in art galleries.) ")]
        public virtual SprinklerSystemType SprinklerSystemType { get; set; } = SprinklerSystemType.Undefined;

        [Description("The presence of combustible materials in the space would indicate the potential need for increasing the hazard type within the space.")]
        public virtual bool CombustibleMaterials { get; set; } = false;

        [Description("The presence of a sloped ceiling within the space would indicate the potential need for the area of the ceiling being calculated as if it were flat (i.e. the space would require more sprinklers than by area alone.)")]
        public virtual bool SlopedCeiling { get; set; } = false;

        [Description("The maximum ceiling temperature indicates the temperature rating, classification and color of the sprinklers within the space.")]
        public virtual double MaximumCeilingTemperature { get; set; } = 0.0;

    }
}



