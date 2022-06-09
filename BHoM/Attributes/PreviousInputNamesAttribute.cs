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
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace BH.oM.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    [Description("Provides the names that were previously used for a given input. If multiple names, use a ',' to separate them.")]
    public class PreviousInputNamesAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual string Name { get; private set; } = "";

        public virtual List<string> PreviousNames { get; private set; } = new List<string>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PreviousInputNamesAttribute(string name, List<string> previousNames)
        {
            Name = name;
            PreviousNames = previousNames.ToList();
        }

        /***************************************************/

        public PreviousInputNamesAttribute(string name, string previousNames)
        {
            Name = name;
            PreviousNames = previousNames.Split(new char[] { ',' }).Select(x => x.Trim()).ToList();
        }

        /***************************************************/
    }
}



