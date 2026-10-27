/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

namespace BH.oM.Base.Reflection
{
    public class CodeElementRecord : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual string AssemblyName { get; set; } = "";

        public virtual DateTime AssemblyModifiedTime { get; set; } = DateTime.MinValue;

        public virtual CodeElementType Type { get; set; } = CodeElementType.Undefined;

        public virtual string DisplayText { get; set; } = "";

        //public virtual string Json { get; set; } = "";

        //TODO: inputKeys could be read from DisplayText? so this is potentially redundant
        public virtual List<string> InputKeys { get; set; } = new List<string>();

        public virtual List<string> OutputKeys { get; set; } = new List<string>();


        /***************************************************/
    }
}
