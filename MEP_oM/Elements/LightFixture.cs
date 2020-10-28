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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Base;
using BH.oM.Analytical.Elements;
using BH.oM.MEP.SectionProperties;
using BH.oM.MEP.Parts;
using BH.oM.Dimensional;

namespace BH.oM.MEP.Elements
{
    [Description("A pipe object is a passageway which conveys material (water, waste, glycol)")]
    public class LightingFixture : BHoMObject, IElement1D, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The point in space for the location of the LightFixture.")]
        public virtual Node Location { get; set; } = new Node();

        [Description("The luminous flux is the measure of the perceived power of light.")]
        public virtual double LuminousFlux { get; set; } = 0;

        [Description("The color temperature is a means of describing the light fixture's appearance, measured in degrees Kelvin")]
        public virtual double ColorTemperature { get; set; } = 0;

        [Description("A means of denoting light fixtures that should be controlled in a similar manner.")]
        public virtual double ControlZone { get; set; } = 0;

        [Description("A means of adding an electrical connector part to the light fixture's properties. Gives the ability to add the voltage, amps, and denotes if the fixture should be on emergency power.")]
        public virtual List<IPart> Parts { get; set; } = new List<IPart>();


        /***************************************************/
    }
}
