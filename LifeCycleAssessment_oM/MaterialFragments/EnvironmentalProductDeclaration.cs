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
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Physical.Materials;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("An Environmental Product Declaration or EPD is an independently verified and registered document that communicates transparent and comparable information about the life-cycle environmental impact of products in a credible way. \n" + 
        "More information can be found on the Environdec website (environdec.com/all-about-epds0/all-about-epds.) \n" + 
        "All EPDs within the BHoM have been provided for general use and are updated as frequently as possible, but by using any supplied EPDs you assume all responsibility for the data used on any applications. \n" + 
        "For additional comments, questions, or feature requests, please visit the LifeCycleAssessment_Toolkit at github.com/BHoM/LifeCycleAssessment_Toolkit.")]
    public class EnvironmentalProductDeclaration : BHoMObject, IMaterialProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The Type of Environmental Product Declaration.")]
        public virtual EPDType Type { get; set; } = EPDType.Product;

        [Description("An Environmental Metric to describe the type and quantity of a specified metric. These metrics are used in all LCA calculations.")]
        public virtual List<EnvironmentalMetric> EnvironmentalMetric { get; set; } = new List<EnvironmentalMetric>();

        [Description("Note that any EPD that does not contain this parameter will not be evaluated. \n" +
            "This metric is based on the declared unit of the reference EPD, i.e. a declared unit of kg refers to QuantityType of mass, a declared unit of m3 refers to a QuantityType of volume, etc. \n" +
            "All data should be normalized to metric declared units before integration in the BHoM. \n" +
            "The quantity type is a key metric for evaluation methods to function. \n" +
            "This property determines how the material is to be evaluated, based on Mass, Volume, Area, Item, or Length.")]
        public virtual QuantityType QuantityType { get; set; } = QuantityType.Undefined;

        [Description("The number of units in reference to quantity type. Example, 1000 kg per unit quantityType of Mass.")]
        public virtual double QuantityTypeValue { get; set; } = 1;

        /***************************************************/
    }
}
