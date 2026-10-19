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
using System.ComponentModel;

namespace BH.oM.Classification.Project
{
    [Description("The stage of a project, using the RIBA Plan of Work 2020 stages 0-7. The stages are UK-centric; use the closest equivalent where another stage model is in use.")]
    public enum ProjectStage
    {
        Undefined,
        [DisplayText("Strategic definition (RIBA 0)")]
        StrategicDefinition,
        [DisplayText("Preparation & brief (RIBA 1)")]
        PreparationAndBrief,
        [DisplayText("Concept design (RIBA 2)")]
        ConceptDesign,
        [DisplayText("Developed design (RIBA 3)")]
        DevelopedDesign,
        [DisplayText("Technical design (RIBA 4)")]
        TechnicalDesign,
        [DisplayText("Construction (RIBA 5)")]
        Construction,
        [DisplayText("Handover & closeOut (RIBA 6)")]
        HandoverAndCloseOut,
        [DisplayText("In use (RIBA 7)")]
        InUse,
    }
}
