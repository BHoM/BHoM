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

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment
{
    public enum Module
    {
        [Description("Activities in A0 include, but are not limited to, non-physical processes before construction such as preliminary studies, impact assessments, risk assessments, stakeholder engagement, design and technical studies, product/material tests, site surveys and acquisition of land and design.\nThis LCA module is specific to RICS Professional Standard, Whole Life Carbon Assessment for the Built Environment (2023).")]
        A0,
        [Description("The A1 module is part of the A1-A3 product stage and consists of raw material extraction and supply.")]
        A1,
        [Description("The A2 module is part of the A1-A3 product stage and relates to all transport during the product stage.")]
        A2,
        [Description("The A3 module is part of the A1-A3 product stage and relates to all manufacturing during the product stage.")]
        A3,
        [Description("Full Product stage - Sum of modules A1, A2 and A3, including raw material extraction, transport during production and manufacturing.")]
        A1toA3,
        [Description("Module A4 captures the impacts associated with the transportation of the materials and components from the factory gate to and from the project site.")]
        A4,
        [Description("Module A5 captures the carbon impacts arising from any on-site construction-related activities and consists of several sub-modules: A5.1 Pre-construction demolition (if applicable), A5.2 Construction activities, A5.3 Waste and waste management, and A5.4 Worker transport (optional).")]
        A5,
        [Description("Module A5.1 Pre-construction demolition consists of demolition/deconstruction of existing buildings and structures, and/or parts thereof, including transport from site and waste processing of removed materials.")]
        A5_1,
        [Description("Module A5.2 Construction activities consists of site preparation; temporary works; ground works; connection to utilities; transport and onsite storage of construction products, materials and equipment; onsite production/assembly of products; works for the installation and ancillary materials (e.g. formworks and their disposal); heating/cooling/ventilation of site facilities; energy and water use for construction processes and landscaping.")]
        A5_2,
        [Description("Module A5.3 Waste and waste management consists of production, transportation, storage and end-of-life treatment and disposal of any material/waste onsite; transport, waste management and disposal of packing materials.")]
        A5_3,
        [Description("Module A5.4 Worker transport consists of emissions of site workers travelling to and from site.")]
        A5_4,
        [Description("Module B1 captures the non-energy-related impacts during the life of a built asset arising from its components and consists of two sub-modules, B1.1 In-use: material emissions and removals and B1.2 In-use: fugitive emissions (refrigerants).")]
        B1,
        [Description("Module B1.1 In-use: material emissions and removals consists of Release from materials of gases with GWP, e.g. blowing agents from insulation; reabsorption of CO2 into products containing lime and cement through carbonation, and removals from vegetation.")]
        B1_1,
        [Description("Module B1.2 In-use: fugitive emissions (refrigerants) consists of the accidental release of refrigerants with GWP from MEP equipment such as cooling systems and heat pumps.")]
        B1_2,
        [Description("Module B2 Maintenance impacts must account for the carbon impacts from any activities relating to maintenance processes, including cleaning, as well as any relevant products used and waste produced over the reference study period.")]
        B2,
        [Description("Module B3 Repair impacts must take into account carbon impacts from all activities that relate to repair processes, and any products used and waste produced over the reference study period. All impacts from the production, transportation to and from site, and installation of the repaired items must be included.")]
        B3,
        [Description("Use, Maintenance and Repair modules in the Use stage - Sum of modules B1, B2 and B3.")]
        B1toB3,
        [Description("Module B4 Replacement impacts must take into account any carbon impacts associated with the anticipated replacement of built asset components, including any impacts from the replacement process, over the reference study period. All impacts from the production, transportation to site and installation of the replacement items must be included, as well as any losses during these processes, as well as any impacts associated with the removal and end-of-life treatment of replaced items. Module B4 consists of two sub-modules, B4.1 Replacement of construction products, components and systems and B4.2 B4.2 Replacement of industrial systems (if applicable for infrastructure).")]
        B4,
        [Description("Module B4.1 Replacement of construction products, components and systems, consists of replacement, including manufacture, transport and installation of new, like-for-like products, components or systems, as well as the deconstruction and waste treatment of removed products, components and systems.")]
        B4_1,
        [Description("Module B4.2 Replacement of industrial systems (if applicable for infrastructure) consists of replacement of industrial systems, including manufacture, transport and installation of new, like-for-like systems, as well as the deconstruction and waste treatment of removed systems.")]
        B4_2,
        [Description("Module B5 Impacts from retrofit/refurbishment/planned changes consists of All impacts arising from the production, transport to site and installation of the components used for a change or refurbishment planned prior to project completion, but undertaken during the in-use stage.")]
        B5,
        [Description("Replacement and Refurbishment modules in the Use stage - Sum of modules B4 and B5.")]
        B4toB5,
        [Description("Full Use Stage except operational energy and Water use - Sum of modules B1, B2, B3, B4 and B5.")]
        B1toB5,
        [Description("Module B6 Operational energy use consists of carbon emissions from all operational energy use by a building or infrastructure asset over its life cycle.")]
        B6,
        [Description("Module B7 Operational water use consists of the carbon impacts from water use during the operation of the built asset over its life cycle and consists of 3 sub-modules: B7.1 Water used by integrated systems, B7.2 Water used by other integrated systems, and B7.3 Water used by non-integrated systems.")]
        B7,
        [Description("Full Use Stage - Sum of modules B1, B2, B3, B4, B5, B6 and B7.")]
        B1toB7,
        [Description("Module B7.1 Water used by integrated systems consists of Water for sanitation, cooking and drinking; irrigation of associated landscape areas, green roofs and walls; and heating, cooling, ventilation and humidification systems.")]
        B7_1,
        [Description("Module B7.2 Water used by other integrated systems consists of water used by fountains, swimming pools and saunas.")]
        B7_2,
        [Description("Module B7.3 Water used by non-integrated systems consists of water used for dishwashers, washing machines and washing cars.")]
        B7_3,
        [Description("Module B8 User activities in buildings covers impacts associated with user activities taking place during the operation of buildings that are not covered by B1-B7. There are 3 sub-modules to B8 including: B8.1 Energy-related impacts associated with building user mobility/ transport not covered in B6, such as user mobility/ commuting to a building (optional), B8.2 Energy-related impacts associated with building user charging of electric vehicles on-site (optional), and B8.3 Other energy related impacts associated with building user activities relating to the building’s intended use, such as upstream embodied impacts of consumables used in the building, e.g. stationery and printing paper for an office (optional).")]
        B8,
        [Description("Module B8.1 consists of energy-related impacts associated with building user mobility/ transport not covered in B6, such as user mobility/ commuting to a building (optional).")]
        B8_1,
        [Description("Module B8.2 consists of energy-related impacts associated with building user charging of electric vehicles on-site (optional).")]
        B8_2,
        [Description("Module B8.3 consists of other energy related impacts associated with building user activities relating to the building's intended use, such as upstream embodied impacts of consumables used in the building, e.g. stationery and printing paper for an office (optional).")]
        B8_3,
        [Description("Module C1 Deconstruction and demolition impacts consists of the impacts arising from any on- or offsite deconstruction and demolition activities at the end of life of the asset, including any energy consumption for site accommodation and plant use.")]
        C1,
        [Description("Module C2 Transport impacts consists of any carbon impacts associated with the transportation of material from deconstruction and demolition to the appropriate final location, including any interim stations.")]
        C2,
        [Description("Module C3 Waste processing for reuse, recycling or other recovery consists of materials and/or components that are intended to be reused, recycled or recovered after the RSP of the asset, any impacts associated with their preparation for reuse, waste treatment and recovery prior to reaching the end-of-waste state.")]
        C3,
        [Description("Module C4 Disposal impacts consists of impacts resulting from any processing required prior to disposal and from the degradation of landfilled materials, or incineration without energy recovery or in a plant without R1 status (Energy Efficiency Formula standard, according to the Waste Framework Directive, less than 65%). This is only applicable for items not being recovered for reuse, recycling or other recovery.")]
        C4,
        [Description("Waste Processing and disposal modules in the End of Life stage - Sum of Modules C3 and C4.")]
        C3toC4,
        [Description("Full End of Life stage- Sum of Modules C1, C2, C3 and C4.")]
        C1toC4,
        [Description("Module D consists of benefits and loads beyond the system boundary and consists of two sub-modules D1 potential benefits and loads from reuse, recycling and energy recovery from the net output flows of materials exiting the system boundary, and/or from other recovery (e.g. from incineration or from use of captured landfill gas) and D2 potential benefits and loads from exported utilities exiting the system boundary.")]
        D,
        [Description("Module D1 covers the potential loads and benefits from reusing or recycling materials and components at end of life, or from any energy recovered from them at end of life (e.g. energy from waste, incineration or use of captured landfill gas).\nModule D1 is relevant to any end-of-life output from the asset during construction (module A5); maintenance, repair, replacement and refurbishment (modules B2-B5); and from waste treatment and disposal (modules C3 and C4).\nIt also includes loads and benefits associated with the deconstruction/demolition activities of existing assets on the site, assessed in module A5.1. Module D1 must be communicated separately, as it mainly occurs beyond the RSP and outside the system boundary of the project being assessed, and also includes inherent uncertainty regarding the future treatment of building components.")]
        D_1,
        [Description("Module D2 indicates that if a building generates more energy than it uses over the course of the year, this 'exported' energy is reported as part of module B6 for buildings (see Appendix G2).\nFor infrastructure that generates energy or produces other utilities, these are reported as exported utilities as part of B8. For both buildings and infrastructure assets, any benefit from these exported utilities (e.g. the avoided impact of grid electricity generation for exported electricity) is reported in D2.")]
        D_2,
    }
}





