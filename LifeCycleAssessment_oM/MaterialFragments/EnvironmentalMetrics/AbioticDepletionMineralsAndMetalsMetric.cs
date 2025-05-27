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
using BH.oM.Base.Attributes;
using BH.oM.Quantities.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Abiotic Depletion of Minerals and Metals, measured in Antimony (Sb), refers to the over-extraction of non-renewable materials which can lead to the exhaustion of natural (non-fossil) resources. This environmental indicator forms part of an Environmental Product Declaration and should be evaluated based on the Quantity Type stated on the Environmental Product Declaration.")]
    public class AbioticDepletionMineralsAndMetalsMetric : BHoMObject, IEnvironmentalMetric, IDynamicObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [DynamicProperty]
        [AbioticDepletionMineralsAndMetalsPerQuantity]
        [Description("Set of factors per module.")]
        public virtual Dictionary<Module, double> Indicators { get; set; } = new Dictionary<Module, double>();

        /***************************************************/

    }
}