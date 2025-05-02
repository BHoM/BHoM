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

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Base interface for all classes that simply provide a list of environmental factors to be evaluated based on a particular quantity, namly the EnvironmentalProductDeclaration as well as CalculatedMaterialLifeCycleEnvironmentalImpactFactors.")]
    public interface IBaseLevelEnvironalmentalFactorsProvider : IBHoMObject, IEnvironmentalFactorsProvider
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("An Environmental Module Factors contains EnvironmentalFactors of a particular quantity for one or more modules. These factors are used in all LCA calculations.")]
        List<IEnvironmentalMetricFactors> EnvironmentalFactors { get; set; }

        [Description("Note that any EPD that does not contain this parameter will not be evaluated. \n" +
            "This metric is based on the declared unit of the reference EPD, i.e. a declared unit of kg refers to QuantityType of mass, a declared unit of m3 refers to a QuantityType of volume, etc. \n" +
            "All data should be normalized to metric declared units before integration in the BHoM. \n" +
            "The quantity type is a key metric for evaluation methods to function. \n" +
            "This property determines how the material is to be evaluated, based on Mass, Volume, Area, Item, or Length.")]
        QuantityType QuantityType { get; set; }

        /***************************************************/

    }
}


