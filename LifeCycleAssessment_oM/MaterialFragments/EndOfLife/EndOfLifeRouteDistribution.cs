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

using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.EndOfLife
{
    [Description("Class outlining the distribution between different end of life routes and scenarios for a particular material. All ratios should be between 0 and 1, and in total sum up to 1.")]
    public class EndOfLifeRouteDistribution : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name of the scenario or material wo which this corresponds.")]
        public override string Name { get; set; }

        [Ratio]
        [Description("Proportion of the material that is resued. Should be a number betwen 0 and 1 where 0 means no reuse, and 1 means all is reused.")]
        public virtual double Reuse { get; set; }

        [Ratio]
        [Description("Proportion of the material that is recycled. Should be a number betwen 0 and 1 where 0 means nothing is recyled, and 1 means all is recyled.")]
        public virtual double Recycling { get; set; }

        [Ratio]
        [Description("Proportion of the material that is incinerated. Should be a number betwen 0 and 1 where 0 means nothing is incinerated, and 1 means all is incinerated.")]
        public virtual double Incineration { get; set; }

        [Ratio]
        [Description("Proportion of the material that is incinerated. Should be a number betwen 0 and 1 where 0 means nothing is incinerated, and 1 means all is incinerated.")]
        public virtual double Waste { get; set; }

        /***************************************************/
    }
}
