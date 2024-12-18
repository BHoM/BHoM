/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using BH.oM.LifeCycleAssessment.MaterialFragments.Transport;
using BH.oM.Physical.Materials;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("An Combined Life Cycle Assessment Factors is aggregate class to compute final impact factors.\n" +
                 "This object is commonly created based on a EPD for cradle to gate metrics (A1 - A3) with addional project and site specific data added for relevant stages such as A4 and A5.")]
    public class CombinedLifeCycleAssessmentFactors : BHoMObject, IMaterialProperties, IEnvironmentalMetricsProvider
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Environmental Product Declaration as the basis for the life cycle assessment. Commnly outlines the metrics for A1-A3 stages, but might contain metrics beyond those stages.")]
        public virtual EnvironmentalProductDeclaration EnvironmentalProductDeclaration { get; set; }

        [Description("Factors for computing the emissions relating to Transport, in general, for the A4 stage.")]
        public virtual ITransportFactors TransportFactors { get; set; }

        [Description("Control for wheter the metrics in the trasport factors should override any potential result for the A4 stage on the EPD.\n" +
                     "If true, A4 is computed only based on results from the TransportFactors. If false, the result is computed as the sum from both EPD and transport factors.")]
        public virtual bool TransportFactorsOverideEPDA4Factors { get; set; } = true;

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/


        [Description("Converts a EnvironmentalProductDeclaration to a CombinedLifeCycleAssessmentFactors, setting the EnvironmentalProductDeclaration to the provided EnvironmentalProductDeclaration. All other properties are set to default values.")]
        public static explicit operator CombinedLifeCycleAssessmentFactors(EnvironmentalProductDeclaration point)
        {
            return new CombinedLifeCycleAssessmentFactors { EnvironmentalProductDeclaration = point };
        }

        /***************************************************/
    }
}


