/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Base interface for all envirnmental metrics.")]
    public interface IEnvironmentalMetric : IBHoMObject
    {
        [Description("Metrics relating to the Raw materials in the product stage.")]
        double A1 { get; }

        [Description("Metrics relating to the Transport in the product stage.")]
        double A2 { get; }

        [Description("Metrics relating to the Manufacturing in the product stage.")]
        double A3 { get; }

        [Description("Metrics relating to the full product stage.")]
        double A1toA3 { get; }

        [Description("Metrics relating to the transport during the assembly stage.")]
        double A4 { get; }

        [Description("Metrics relating to the final assembly during the assembly stage.")]
        double A5 { get; }

        [Description("Metrics relating to the general use during the usage stage.")]
        double B1 { get; }

        [Description("Metrics relating to the maintance during the usage stage.")]
        double B2 { get; }

        [Description("Metrics relating to the repair during the usage stage.")]
        double B3 { get; }

        [Description("Metrics relating to the replacement during the usage stage.")]
        double B4 { get; }

        [Description("Metrics relating to the refurbishment during the usage stage.")]
        double B5 { get; }

        [Description("Metrics relating to the operational energy use during the usage stage.")]
        double B6 { get; }

        [Description("Metrics relating to the operational water use during the usage stage.")]
        double B7 { get; }

        [Description("Metrics relating to the deconstruction and/or demolishion during the end of life stage.")]
        double C1 { get; }

        [Description("Metrics relating to the transport during the end of life stage.")]
        double C2 { get; }

        [Description("Metrics relating to the waste processing during the end of life stage.")]
        double C3 { get; }

        [Description("Metrics relating to the disposal during the end of life stage.")]
        double C4 { get; }

        [Description("Metrics relating to the stage beyond the system boundary.")]
        double D { get; }
    }
}
