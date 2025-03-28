/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Geometry.CoordinateSystem;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;

namespace BH.oM.Ground
{

    [Description("A representation of a borehole defined by a coordinate system, start point and end point based on the AGS schema.")]
    public class Borehole : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Location identifier for the borehole unique to the project (LOCA_ID).")]
        public virtual string Id { get; set; }

        [Description("The top of the borehole within the coordinate system provided (LOCA_NATE, LOCA_NATEN, LOCA_GL).")]
        public virtual Point Top { get; set; }

        [Description("The bottom of the borehole within the coordinate system provided (LOCA_ETRV, LOCA_NTRV, LOCA_FDEP).")]
        public virtual Point Bottom { get; set; }

        [Description("The coordinate system referenced by the top and bottom point. (LOCA_GREF, LOCA_NATD).")]
        public virtual Cartesian CoordinateSystem { get; set; }

        [Description("A list of objects containing the strata found within the borehole, based on the GEOL table.")]
        public virtual List<Stratum> Strata { get; set; }

        [Description("A list of objects containing the contaminant samples found within the borehole, based on the ERES table.")]
        public virtual List<ContaminantSample> ContaminantSamples { get; set; }

        [Description("A list of objects containing the geotechnical results found within the borehole.")]
        public virtual List<ITest> GeotechnicalTestResults { get; set; }

        [Description("A list of properties related to the borehole.")]
        public virtual List<IBoreholeProperty> BoreholeProperties { get; set; }

        /***************************************************/
    }
}

