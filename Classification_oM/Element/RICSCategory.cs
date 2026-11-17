/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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
using BH.oM.Base.Attributes.Enums;
using BH.oM.Classification.Attributes;
using System.ComponentModel;

namespace BH.oM.Classification.Element
{
    [Description("A building element category from the RICS Whole Life Carbon Assessment standard, version 2 (2023), which breaks a building down into the elements that carbon is reported against. The categories are hierarchical: each member carries its code (for example 2.1.2) and the reporting stage it belongs to (1 concept, 2 planning, 3 post-completion, or 0 for a grouping that is not itself selectable) as attributes, and a detailed category rolls up into the coarser ones whose code it starts with. Members are named after their code, with the dots replaced by underscores.")]
    [DocumentationURL("https://www.rics.org/profession-standards/rics-standards-and-guidance/sector-standards/construction-standards/whole-life-carbon-assessment", DocumentationType.Documentation, "RICS Whole Life Carbon Assessment standard, version 2 (2023): the source of these categories. Its supporting building element categories spreadsheet outlines the categories defined in this enum.")]
    public enum RICSCategory
    {
        Undefined,
        [CategoryCode("0.1")]
        [CategoryLevel(1)]
        [DisplayText("0.1 Treatment, demolition and facilitating works")]
        _0_1,
        [CategoryCode("0.1.1")]
        [CategoryLevel(2)]
        [DisplayText("0.1.1 Toxic/contaminated material treatment, Demolition works")]
        _0_1_1,
        [CategoryCode("0.1.1.1")]
        [CategoryLevel(3)]
        [DisplayText("0.1.1.1 Toxic/contaminated material treatment")]
        _0_1_1_1,
        [CategoryCode("0.1.1.2")]
        [CategoryLevel(3)]
        [DisplayText("0.1.1.2 Demolition works")]
        _0_1_1_2,
        [CategoryCode("0.1.2")]
        [CategoryLevel(2)]
        [DisplayText("0.1.2 Facilitating works")]
        _0_1_2,
        [CategoryCode("0.1.2.1")]
        [CategoryLevel(3)]
        [DisplayText("0.1.2.1 Temporary supports")]
        _0_1_2_1,
        [CategoryCode("0.1.2.2")]
        [CategoryLevel(3)]
        [DisplayText("0.1.2.2 Facade retention")]
        _0_1_2_2,
        [CategoryCode("0.1.2.3")]
        [CategoryLevel(3)]
        [DisplayText("0.1.2.3 Specialist groundworks")]
        _0_1_2_3,
        [CategoryCode("0.1.2.4")]
        [CategoryLevel(3)]
        [DisplayText("0.1.2.4 Temporary diversion works")]
        _0_1_2_4,
        [CategoryCode("0.1.2.5")]
        [CategoryLevel(3)]
        [DisplayText("0.1.2.5 Extraordinary site investigations")]
        _0_1_2_5,
        [CategoryCode("0.1.2.6")]
        [CategoryLevel(3)]
        [DisplayText("0.1.2.6 Site preparation works")]
        _0_1_2_6,
        [CategoryCode("1")]
        [CategoryLevel(1)]
        [DisplayText("1 Sub-structure")]
        _1,
        [CategoryCode("1.1")]
        [CategoryLevel(2)]
        [DisplayText("1.1 Foundations and piling")]
        _1_1,
        [CategoryCode("1.2")]
        [CategoryLevel(2)]
        [DisplayText("1.2 Basement retaining walls and lowest slab")]
        _1_2,
        [CategoryCode("1.2.1")]
        [CategoryLevel(3)]
        [DisplayText("1.2.1 Lowest slab")]
        _1_2_1,
        [CategoryCode("1.2.2")]
        [CategoryLevel(3)]
        [DisplayText("1.2.2 Suspended slabs")]
        _1_2_2,
        [CategoryCode("1.2.3")]
        [CategoryLevel(3)]
        [DisplayText("1.2.3 Basement retaining walls")]
        _1_2_3,
        [CategoryCode("2")]
        [CategoryLevel(1)]
        [DisplayText("2 Superstructure")]
        _2,
        [CategoryCode("2.1")]
        [CategoryLevel(2)]
        [DisplayText("2.1 Frame")]
        _2_1,
        [CategoryCode("2.1.1")]
        [CategoryLevel(3)]
        [DisplayText("2.1.1 Frame (vertical) - columns/ structural walls & braces")]
        _2_1_1,
        [CategoryCode("2.1.2")]
        [CategoryLevel(3)]
        [DisplayText("2.1.2 Frame (Horizontal) - beams, joists & braces")]
        _2_1_2,
        [CategoryCode("2.2")]
        [CategoryLevel(2)]
        [DisplayText("2.2 Upper floors")]
        _2_2,
        [CategoryCode("2.2.1")]
        [CategoryLevel(3)]
        [DisplayText("2.2.1 Upper floor and roof - structural slabs")]
        _2_2_1,
        [CategoryCode("2.2.2")]
        [CategoryLevel(3)]
        [DisplayText("2.2.2 Upper floor and roof - non-structural slabs")]
        _2_2_2,
        [CategoryCode("2.3")]
        [CategoryLevel(2)]
        [DisplayText("2.3 Roof")]
        _2_3,
        [CategoryCode("2.4")]
        [CategoryLevel(2)]
        [DisplayText("2.4 Stairs, ramps and safety guarding")]
        _2_4,
        [CategoryCode("2.4.1")]
        [CategoryLevel(3)]
        [DisplayText("2.4.1 Stairs")]
        _2_4_1,
        [CategoryCode("2.4.2")]
        [CategoryLevel(3)]
        [DisplayText("2.4.2 Ramps")]
        _2_4_2,
        [CategoryCode("2.4.3")]
        [CategoryLevel(3)]
        [DisplayText("2.4.3 Safety and access ladders, chutes, slides and guarding")]
        _2_4_3,
        [CategoryCode("2.5")]
        [CategoryLevel(2)]
        [DisplayText("2.5 External envelope including roof finishes")]
        _2_5,
        [CategoryCode("2.5.1")]
        [CategoryLevel(3)]
        [DisplayText("2.5.1 External - opaque envelope")]
        _2_5_1,
        [CategoryCode("2.5.2")]
        [CategoryLevel(3)]
        [DisplayText("2.5.2 External - full height glazing systems")]
        _2_5_2,
        [CategoryCode("2.5.3")]
        [CategoryLevel(3)]
        [DisplayText("2.5.3 External - roof finishes/coverings")]
        _2_5_3,
        [CategoryCode("2.5.4")]
        [CategoryLevel(3)]
        [DisplayText("2.5.4 External - safety systems")]
        _2_5_4,
        [CategoryCode("2.6")]
        [CategoryLevel(2)]
        [DisplayText("2.6 Windows and ext doors")]
        _2_6,
        [CategoryCode("2.6.1")]
        [CategoryLevel(3)]
        [DisplayText("2.6.1 Windows - vertical")]
        _2_6_1,
        [CategoryCode("2.6.2")]
        [CategoryLevel(3)]
        [DisplayText("2.6.2 Windows - roof or horizontal")]
        _2_6_2,
        [CategoryCode("2.6.3")]
        [CategoryLevel(3)]
        [DisplayText("2.6.3 External doors")]
        _2_6_3,
        [CategoryCode("2.7")]
        [CategoryLevel(2)]
        [DisplayText("2.7 Internal walls")]
        _2_7,
        [CategoryCode("2.7.1")]
        [CategoryLevel(3)]
        [DisplayText("2.7.1 Internal walls - solid")]
        _2_7_1,
        [CategoryCode("2.7.2")]
        [CategoryLevel(3)]
        [DisplayText("2.7.2 Internal walls - non-structural glazed walls, windows and vision panels")]
        _2_7_2,
        [CategoryCode("2.8")]
        [CategoryLevel(2)]
        [DisplayText("2.8 Internal doors")]
        _2_8,
        [CategoryCode("3")]
        [CategoryLevel(1)]
        [DisplayText("3 Finishes")]
        _3,
        [CategoryCode("3.1")]
        [CategoryLevel(2)]
        [DisplayText("3.1 Wall finishes")]
        _3_1,
        [CategoryCode("3.2")]
        [CategoryLevel(2)]
        [DisplayText("3.2 Floor finishes")]
        _3_2,
        [CategoryCode("3.2.1")]
        [CategoryLevel(3)]
        [DisplayText("3.2.1 Raised access floor or specialist sprung floors")]
        _3_2_1,
        [CategoryCode("3.2.2")]
        [CategoryLevel(3)]
        [DisplayText("3.2.2 Non-structural screed")]
        _3_2_2,
        [CategoryCode("3.2.3")]
        [CategoryLevel(3)]
        [DisplayText("3.2.3 Floor finishes")]
        _3_2_3,
        [CategoryCode("3.3")]
        [CategoryLevel(2)]
        [DisplayText("3.3 Ceiling finishes")]
        _3_3,
        [CategoryCode("4")]
        [CategoryLevel(1)]
        [DisplayText("4 FF&E")]
        _4,
        [CategoryCode("4.1")]
        [CategoryLevel(3)]
        [DisplayText("4.1 General FF&E")]
        _4_1,
        [CategoryCode("4.2")]
        [CategoryLevel(3)]
        [DisplayText("4.2 Kitchen equipment")]
        _4_2,
        [CategoryCode("4.3")]
        [CategoryLevel(3)]
        [DisplayText("4.3 Special equipment")]
        _4_3,
        [CategoryCode("4.4")]
        [CategoryLevel(3)]
        [DisplayText("4.4 Loose FF&E")]
        _4_4,
        [CategoryCode("4.5")]
        [CategoryLevel(3)]
        [DisplayText("4.5 IT")]
        _4_5,
        [CategoryCode("4.6")]
        [CategoryLevel(3)]
        [DisplayText("4.6 Audio and visual")]
        _4_6,
        [CategoryCode("5")]
        [CategoryLevel(0)]
        [DisplayText("5 Services")]
        _5,
        [CategoryCode("5.1")]
        [CategoryLevel(1)]
        [DisplayText("5.1 Public Health")]
        _5_1,
        [CategoryCode("5.1.1")]
        [CategoryLevel(2)]
        [DisplayText("5.1.1 Sanitaryware")]
        _5_1_1,
        [CategoryCode("5.1.2")]
        [CategoryLevel(2)]
        [DisplayText("5.1.2 Cold water systems")]
        _5_1_2,
        [CategoryCode("5.1.2.1")]
        [CategoryLevel(3)]
        [DisplayText("5.1.2.1 Cold water systems")]
        _5_1_2_1,
        [CategoryCode("5.1.2.2")]
        [CategoryLevel(3)]
        [DisplayText("5.1.2.2 Cold water storage")]
        _5_1_2_2,
        [CategoryCode("5.1.3")]
        [CategoryLevel(2)]
        [DisplayText("5.1.3 Drainage and rainwater")]
        _5_1_3,
        [CategoryCode("5.1.3.1")]
        [CategoryLevel(3)]
        [DisplayText("5.1.3.1 Surface water/rainwater/foul water drainage")]
        _5_1_3_1,
        [CategoryCode("5.1.3.2")]
        [CategoryLevel(3)]
        [DisplayText("5.1.3.2 Water reuse systems")]
        _5_1_3_2,
        [CategoryCode("5.2")]
        [CategoryLevel(1)]
        [DisplayText("5.2 Heating, Ventilation and Cooling (HVAC)")]
        _5_2,
        [CategoryCode("5.2.1")]
        [CategoryLevel(2)]
        [DisplayText("5.2.1 Space heating and hot water")]
        _5_2_1,
        [CategoryCode("5.2.1.1")]
        [CategoryLevel(3)]
        [DisplayText("5.2.1.1 Heat & Hot water generation equipment")]
        _5_2_1_1,
        [CategoryCode("5.2.1.2")]
        [CategoryLevel(3)]
        [DisplayText("5.2.1.2 Heat & hot water distribution, control, ancillaries, emitters, exchangers/terminal units")]
        _5_2_1_2,
        [CategoryCode("5.2.1.3")]
        [CategoryLevel(3)]
        [DisplayText("5.2.1.3 Heat storage equipment")]
        _5_2_1_3,
        [CategoryCode("5.2.2")]
        [CategoryLevel(2)]
        [DisplayText("5.2.2 Dedicated cooling installations")]
        [Description("If the system does both heating and cooling, include it in heating (5.2.1).")]
        _5_2_2,
        [CategoryCode("5.2.2.1")]
        [CategoryLevel(3)]
        [DisplayText("5.2.2.1 Cooling generation equipment")]
        _5_2_2_1,
        [CategoryCode("5.2.2.2")]
        [CategoryLevel(3)]
        [DisplayText("5.2.2.2 Cooling emitter, exchangers/ terminal units, ancillaries and control, distribution, storage")]
        _5_2_2_2,
        [CategoryCode("5.2.3")]
        [CategoryLevel(2)]
        [DisplayText("5.2.3 Air movement")]
        _5_2_3,
        [CategoryCode("5.2.4")]
        [CategoryLevel(2)]
        [DisplayText("5.2.4 Ventilation air terminals, ductwork and ancillaries, control dampers, attenuation, fire safety related to ventilation equipment")]
        _5_2_4,
        [CategoryCode("5.2.4.1")]
        [CategoryLevel(3)]
        [DisplayText("5.2.4.1 Air terminals")]
        _5_2_4_1,
        [CategoryCode("5.2.4.2")]
        [CategoryLevel(3)]
        [DisplayText("5.2.4.2 Ductwork & ancillaries")]
        _5_2_4_2,
        [CategoryCode("5.2.4.3")]
        [CategoryLevel(3)]
        [DisplayText("5.2.4.3 Control dampers, attenuation and fIre safety related to ventilation equipment")]
        _5_2_4_3,
        [CategoryCode("5.3")]
        [CategoryLevel(1)]
        [DisplayText("5.3 Electrical installations")]
        _5_3,
        [CategoryCode("5.3.1")]
        [CategoryLevel(2)]
        [DisplayText("5.3.1 Lighting")]
        _5_3_1,
        [CategoryCode("5.3.1.1")]
        [CategoryLevel(3)]
        [DisplayText("5.3.1.1 Internal lighting")]
        _5_3_1_1,
        [CategoryCode("5.3.1.2")]
        [CategoryLevel(3)]
        [DisplayText("5.3.1.2 External lighting (building mounted)")]
        _5_3_1_2,
        [CategoryCode("5.3.1.3")]
        [CategoryLevel(3)]
        [DisplayText("5.3.1.3 Emergency lighting")]
        _5_3_1_3,
        [CategoryCode("5.3.1.4")]
        [CategoryLevel(3)]
        [DisplayText("5.3.1.4 Other lighting")]
        _5_3_1_4,
        [CategoryCode("5.3.2")]
        [CategoryLevel(2)]
        [DisplayText("5.3.2 Electrical services for power, communications, security, IT and fire detection")]
        _5_3_2,
        [CategoryCode("5.3.2.1")]
        [CategoryLevel(3)]
        [DisplayText("5.3.2.1 Electrical power")]
        _5_3_2_1,
        [CategoryCode("5.3.2.2")]
        [CategoryLevel(3)]
        [DisplayText("5.3.2.2 ELV/ Communications/Security")]
        _5_3_2_2,
        [CategoryCode("5.3.2.3")]
        [CategoryLevel(3)]
        [DisplayText("5.3.2.3 IT & Data")]
        _5_3_2_3,
        [CategoryCode("5.3.2.4")]
        [CategoryLevel(3)]
        [DisplayText("5.3.2.4 BMS")]
        _5_3_2_4,
        [CategoryCode("5.3.2.5")]
        [CategoryLevel(3)]
        [DisplayText("5.3.2.5 Electricity back up generation")]
        _5_3_2_5,
        [CategoryCode("5.3.2.6")]
        [CategoryLevel(3)]
        [DisplayText("5.3.2.6 Fire detection & alarm")]
        _5_3_2_6,
        [CategoryCode("5.4")]
        [CategoryLevel(1)]
        [DisplayText("5.4 On site renewable energy generation")]
        _5_4,
        [CategoryCode("5.4.1")]
        [CategoryLevel(2)]
        [DisplayText("5.4.1 On site renewable energy generation")]
        _5_4_1,
        [CategoryCode("5.4.1.1")]
        [CategoryLevel(3)]
        [DisplayText("5.4.1.1 Renewable energy - electrical generation onsite and building mounted")]
        _5_4_1_1,
        [CategoryCode("5.4.1.2")]
        [CategoryLevel(3)]
        [DisplayText("5.4.1.2 Renewable energy - storage onsite")]
        _5_4_1_2,
        [CategoryCode("5.5")]
        [CategoryLevel(1)]
        [DisplayText("5.5 Systems including Life safety, Fuel installations, Lift and conveyor installations, Services equipment, Disposal installations, Specialist installations, Builders work in connection with services")]
        _5_5,
        [CategoryCode("5.5.1")]
        [CategoryLevel(2)]
        [DisplayText("5.5.1 Life safety")]
        _5_5_1,
        [CategoryCode("5.5.1.1")]
        [CategoryLevel(3)]
        [DisplayText("5.5.1.1 Sprinkler system")]
        _5_5_1_1,
        [CategoryCode("5.5.1.2")]
        [CategoryLevel(3)]
        [DisplayText("5.5.1.2 Fire fighting systems")]
        _5_5_1_2,
        [CategoryCode("5.5.1.3")]
        [CategoryLevel(3)]
        [DisplayText("5.5.1.3 Lightning protection/earth bonding")]
        _5_5_1_3,
        [CategoryCode("5.5.2")]
        [CategoryLevel(2)]
        [DisplayText("5.5.2 Fuel installations")]
        _5_5_2,
        [CategoryCode("5.5.3")]
        [CategoryLevel(2)]
        [DisplayText("5.5.3 Lift and conveyor installations")]
        _5_5_3,
        [CategoryCode("5.5.3.2")]
        [CategoryLevel(3)]
        [DisplayText("5.5.3.2 Lift, stair lift, lifting platform")]
        _5_5_3_2,
        [CategoryCode("5.5.3.3")]
        [CategoryLevel(3)]
        [DisplayText("5.5.3.3 Escalators and moving walkways")]
        _5_5_3_3,
        [CategoryCode("5.5.4")]
        [CategoryLevel(2)]
        [DisplayText("5.5.4 Specialised and communal waste disposal")]
        _5_5_4,
        [CategoryCode("5.5.5")]
        [CategoryLevel(2)]
        [DisplayText("5.5.5 Specialist installations & maintenance")]
        _5_5_5,
        [CategoryCode("5.5.6")]
        [CategoryLevel(2)]
        [DisplayText("5.5.6 Builders work in connection with services")]
        _5_5_6,
        [CategoryCode("6")]
        [CategoryLevel(1)]
        [DisplayText("6 Pre-fabricated buildings and building units")]
        _6,
        [CategoryCode("7")]
        [CategoryLevel(1)]
        [DisplayText("7 Works to existing buildings")]
        _7,
        [CategoryCode("7.1")]
        [CategoryLevel(3)]
        [DisplayText("7.1 Alterations")]
        _7_1,
        [CategoryCode("7.2")]
        [CategoryLevel(3)]
        [DisplayText("7.2 Repairs to existing , Cleaning existing surfaces, General Renovation works")]
        _7_2,
        [CategoryCode("7.3")]
        [CategoryLevel(3)]
        [DisplayText("7.3 Damp-proof courses/fungus and beetle eradication")]
        _7_3,
        [CategoryCode("8")]
        [CategoryLevel(1)]
        [DisplayText("8 External work")]
        _8,
        [CategoryCode("8.1")]
        [CategoryLevel(2)]
        [DisplayText("8.1 Roads, paths, pavings, surfaces, Fencing, railings, walls, External fixtures")]
        _8_1,
        [CategoryCode("8.1.1")]
        [CategoryLevel(3)]
        [DisplayText("8.1.1 Roads, paths, pavings, surfaces")]
        _8_1_1,
        [CategoryCode("8.1.2")]
        [CategoryLevel(3)]
        [DisplayText("8.1.2 Fencing, railings, walls")]
        _8_1_2,
        [CategoryCode("8.1.3")]
        [CategoryLevel(3)]
        [DisplayText("8.1.3 External fixtures")]
        _8_1_3,
        [CategoryCode("8.2")]
        [CategoryLevel(2)]
        [DisplayText("8.2 Soft landscape, planting, irrigation")]
        _8_2,
        [CategoryCode("8.3")]
        [CategoryLevel(2)]
        [DisplayText("8.3 External drainage, External services, Minor building works")]
        _8_3,
        [CategoryCode("8.3.1")]
        [CategoryLevel(3)]
        [DisplayText("8.3.1 External drainage")]
        _8_3_1,
        [CategoryCode("8.3.2")]
        [CategoryLevel(3)]
        [DisplayText("8.3.2 External services")]
        _8_3_2,
        [CategoryCode("8.3.3")]
        [CategoryLevel(3)]
        [DisplayText("8.3.3 Minor building works, ancillary")]
        _8_3_3,
        [CategoryCode("9")]
        [CategoryLevel(1)]
        [DisplayText("9 Others")]
        _9,
    }
}
