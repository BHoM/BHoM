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
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    public class SectorEnvironmentalProductDeclaration : BHoMObject, IEnvironmentalProductDeclarationData
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Publisher description.")]
        public List<string> Publisher { get; set; } = new List<string>();

        [Description("Jurisdiction description.")]
        public List<string> Jurisdiction { get; set; } = new List<string>();

        [Description("Id description.")]
        public string Id { get; set; } = "";

        [Description("Density description.")]
        public string Density { get; set; } = "";

        [Description("Declared Unit description.")]
        public string DeclaredUnit { get; set; } = "";

        [Description("Description description.")]
        public string Description { get; set; } = "";

        [Description("Scope description.")]
        public string Scope { get; set; } = "";

        [Description("Global Warming Potential description.")]
        public double GlobalWarmingPotential { get; set; } = double.NaN;

        [Description("Biogenic Embodied Carbon description.")]
        public double BiogenicEmbodiedCarbon { get; set; } = double.NaN;

        [Description("Ozone Depletion Potential description.")]
        public double OzoneDepletionPotential { get; set; } = double.NaN;

        [Description("Photochemical Ozone Creation Potential description.")]
        public double PhotochemicalOzoneCreationPotential { get; set; } = double.NaN;

        [Description("Acidification Potential description.")]
        public double AcidificationPotential { get; set; } = double.NaN;

        [Description("Eutrophication Potential description.")]
        public double EutrophicationPotential { get; set; } = double.NaN;

        [Description("Depletion of Abiotic Resources Fossil Fuels description.")]
        public double DepletionOfAbioticResourcesFossilFuels { get; set; } = double.NaN;

        [Description("Global Warming Potential End of Life description.")]
        public double GlobalWarmingPotentialEndOfLife { get; set; } = double.NaN;

        [Description("Ozone Depletion Potential End of Life description.")]
        public double OzoneDepletionPotentialEndOfLife { get; set; } = double.NaN;

        [Description("Photochemcical Ozone Creation Potential End of Life description.")]
        public double PhotochemicalOzoneCreationPotentialEndOfLife { get; set; } = double.NaN;

        [Description("Acidification Potential End of Life description.")]
        public double AcidificationPotentialEndOfLife { get; set; } = double.NaN;

        [Description("Eutrophication Potential End of Life description.")]
        public double EutrophicationPotentialEndOfLife { get; set; } = double.NaN;

        [Description("Depletion of Abiotic Resources Fossil Fuels End of Life description.")]
        public double DepletionOfAbioticResourcesFossilFuelsEndOfLife { get; set; } = double.NaN;

        [Description("End of Life Treatment description.")]
        public string EndOfLifeTreatment { get; set; } = "";
        /***************************************************/
    }
}