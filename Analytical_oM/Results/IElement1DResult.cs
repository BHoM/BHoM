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
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BH.oM.Analytical.Results
{
    [Description("Base interface for results, corresponding to a discrete result at a particular position along a one-dimensional element.")]
    public interface IElement1DResult : IResult, IObjectIdResult, IResultItem
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Position on the element as normalised length, i.e. 0 for start, 1 for end and 0.5 for middle.")]
        double Position { get; }

        [Description("How many division points along the element was used when extracting this result. This generally means that this many results with the same identifiers and varying Position was extracted.")]
        int Divisions { get; }

        /***************************************************/
    }
}



