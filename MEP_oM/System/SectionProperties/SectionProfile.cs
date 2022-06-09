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

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Spatial.ShapeProfiles;

namespace BH.oM.MEP.System.SectionProperties
{
    public class SectionProfile : BHoMObject, IBHoMObject, IImmutable
    {
        [Description("ShapeProfile of the element itself. This is the base ShapeProfile that determines the overall shape of the IFlow object.")]
        public virtual IProfile ElementProfile { get; }

        [Description("ShapeProfile of the element's interior lining.")]
        public virtual IProfile LiningProfile { get; }

        [Description("ShapeProfile of the element's exterior insulation.")]
        public virtual IProfile InsulationProfile { get; }

        public SectionProfile(IProfile elementProfile, IProfile liningProfile, IProfile insulationProfile)
        {
            ElementProfile = elementProfile;
            LiningProfile = liningProfile;
            InsulationProfile = insulationProfile;
        }
    }
}


