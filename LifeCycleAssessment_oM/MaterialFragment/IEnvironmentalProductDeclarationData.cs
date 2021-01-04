/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Physical.Materials;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;
using System.Dynamic;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    public interface IEnvironmentalProductDeclarationData : IFragment, IMaterialProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Acidification, measured in kgSO2e, refers to emissions which increase the H+ ions in the environment causing a decrease in pH. Potential effects include fish mortality, forest decline, and the deterioration of building materials.")]
        double AcidificationPotential { get; set; }

        [Description("Biogenic carbon includes emissions, in terms of kgCO2e, related to the natural carbon cycle related to biological-based materials and may involve carbon uptake, fermentation, combustion, etc.")]
        double BiogenicCarbon { get; set; }

        [Density]
        [Description("The material density in kg/m^3.")]
        double Density { get; set; }

        [Description("Depletion of Abiotic Resources refers to non-renewable resources such as minerals, clay, and peat measured in kg Sb (antimony) equivalent.")]
        double DepletionOfAbioticResources { get; set; }

        [Description("Depletion of non-renewable Abiotic Resources (fossil fuels) measured in Methyl Jasmonate.")]
        double DepletionOfAbioticResourcesFossilFuels { get; set; }

        [Description("Brief summary of the EPD from the data source.")]
        string Description { get; set; }

        [Description("Description of the material's treatment after its useful life.")]
        string EndOfLifeTreatment { get; set; }

        [Description("Eutrophication, measured in kg N equivalents, refers to emissions of nutrients like nitrogen and phosphorus causing overfertilization, leading to overgrowth of biomass that depresses oxygen levels and suffocates ecosystems.")]
        double EutrophicationPotential { get; set; }

        [Description("Exported Electrical Energy or EEE measured in MJ.")]
        double ExportedElectricalEnergy { get; set; }

        [Description("Exported Thermal Energy or EET measured in MJ.")]
        double ExportedThermalEnergy { get; set; }

        [Description("Use of freshwater resources measured in m^3.")]
        double FreshWater { get; set; }

        [Description("Global Warming Potential, expressed in kgCO2e, refers to the emissions of carbon dioxide, methane and other gases that contribute to the greenhouse effect and global warming.")]
        double GlobalWarmingPotential { get; set; }

        [Description("Hazardous Waste Disposed or HWD measured in kg.")]
        double HazardousWasteDisposed { get; set; }

        [Description("Unique identifier of the EPD from the source of the information.")]
        string Id { get; set; }

        [Description("Phase abbreviation for the scope of the EPD. For single phase entries, please input the relevant phase of evaluation i.e. A1 or A1-A3. More information on typical LCA phases can be found in the repository wiki.")]
        string LifeCycleAssessmentPhase { get; set; }

        [Description("The period of useful life of the product measured in years.")]
        int Lifespan { get; set; }

        [Description("Manufacturer name.")]
        string Manufacturer { get; set; }

        [Description("MasterFormat code for material type organisation.")]
        string MasterFormat { get; set; }

        [Description("Material For Energy Recovery or MFR measured in kg.")]
        double MaterialForEnergyRecovery { get; set; }

        [Description("Non-Hazardous Waste Disposed or NHWD measured in kg.")]
        double NonHazardousWasteDisposed { get; set; }

        [Description("Use of Non-renewable Secondary Fuels or NRSF measured in MJ, LHV.")]
        double NonRenewableSecondaryFuels { get; set; }

        [Description("Ozone Depletion Potential, measured in kg CFC-11 equivalents, refers to emissions which contribute to the depletion of the stratospheric ozone layer.")]
        double OzoneDepletionPotential { get; set; }

        [Description("Photochemical Ozone Creation Potential, measured in kgO3 equivalents, refers to emissions which contribute to the formation of ground-level smog.")]
        double PhotochemicalOzoneCreationPotential { get; set; }

        [Description("Manufacturing facility name within which the product was created.")]
        string Plant { get; set; }

        [Description("Postal Code within which the product was created.")]
        int PostalCode { get; set; }

        [Description("Amount of post consumer recycled content measured in kg.")]
        string PostConsumerRecycledContent { get; set; }

        [Description("Use of non-renewable primary energy excluding raw materials measured in megajoules.")]
        double PrimaryEnergyNonRenewableEnergy { get; set; }

        [Description("Primary Energy Non-renewable Resources or PENRT is measured in MJ, LHV.")]
        double PrimaryEnergyNonRenewableResource { get; set; }

        [Description("Use of renewable energy primary energy in megajoules.")]
        double PrimaryEnergyRenewableEnergy { get; set; }

        [Description("Total use of renewable energy resources required to produce a product, measured in megajoules.")]
        double PrimaryEnergyRenewableTotal { get; set; }

        [Description("Primary Energy Resources used as raw materials measured in megajoules.")]
        double PrimaryEnergyResourcesRawMaterials { get; set; }

        [Description("Radioactive Waste Disposed measured in kg.")]
        double RadioActiveWasteDisposed { get; set; }

        [Description("Year in which the EPD was created.")]
        int ReferenceYear { get; set; }

        [Description("Use of Renewable Secondary fuels measured in megajoules.")]
        double RenewableSecondaryFuels { get; set; }

        [Description("Use of secondary materials measured in kg.")]
        double SecondaryMaterial { get; set; }

        [Description("Note that any EPD that does not contain this parameter will not be evaluated." +
            "This metric is based on the declared unit of the reference EPD, i.e. a declared unit of kg refers to QuantityType of mass, a declared unit of m3 refers to a QuantityType of volume, etc. " +
            "All data should be normalized to metric declared units before integration in the BHoM. " +
            "The quantity type is a key metric for evaluation methods to function. " +
            "This property determines how the material is to be evaluated, based on Mass, Volume, Area, Item, or Length. ")]
        QuantityType QuantityType { get; set; }

        [Description("The number of units in reference to quantity type. Example, 1000 kg per unit quantityType of Mass.")]
        double QuantityTypeValue { get; set; }

        /***************************************************/
    }
}
