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
using BH.oM.Geometry;
using BH.oM.Physical.Enums;
using BH.oM.Quantities.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Physical.Elements
{
    [Description("A device used to control the flow within a duct system (fire smoke damper, volume damper, etc.)")]
    public class Damper : BHoMObject, IElement0D, IConduitConnector
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The point at which the Fitting occurs.")]
        public virtual Point Location { get; set; } = null;

        [Description("The points at which the Fitting physically connects to other MEP segments.")]
        public virtual List<Connector> Connections { get; set; } = null;

        [Description("A type which describes the damper more specifically whether it's a fire smoke damper, volume damper or balancing damper.")]
        public virtual DamperType DamperType { get; set; } = DamperType.Undefined;

        [Description("The geometry and size dependent local loss coefficient for fittings.")]
        public virtual double CFactor { get; set; } = 0;

        /***************************************************/
    }
}

