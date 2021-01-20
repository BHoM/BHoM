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
    [Description("A device used to convey electricity e.g. duplex sockets/receptacles, disconnect/isolator switches (for electrified mechanical equipment), floors boxes.")]
    public class ElectricalFixture : BHoMObject, INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("A type which describes the electrical fixture more specifically whether it's a duplex or quad receptacle/socket, a floor box or a disconnect/isolator switch.")]
        public virtual ElectricalFixtureType ElectricalFixtureType { get; set; } = ElectricalFixtureType.Undefined;

        [Description("The point in space for the location of the Electrical Fixture.")]
        public virtual Point Position { get; set; } = new Point();

        [Description("Ground Fault Circuit Interrupter (GFCI) is a boolean value (true/false) that denotes whether a device is a fast acting circuit breaker designed to shut off power in the event of a ground fault.")]
        public virtual bool GroundFaultCircuitInterrupter { get; set; } = false;

        [Description("Weather Proof is a boolean value (true/false) that denotes whether a device has water/weather tight casting.")]
        public virtual bool WeatherProof { get; set; } = false;

        [Power]
        [Description("The power of the electrical fixture described in kilowatts.")]
        public virtual double Power { get; set; } = 0;
        /***************************************************/
    }
}
