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
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    public class EnvironmentalProductDeclaration : BHoMObject, IEnvironmentalProductDeclarationData
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Acidification, measured in kgSO2e, refers to emissions which increase the H+ ions in the environment causing a decrease in pH. Potential effects include fish mortality, forest decline, and the deterioration of building materials.")]
        public virtual double AcidificationPotential { get; set; } = double.NaN;

        [Description("Biogenic carbon includes emissions, in terms of kgCO2e, related to the natural carbon cycle related to biological-based materials and may involve carbon uptake, fermentation, combustion, etc.")]
        public virtual double BiogenicCarbon { get; set; } = double.NaN;

        [Density]
        [Description("The material density in kg/m^3.")]
        public virtual double Density { get; set; } = 0;

        [Description("Depletion of Abiotic Resources refers to non-renewable resources such as minerals, clay, and peat measured in kg Sb (antimony) equivalent.")]
        public virtual double DepletionOfAbioticResources { get; set; } = double.NaN;

        [Description("Depletion of non-renewable Abiotic Resources (fossil fuels) measured in Methyl Jasmonate.")]
        public virtual double DepletionOfAbioticResourcesFossilFuels { get; set; } = double.NaN;

        [Description("Brief summary of the EPD from the data source.")]
        public virtual string Description { get; set; } = "";

        [Description("Description of the material's treatment after its useful life.")]
        public virtual string EndOfLifeTreatment { get; set; } = "";

        [Description("Eutrophication, measured in kg N equivalents, refers to emissions of nutrients like nitrogen and phosphorus causing overfertilization, leading to overgrowth of biomass that depresses oxygen levels and suffocates ecosystems.")]
        public virtual double EutrophicationPotential { get; set; } = double.NaN;

        [Description("Exported Electrical Energy or EEE measured in MJ.")]
        public virtual double ExportedElectricalEnergy { get; set; } = double.NaN;

        [Description("Exported Thermal Energy or EET measured in MJ.")]
        public virtual double ExportedThermalEnergy { get; set; } = double.NaN;

        [Description("Use of freshwater resources measured in m^3.")]
        public virtual double FreshWater { get; set; } = double.NaN;

        [Description("Global Warming Potential, expressed in kgCO2e, refers to the emissions of carbon dioxide, methane and other gases that contribute to the greenhouse effect and global warming.")]
        public virtual double GlobalWarmingPotential { get; set; } = double.NaN;

        [Description("Hazardous Waste Disposed or HWD measured in kg.")]
        public virtual double HazardousWasteDisposed { get; set; } = double.NaN;

        [Description("Unique identifier of the EPD from the source of the information.")]
        public virtual string Id { get; set; } = "";

        [Description("Industry Standards referenced in creating the product.")]
        public virtual List<string> IndustryStandards { get; set; } = new List<string>();

        [Description("Phase abbreviation for the scope of the EPD. For single phase entries, please input the relevant phase of evaluation i.e. A1 or A1-A3. More information on typical LCA phases can be found in the repository wiki.")]
        public virtual string LifeCycleAssessmentPhase { get; set; } = "Undefined";

        [Description("The period of useful life of the product measured in years.")]
        public virtual int Lifespan { get; set; } = 0;

        [Description("Manufacturer name.")]
        public virtual string Manufacturer { get; set; } = "";

        [Description("MasterFormat code for material type organisation.")]
        public virtual string MasterFormat { get; set; } = "";

        [Description("Material For Energy Recovery or MFR measured in kg.")]
        public virtual double MaterialForEnergyRecovery { get; set; } = double.NaN;

        [Description("Non-Hazardous Waste Disposed or NHWD measured in kg.")]
        public virtual double NonHazardousWasteDisposed { get; set; } = double.NaN;

        [Description("Use of Non-renewable Secondary Fuels or NRSF measured in MJ, LHV.")]
        public virtual double NonRenewableSecondaryFuels { get; set; } = double.NaN;

        [Description("Ozone Depletion Potential, measured in kg CFC-11 equivalents, refers to emissions which contribute to the depletion of the stratospheric ozone layer.")]
        public virtual double OzoneDepletionPotential { get; set; } = double.NaN;

        [Description("Photochemical Ozone Creation Potential, measured in kgO3 equivalents, refers to emissions which contribute to the formation of ground-level smog.")]
        public virtual double PhotochemicalOzoneCreationPotential { get; set; } = double.NaN;

        [Description("Manufacturing facility name within which the product was created.")]
        public virtual string Plant { get; set; } = "";

        [Description("Postal Code within which the product was created.")]
        public virtual int PostalCode { get; set; } = 0;

        [Description("Amount of post consumer recycled content measured in kg.")]
        public virtual string PostConsumerRecycledContent { get; set; } = "";

        [Description("Use of non-renewable primary energy excluding raw materials measured in megajoules.")]
        public virtual double PrimaryEnergyNonRenewableEnergy { get; set; } = double.NaN;

        [Description("Primary Energy Non-renewable Resources or PENRT is measured in MJ, LHV.")]
        public virtual double PrimaryEnergyNonRenewableResource { get; set; } = double.NaN;

        [Description("Use of renewable energy primary energy in megajoules.")]
        public virtual double PrimaryEnergyRenewableEnergy { get; set; } = double.NaN;

        [Description("Total use of renewable energy resources required to produce a product, measured in megajoules.")]
        public virtual double PrimaryEnergyRenewableTotal { get; set; } = double.NaN;

        [Description("Primary Energy Resources used as raw materials measured in megajoules.")]
        public virtual double PrimaryEnergyResourcesRawMaterials { get; set; } = double.NaN;

        [Description("Radioactive Waste Disposed measured in kg.")]
        public virtual double RadioActiveWasteDisposed { get; set; } = double.NaN;

        [Description("Year in which the EPD was created.")]
        public virtual int ReferenceYear { get; set; } = 0;

        [Description("Use of Renewable Secondary fuels measured in megajoules.")]
        public virtual double RenewableSecondaryFuels { get; set; } = double.NaN;

        [Description("Use of secondary materials measured in kg.")]
        public virtual double SecondaryMaterial { get; set; } = double.NaN;

        [Description("Note that any EPD that does not contain this parameter will not be evaluated." +
            "This metric is based on the declared unit of the reference EPD, i.e. a declared unit of kg refers to QuantityType of mass, a declared unit of m3 refers to a QuantityType of volume, etc. " +
            "All data should be normalized to metric declared units before integration in the BHoM. " +
            "The quantity type is a key metric for evaluation methods to function. " +
            "This property determines how the material is to be evaluated, based on Mass, Volume, Area, Item, or Length. ")]
        public virtual QuantityType QuantityType { get; set; } = QuantityType.Undefined;

        [Description("The number of units in reference to quantity type. Example, 1000 kg per unit quantityType of Mass.")]
        public virtual double QuantityTypeValue { get; set; } = 1;

        /***************************************************/
    }
}
