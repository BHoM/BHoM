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

using System;
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Ground
{

    [Description("References to associated files, storage links or previous boreholes.")]
    public class BoreholeReference : BHoMObject, IBoreholeProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Associated file reference including instructions and photographs (FILE_FSET).")]
        public virtual List<string> File { get; set; }

        [Description("Link to storage of borehole data.")]
        public virtual string URL { get; set; }

        [Description("Original hole id (LOCA_ORID).")]
        public virtual string OriginalId { get; set; }

        [Description("Original job reference (LOCA_ORJO).")]
        public virtual string OriginalReference { get; set; }

        [Description("Originating company (LOCA_ORCO).")]
        public virtual string OriginalCompany { get; set; }

        /***************************************************/
    }
}