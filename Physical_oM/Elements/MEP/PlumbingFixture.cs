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
    [Description("A device used to regulate the volume of air to or from an air handling unit, variable air volume device or similar, to or from the occupied space. These devices may be ducted or connect directly to a plenum, in which case no duct connection will be present.")]
    public class PlumbingFixture : BHoMObject, IElement0D, IConduitTermination
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The point in space for the location of the object.")]
        public virtual Point Location { get; set; } = null;

        [Description("The point at which the air terminal physically connects to other MEP segments.")]
        public virtual Connector Connection { get; set; } = null;

        public virtual PlumbingFixtureType Type { get; set; } = PlumbingFixtureType.Undefined;

        /***************************************************/
    }
}


