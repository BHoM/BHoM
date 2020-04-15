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
    public class SectorEnvironmentalProductDeclaration : BHoMObject, IEnvironmentalProductDeclarationData
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual QuantityType QuantityType { get; set; } = QuantityType.Undefined;
        public virtual List<string> Publisher { get; set; } = new List<string>();
        public virtual List<string> Jurisdiction { get; set; } = new List<string>();
        public virtual string Id { get; set; } = "";
        public virtual double Density { get; set; } = double.NaN;
        public virtual string DeclaredUnit { get; set; } = "";
        public virtual string Description { get; set; } = "";
        public virtual string Scope { get; set; } = "";
        public virtual double GlobalWarmingPotential { get; set; } = double.NaN;
        public virtual double BiogenicEmbodiedCarbon { get; set; } = double.NaN;
        public virtual double OzoneDepletionPotential { get; set; } = double.NaN;
        public virtual double PhotochemicalOzoneCreationPotential { get; set; } = double.NaN;
        public virtual double AcidificationPotential { get; set; } = double.NaN;
        public virtual double EutrophicationPotential { get; set; } = double.NaN;
        public virtual double DepletionOfAbioticResourcesFossilFuels { get; set; } = double.NaN;
        public virtual double GlobalWarmingPotentialEndOfLife { get; set; } = double.NaN;
        public virtual double OzoneDepletionPotentialEndOfLife { get; set; } = double.NaN;
        public virtual double PhotochemicalOzoneCreationPotentialEndOfLife { get; set; } = double.NaN;
        public virtual double AcidificationPotentialEndOfLife { get; set; } = double.NaN;
        public virtual double EutrophicationPotentialEndOfLife { get; set; } = double.NaN;
        public virtual double DepletionOfAbioticResourcesFossilFuelsEndOfLife { get; set; } = double.NaN;
        public virtual string EndOfLifeTreatment { get; set; } = "";
        /***************************************************/
    }
}