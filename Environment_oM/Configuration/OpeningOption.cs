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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Environment.Elements;

namespace BH.oM.Environment.Configuration
{
    [Description("Defines the design options for Openings.")]
    public class OpeningOption : BHoMObject
    {
        [Length]
        [Description("Defines the height the opening should be.")]
        public virtual double Height { get; set; } = 0;
        
        [Length]
        [Description("Defines the width the opening should be.")]
        public virtual double Width { get; set; } = 0;

        [Length]
        [Description("The distance between the base of the panel and the bottom of the opening.")]
        public virtual double SillHeight { get; set; } = 0;

        [Description("The type of opening that should be created from this opening configuration.")]
        public virtual OpeningType Type { get; set; } = OpeningType.Undefined;
    }
}

