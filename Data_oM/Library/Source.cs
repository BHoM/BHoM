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
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Data.Library
{
    public class Source : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Hyperlink or file path to where the source information used can be found.")]
        public virtual string SourceLink { get; set; } = "";

        [Description("Title of the source. For example Book title, Paper title, Code title etc.")]
        public virtual string Title { get; set; } = "";

        [Description("Author of the source.")]
        public virtual string Author { get; set; } = "";

        [Description("Table, figure or code reference etc.")]
        public virtual string ItemReference { get; set; } = "";

        [Description("Version or edition of the source.")]
        public virtual string Version { get; set; } = "";

        [Description("Publisher of the source.")]
        public virtual string Publisher { get; set; } = "";

        [Description("Schema of the source.")]
        public virtual string Schema { get; set; } = "";

        [Description("Language of the source.")]
        public virtual string Language { get; set; } = "";

        [Description("Country/Region of the source.")]
        public virtual string Location { get; set; } = "";

        [Description("Any applicable copyright information associated with the source.")]
        public virtual string Copyright { get; set; } = "";

        [Description("Contributors to the source.")]
        public virtual string Contributors { get; set; } = "";

        [Description("Level of confidence of the data related to the source.")]
        public virtual Confidence Confidence { get; set; } = Confidence.Undefined;

        /***************************************************/
    }
}



