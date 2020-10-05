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

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    public class SectorEnvironmentalProductDeclaration : BHoMObject, IEnvironmentalProductDeclarationData
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The consequence of acids being emitted to the atmosphere and subsequently deposited in surface soils and waters measured in kg/SO2e.")]
        public virtual double AcidificationPotential { get; set; } = double.NaN;

        [Description("Amount of the material that comes from a biological source (trees, soil), these materials have the ability sequester/store carbon.")]
        public virtual double BiogenicEmbodiedCarbon { get; set; } = double.NaN;

        [Description("The material density in kg/m^3.")]
        public virtual double Density { get; set; } = 0;

        [Description("The amount of depletion of non-renewable material resources measured in Sb (Antimony).")]
        public virtual double DepletionOfAbioticResources { get; set; } = double.NaN;

        [Description("The amount of depletion of non-renewable, fossil fuel material resources measured in kg/MJ.")]
        public virtual double DepletionOfAbioticResourcesFossilFuels { get; set; } = double.NaN;

        [Description("Brief summary of the EPD from the data source.")]
        public virtual string Description { get; set; } = "";

        [Description("Description of the material's treatment after its useful life.")]
        public virtual string EndOfLifeTreatment { get; set; } = "";

        [Description("The pollution state of aquatic ecosystems in which the over-fertilization of water and soil has turned into an increased growth of biomass measured in kg/PO4e.")]
        public virtual double EutrophicationPotential { get; set; } = double.NaN;

        [Description("Exported Electrical Energy or EEE measured in MJ.")]
        public virtual double ExportedElectricalEnergy { get; set; } = double.NaN;

        [Description("Exported Thermal Energy or EET measured in MJ.")]
        public virtual double ExportedThermalEnergy { get; set; } = double.NaN;

        [Description("Use of freshwater resources measured in m3.")]
        public virtual double FreshWater { get; set; } = double.NaN;

        [Description("How much heat a greenhouse gas traps in the atmosphere up to a specific time horizon, relative to carbon dioxide measured in kg/CO2e.")]
        public virtual double GlobalWarmingPotential { get; set; } = double.NaN;

        [Description("Hazardous Waste Disposed or HWD measured in kg.")]
        public virtual double HazardousWasteDisposed { get; set; } = double.NaN;

        [Description("Unique identifier of the EPD from the source of the information.")]
        public virtual string Id { get; set; } = "";

        [Description("Industry Standards referenced in creating the product.")]
        public virtual List<string> IndustryStandards { get; set; } = new List<string>();

        [Description("Jurisdiction within which the sector based product EPD originates.")]
        public virtual List<string> Jurisdiction { get; set; } = new List<string>();

        [Description("Phase abreviation for the scope of the EPD. For single phase entries, please input the relevant phase of evaluation i.e. A1 or A1-A3. More information on typical LCA phases can be found in the repository wiki.")]
        public virtual string LifeCycleAssessmentPhase { get; set; } = "Undefined";

        [Description("The period of existence or duration for the product measured in whole years.")]
        public virtual int Lifespan { get; set; }

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

        [Description("The relative amount of degradation to the ozone layer measured in kg/CFC-11e.")]
        public virtual double OzoneDepletionPotential { get; set; } = double.NaN;

        [Description("The relative abilities of volatile organic compounds (VOCs) to produce ground level ozone (or Ethene) measured in kg/O3e.")]
        public virtual double PhotochemicalOzoneCreationPotential { get; set; } = double.NaN;

        [Description("Plant within which the product was created.")]
        public virtual string Plant { get; set; } = "";

        [Description("Postal Code within which the product was created.")]
        public virtual int PostalCode { get; set; } = 0;

        [Description("Amount of post consumer recycled content measured in kg.")]
        public virtual string PostConsumerRecycledContent { get; set; } = "";

        [Description("Use of non-renewable primary energy excluding raw materials or PENRE measured in MJ, LHV.")]
        public virtual double PrimaryEnergyNonRenewableEnergy { get; set; } = double.NaN;

        [Description("Primary Energy Non-renewable Resources or PENRT is measured in MJ, LHV.")]
        public virtual double PrimaryEnergyNonRenewableResource { get; set; } = double.NaN;

        [Description("Primary Energy Renewable-Energy or PERE, is specified in MJ and calculated fro mthe lower calorific value of the energy resources deployed.")]
        public virtual double PrimaryEnergyRenewableEnergy { get; set; } = double.NaN;

        [Description("Primary Energy Renewable Total or PERT is the total energy resources required to produce a product.")]
        public virtual double PrimaryEnergyRenewableTotal { get; set; } = double.NaN;

        [Description("Primary Energy Resources used as Raw Materials or PERM measured in MJ.")]
        public virtual double PrimaryEnergyResourcesRawMaterials { get; set; } = double.NaN;

        [Description("Publisher responsible for recording and presenting all sector EPD information.")]
        public virtual List<string> Publisher { get; set; } = new List<string>();

        [Description("Radioactive Waste Disposed or RWD measured in kg.")]
        public virtual double RadioActiveWasteDisposed { get; set; } = double.NaN;

        [Description("Year in which the EPD was created.")]
        public virtual int ReferenceYear { get; set; } = 0;

        [Description("Use of Renewable Secondary Fuels or RSF measured in MJ, LHV.")]
        public virtual double RenewableSecondaryFuels { get; set; } = double.NaN;

        [Description("List the construction scope of the product. Examples include Structures, Foundations, or Enclosures.")]
        public virtual string Scope { get; set; } = "";

        [Description("Use of Secondary Material or SM measured in MJ, LHV.")]
        public virtual double SecondaryMaterial { get; set; } = double.NaN;

        [Description("Key metric for evaluation methods to function. This property determines how the material is to be evaluated, based on Mass, Volume, Area, Item, or Length. Note that any EPD that does not contain this parameter will not be evaluated.")]
        public virtual QuantityType QuantityType { get; set; } = QuantityType.Undefined;
        /***************************************************/
    }
}