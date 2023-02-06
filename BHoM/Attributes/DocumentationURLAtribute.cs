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
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Base.Attributes.Enums;

namespace BH.oM.Base.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class DocumentationURLAtribute : Attribute, IImmutable
    {
        public virtual string DocumentationURL { get; private set; } = "";
        public virtual DocumentationType Type { get; private set; } = DocumentationType.Undefined;
        public virtual string Description { get; private set; } = "";

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public DocumentationURLAtribute(string documentationURL, DocumentationType type, string description = "")
        {
            DocumentationURL = documentationURL;
            Type = type;
            Description = description;
        }
    }
}
