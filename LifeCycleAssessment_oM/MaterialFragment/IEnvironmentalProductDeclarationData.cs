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
using BH.oM.Physical.Materials;
using BH.oM.Base;
using System.ComponentModel;
using System.Dynamic;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    public interface IEnvironmentalProductDeclarationData : IFragment, IMaterialProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The consequence of acids being emitted to the atmosphere and subsequently deposited in surface soils and waters measured in kg/SO2e.")]
        double AcidificationPotential { get; set; }

        [Description("Amount of the material that comes from a biological source (trees, soil), these materials have the ability sequester/store carbon.")]
        double BiogenicEmbodiedCarbon { get; set; }

        [Description("The material density in kg/m^3.")]
        double Density { get; set; }

        [Description("The amount of depletion of non-renewable material resources measured in Sb (Antimony).")]
        double DepletionOfAbioticResources { get; set; }

        [Description("The amount of depletion of non-renewable, fossil fuel material resources measured in kg/MJ.")]
        double DepletionOfAbioticResourcesFossilFuels { get; set; }

        [Description("Brief summary of the EPD from the data source.")]
        string Description { get; set; }

        [Description("Description of the material's treatment after its useful life.")]
        string EndOfLifeTreatment { get; set; }

        [Description("The pollution state of aquatic ecosystems in which the over-fertilization of water and soil has turned into an increased growth of biomass measured in kg/PO4e.")]
        double EutrophicationPotential { get; set; }

        [Description("Exported Electrical Energy or EEE measured in MJ.")]
        double ExportedElectricalEnergy { get; set; }

        [Description("Exported Thermal Energy or EET measured in MJ.")]
        double ExportedThermalEnergy { get; set; }

        [Description("Use of freshwater resources measured in m3.")]
        double FreshWater { get; set; }

        [Description("How much heat a greenhouse gas traps in the atmosphere up to a specific time horizon, relative to carbon dioxide measured in kg/CO2e.")]
        double GlobalWarmingPotential { get; set; }

        [Description("Hazardous Waste Disposed or HWD measured in kg.")]
        double HazardousWasteDisposed { get; set; }

        [Description("Unique identifier of the EPD from the source of the information.")]
        string Id { get; set; }

        [Description("Phase abreviation for the scope of the EPD. For single phase entries, please input the relevant phase of evaluation i.e. A1 or A1-A3. More information on typical LCA phases can be found in the repository wiki.")]
        string LifeCycleAssessmentPhase { get; set; }

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

        [Description("The relative amount of degradation to the ozone layer measured in kg/CFC-11e.")]
        double OzoneDepletionPotential { get; set; }

        [Description("The relative abilities of volatile organic compounds (VOCs) to produce ground level ozone (or Ethene) measured in kg/O3e.")]
        double PhotochemicalOzoneCreationPotential { get; set; }

        [Description("Plant within which the product was created.")]
        string Plant { get; set; }

        [Description("Postal Code within which the product was created.")]
        int PostalCode { get; set; }

        [Description("Amount of post consumer recycled content measured in kg.")]
        string PostConsumerRecycledContent { get; set; }

        [Description("Use of non-renewable primary energy excluding raw materials or PENRE measured in MJ, LHV.")]
        double PrimaryEnergyNonRenewableEnergy { get; set; }

        [Description("Primary Energy Non-renewable Resources or PENRT is measured in MJ, LHV.")]
        double PrimaryEnergyNonRenewableResource { get; set; }

        [Description("Primary Energy Renewable-Energy or PERE, is specified in MJ and calculated fro mthe lower calorific value of the energy resources deployed.")]
        double PrimaryEnergyRenewableEnergy { get; set; }

        [Description("Primary Energy Renewable Total or PERT is the total energy resources required to produce a product.")]
        double PrimaryEnergyRenewableTotal { get; set; }

        [Description("Primary Energy Resources used as Raw Materials or PERM measured in MJ.")]
        double PrimaryEnergyResourcesRawMaterials { get; set; }

        [Description("Radioactive Waste Disposed or RWD measured in kg.")]
        double RadioActiveWasteDisposed { get; set; }

        [Description("Year in which the EPD was created.")]
        int ReferenceYear { get; set; }

        [Description("Use of Renewable Secondary Fuels or RSF measured in MJ, LHV.")]
        double RenewableSecondaryFuels { get; set; }

        [Description("List the construction scope of the product. Examples include Structures, Foundations, or Enclosures.")]
        string Scope { get; set; }

        [Description("Use of Secondary Material or SM measured in MJ, LHV.")]
        double SecondaryMaterial { get; set; }

        [Description("Key metric for evaluation methods to function. This property determines how the material is to be evaluated, based on Mass, Volume, Area, Item, or Length. Note that any EPD that does not contain this parameter will not be evaluated.")]
        QuantityType QuantityType { get; set; }

        /***************************************************/
    }
}