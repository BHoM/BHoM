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

using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.MEP.Enums;
using BH.oM.MEP.Fragments;
using BH.oM.MEP.System;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.MEP.Fixtures
{
    [Description("A device used to convey public health (plumbing) fluids (water, waste.)")]
    public class PlumbingFixture : BHoMObject, IElement0D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The point in space for the location of the object.")]
        public virtual Node Location { get; set; } = new Node();

        [Angle]
        [Description("Controls the local plan orientation of the object.")]
        public virtual double OrientationAngle { get; set; } = 0;

        [Description("A type which describes the plumbing fixture more specifically whether it's a water closet (toilet), urinal or lavatory.")]
        public virtual PlumbingFixtureType PlumbingFixtureType { get; set; } = PlumbingFixtureType.Undefined;

        [Description("Depiction of the plumbing flow associated with the plumbing fixture (cold water, hot water and drainage.)")]
        public virtual PlumbingFlowFragment Flow { get; set; } = new PlumbingFlowFragment();

        [Description("Depiction of the plumbing loading/fixture units associated with the plumbing fixture (cold water, hot water and drainage.)")]
        public virtual PlumbingLoadingFixtureUnitFragment LoadingFixtureUnits { get; set; } = new PlumbingLoadingFixtureUnitFragment();

        /***************************************************/
    }
}

