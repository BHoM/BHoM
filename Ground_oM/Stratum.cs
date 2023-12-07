/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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


using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;

namespace BH.oM.Ground
{

    [Description("A stratum containing the geological information based on the AGS schema.")]
    public class Stratum : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Location identifier relating the borehole to the strata (LOCA_ID).")]
        public virtual string Id { get; set; }

        [Length]
        [Description("Depth to the top of the strata based on the datum provided on the Borehole (GEOL_TOP).")]
        public virtual double Top { get; set; }

        [Length]
        [Description("Depth to the bottom of the strata based on the datum provided on the Borehole (GEOL_BOT).")]
        public virtual double Bottom { get; set; }

        [Description("General description of the strata (GEOL_DESC).")]
        public virtual string LogDescription { get; set; }

        [Description("The legend code summarising the LogDescription (GEOL_LEG).")]
        public virtual string Legend { get; set; }

        [Description("The observed geology expressed as a GeologicalUnit (GEOL_GEOL).")]
        public virtual string ObservedGeology { get; set; }

        [Description("The interpreted geology expressed as an engineering material (GEOL_GEO2).")]
        public virtual string InterpretedGeology { get; set; }

        [Description("The optional interpreted geology expressed as an engineering material (GEOL_GEO3).")]
        public virtual string OptionalInterpretedGeology { get; set; }

        [Description("The optional stratum properties.")]
        public virtual List<IStratumProperty> Properties { get; set; }

        /***************************************************/
    }
}




