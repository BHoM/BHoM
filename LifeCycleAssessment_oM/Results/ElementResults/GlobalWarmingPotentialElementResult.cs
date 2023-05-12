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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BH.oM.Quantities.Attributes;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Result class for resulting Global Warming potential for a particular Element.")]
    public class GlobalWarmingPotentialElementResult : ElementResult<GlobalWarmingPotentialMaterialResult>, IGlobalWarmingPotentialResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Enum indicating the metric type the object relates to.")]
        public override EnvironmentalMetrics MetricType { get; } = EnvironmentalMetrics.GlobalWarmingPotential;

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the Raw materials in the product stage.")]
        public override double A1 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the Transport in the product stage.")]
        public override double A2 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the Manufacturing in the product stage.")]
        public override double A3 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the full product stage.")]
        public override double A1toA3 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the transport during the assembly stage.")]
        public override double A4 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the final assembly during the assembly stage.")]
        public override double A5 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the general use during the usage stage.")]
        public override double B1 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the maintance during the usage stage.")]
        public override double B2 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the repair during the usage stage.")]
        public override double B3 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the replacement during the usage stage.")]
        public override double B4 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the refurbishment during the usage stage.")]
        public override double B5 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the operational energy use during the usage stage.")]
        public override double B6 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the operational water use during the usage stage.")]
        public override double B7 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the deconstruction and/or demolition during the end of life stage.")]
        public override double C1 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the transport during the end of life stage.")]
        public override double C2 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the waste processing during the end of life stage.")]
        public override double C3 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the disposal during the end of life stage.")]
        public override double C4 { get; protected set; }

        [GlobalWarmingPotential]
        [Description("Resulting Global Warming Potential due to the stage beyond the system boundary.")]
        public override double D { get; protected set; }

        [GlobalWarmingPotential]
        [Description("")]
        public virtual double BiogenicCarbon { get; protected set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GlobalWarmingPotentialElementResult(
            IComparable objectId, 
            ScopeType scope, 
            ObjectCategory category, 
            IReadOnlyList<GlobalWarmingPotentialMaterialResult> materialResults,

            double a1,
            double a2,
            double a3,
            double a1toa3,
            double a4,
            double a5,
            double b1,
            double b2,
            double b3,
            double b4,
            double b5,
            double b6,
            double b7,
            double c1,
            double c2,
            double c3,
            double c4,
            double d,
            double biogenicCarbon
            ) : base(objectId, scope, category, materialResults)
        {
            A1 = a1;
            A2 = a2;
            A3 = a3;
            A1toA3 = a1toa3;
            A4 = a4;
            A5 = a5;
            B1 = b1;
            B2 = b2;
            B3 = b3;
            B4 = b4;
            B5 = b5;
            B6 = b6;
            B7 = b7;
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            D = d;
            BiogenicCarbon = biogenicCarbon;
        }

        /***************************************************/
    }
}
