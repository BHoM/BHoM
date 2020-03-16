/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    public class EnvironmentalProductDeclaration : BHoMObject, IEnvironmentalProductDeclarationData
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public string Manufacturer { get; set; } = "";
        public string Plant { get; set; } = "";
        public int PostalCode { get; set; } = 0;
        public List<string> IndustryStandards { get; set; } = new List<string>();
        public string Id { get; set; } = "";
        public string Density { get; set; } = "";
        public string GwpPerKG { get; set; } = "";
        public string GwpPerDeclaredUnit { get; set; } = "";
        public double BiogenicEmbodiedCarbon { get; set; } = double.NaN;
        public string DeclaredUnit { get; set; } = "";
        public string Description { get; set; } = "";
        public string Scope { get; set; } = "";
        public double GlobalWarmingPotential { get; set; } = double.NaN;
        public double OzoneDepletionPotential { get; set; } = double.NaN;
        public double PhotochemicalOzoneCreationPotential { get; set; } = double.NaN; //needs convert method "smogPotential"
        public double AcidificationPotential { get; set; } = double.NaN;
        public double EutrophicationPotential { get; set; } = double.NaN;
        public double DepletionOfAbioticResourcesFossilFuels { get; set; } = double.NaN; //needs convert method "primaryEnergyDemand"
        public double GlobalWarmingPotentialEndOfLife { get; set; } = double.NaN;
        public double OzoneDepletionPotentialEndOfLife { get; set; } = double.NaN;
        public double PhotochemicalOzoneCreationPotentialEndOfLife { get; set; } = double.NaN; //needs convert method "smogPotentialEol"
        public double AcidificationPotentialEndOfLife { get; set; } = double.NaN;
        public double EutrophicationPotentialEndOfLife { get; set; } = double.NaN;
        public double DepletionOfAbioticResourcesFossilFuelsEndOfLife { get; set; } = double.NaN; //needs convert method "primaryEnergyDemandEol"
        public string EndOfLifeTreatment { get; set; } = "";
        public string Masterformat { get; set; } = "";
        public string PostConsumerRecycledContent { get; set; } = "";
        public int ReferenceYear { get; set; } = 0;
        /***************************************************/
    }
}
