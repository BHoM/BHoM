/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.MEP.System.SectionProperties;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;
using BH.oM.Analytical.Elements;
using BH.oM.MEP.Enums;

namespace BH.oM.MEP.Fixtures
{
    [Description("A device used to convey public health (plumbing) fluids (water, waste.)")]
    public class PlumbingFixture : BHoMObject, INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("A type which describes the plumbing fixture more specifically whether it's a water closet (toilet), urinal or lavatory.")]
        public virtual PlumbingFixtureType PlumbingFixtureType { get; set; } = PlumbingFixtureType.Undefined;

        [Description("The point in space for the location of the Plumbing Fixture.")]
        public virtual Point Position { get; set; } = new Point();

        [VolumetricFlowRate]
        [Description("The volume of cold water being conveyed by the Plumbing Fixture per second (m3/s).")]
        public virtual double ColdWaterFlowRate { get; set; } = 0;

        [VolumetricFlowRate]
        [Description("The volume of hot water being conveyed by the Plumbing Fixture per second (m3/s).")]
        public virtual double HotWaterFlowRate { get; set; } = 0;

        [VolumetricFlowRate]
        [Description("The volume of waste/drainage being conveyed by the Plumbing Fixture per second (m3/s).")]
        public virtual double DrainageFlowRate { get; set; } = 0;

        [Description("The number of cold water fixture or loading units for the plumbing fixture which denote the hydraulic load imposed based on flow rate, time of operation and frequency of use.")]
        public virtual double ColdWaterLoadingFixtureUnits { get; set; } = 0.0;

        [Description("The number of hot water fixture or loading units for the plumbing fixture which denote the hydraulic load imposed based on flow rate, time of operation and frequency of use.")]
        public virtual double HotWaterLoadingFixtureUnits { get; set; } = 0.0;

        [Description("The number of waste/drainage fixture or loading units for the plumbing fixture which denote the hydraulic load imposed based on flow rate, time of operation and frequency of use.")]
        public virtual double DrainageLoadingFixtureUnits { get; set; } = 0.0;

        [Description("The PipeSectionProperties for the cold water pipe connected to the plumbing fixture.")]
        public virtual PipeSectionProperty ConnectedColdWaterPipeProperties { get; set; } = null;

        [Description("The PipeSectionProperties for the hot water pipe connected to the plumbing fixture.")]
        public virtual PipeSectionProperty ConnectedHotWaterPipeProperties { get; set; } = null;

        [Description("The PipeSectionProperties for the drainage pipe connected to the plumbing fixture.")]
        public virtual PipeSectionProperty ConnectedDrainagePipeProperties { get; set; } = null;

        /***************************************************/
    }
}
