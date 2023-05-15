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
    [Description("Result class for resulting Acidification Potential for a particular Material and EPD.")]
    public class AcidificationPotentialMaterialResult : MaterialResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Enum indicating the metric type the object relates to.")]
        public override EnvironmentalMetrics MetricType { get; } = EnvironmentalMetrics.AcidificationPotential;

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Raw Material Supply module in the Product stage.")]
        public override double A1 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Transport module in the Product stage.")]
        public override double A2 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Manufacturing module in the Product stage.")]
        public override double A3 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the full product stage.")]
        public override double A1toA3 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Transport module in the Construction Process stage.")]
        public override double A4 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Construction Installation Process module in the Construction Process stage.")]
        public override double A5 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Use module in the Use stage.")]
        public override double B1 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Maintenance module in the Use stage.")]
        public override double B2 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Repair module in the Use stage.")]
        public override double B3 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Replacement module in the Use stage.")]
        public override double B4 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Refurbishment module in the Use stage.")]
        public override double B5 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Operational Energy Use module in the Use stage.")]
        public override double B6 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Operational Water Use module in the Use stage.")]
        public override double B7 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the De-construction Demolition module in the End of Life stage.")]
        public override double C1 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Transport module in the End of Life stage.")]
        public override double C2 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Waste Processing module in the End of Life stage.")]
        public override double C3 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to the Disposal module in the End of Life stage.")]
        public override double C4 { get; }

        [AcidificationPotential]
        [Description("Resulting Acidification Potential relating to benefits and loads beyond the system boundary.")]
        public override double D { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AcidificationPotentialMaterialResult(
            string materialName, 
            string environmentalProductDeclarationName,

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
            double d
            ) : base(materialName,environmentalProductDeclarationName)
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
        }

        /***************************************************/
    }
}
