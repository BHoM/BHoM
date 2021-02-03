/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.MEP.System.MaterialFragments;
using BH.oM.Spatial.ShapeProfiles;

namespace BH.oM.MEP.System.SectionProperties
{
    public class SectionProperty : BHoMObject, IFlowSectionProperty, IImmutable
    {
        [Description("ShapeProfile of the element itself. This is the base ShapeProfile that determines the overall shape of the IFlow object.")]
        public virtual IProfile Profile { get; set; }

        [Description("The materials of the object.")]
        public virtual SystemMaterialFragment Materials { get; set; }

        [Description("Lining thickness if being utilised within the element.")]
        public virtual double LiningThickness { get; set; }

        [Description("Insulation thickness if being utilised within the element.")]
        public virtual double InsulationThickness { get; set; }

        [Description("Hydraulic Diameter allows you to calculate the round equivalent hydraulic diameter for a non-round duct (rectangular/square).")]
        public virtual double HydraulicDiameter { get; }

        [Description("CircularEquivalentDiameter is the equivalent size for a duct if it were to be round (for size/capacity comparison).")]
        public virtual double CircularEquivalentDiameter { get; }

        [Description("This area takes the element's thickness into account to determine the actual area of the 'solid' portion of the ShapeProfile.")]
        public virtual double ElementSolidArea { get; }

        [Description("The interior area within the element's shapeProfile. This corresponds to the actual open area less any material thickness.")]
        public virtual double ElementVoidArea { get; }

        [Description("The solid area of the lining within the element. This area takes into account the ElementSolidArea.")]
        public virtual double LiningSolidArea { get; }

        [Description("The innermost, open area within the Element and its interior lining. This corresponds to the actual open area of the element.")]
        public virtual double LiningVoidArea { get; }

        [Description("The actual area of the exterior insulation material.")]
        public virtual double InsulationSolidArea { get; }

        [Description("The interior area within the Insulation. This should correspond to the element's height and width properties.")]
        public virtual double InsulationVoidArea { get; }

        //Constructor
        public SectionProperty(IProfile elementProfile, double elementSolidArea, double liningSolidArea, double insulationSolidArea, double elementVoidArea, double liningVoidArea, double insulationVoidArea, double hydraulicDiameter, double circularEquivalentDiameter)
        {
            Profile = elementProfile;
            ElementSolidArea = elementSolidArea;
            ElementVoidArea = elementVoidArea;
            LiningSolidArea = liningSolidArea;
            LiningVoidArea = liningVoidArea;
            InsulationSolidArea = insulationSolidArea;
            InsulationVoidArea = insulationVoidArea;
            HydraulicDiameter = hydraulicDiameter;
            CircularEquivalentDiameter = circularEquivalentDiameter;
        }
    }
}

