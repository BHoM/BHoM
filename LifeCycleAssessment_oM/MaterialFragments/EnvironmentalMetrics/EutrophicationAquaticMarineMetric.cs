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
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Eutrophication - aquatic marine for a particular product or material. Forms part of an EPD, and should be evaluated based on the QuantityType stated on the EPD.")]
    public class EutrophicationAquaticMarineMetric : BHoMObject, IEnvironmentalMetric, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Enum indicating the metric type the object relates to.")]
        public virtual EnvironmentalMetrics MetricType { get; } = EnvironmentalMetrics.EutrophicationAquaticMarine;

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Raw Material Supply module in the Product stage.")]
        public virtual double A1 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Transport module in the Product stage.")]
        public virtual double A2 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Manufacturing module in the Product stage.")]
        public virtual double A3 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the full Product stage.")]
        public virtual double A1toA3 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Transport module in the Construction Process stage.")]
        public virtual double A4 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Construction Installation Process module in the Construction Process stage.")]
        public virtual double A5 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Use module in the Use stage.")]
        public virtual double B1 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Maintenance module in the Use stage.")]
        public virtual double B2 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Repair module in the Use stage.")]
        public virtual double B3 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Replacement module in the Use stage.")]
        public virtual double B4 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Refurbishment module in the Use stage.")]
        public virtual double B5 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Operational Energy Use module in the Use stage.")]
        public virtual double B6 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Operational Water Use module in the Use stage.")]
        public virtual double B7 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the full Use Stage.")]
        public virtual double B1toB7 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the De-construction Demolition module in the End of Life stage.")]
        public virtual double C1 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Transport module in the End of Life stage.")]
        public virtual double C2 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Waste Processing module in the End of Life stage.")]
        public virtual double C3 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the Disposal module in the End of Life stage.")]
        public virtual double C4 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to the full End of Life stage.")]
        public virtual double C1toC4 { get; }

        [EutrophicationAquaticMarinePerQuantity]
        [Description("Eutrophication - aquatic marine relating to benefits and loads beyond the system boundary.")]
        public virtual double D { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public EutrophicationAquaticMarineMetric(
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
            double b1tob7,
            double c1,
            double c2,
            double c3,
            double c4,
            double c1toc4,
            double d
            )
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
            B1toB7 = b1tob7;
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C1toC4 = c1toc4;
            D = d;
        }

        /***************************************************/

    }
}
