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

using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Result class for resulting Photochemical Ozone Creation as defined by the TRACI standard for a particular Element.")]
    public class PhotochemicalOzoneCreationTRACIElementResult : ElementResult<PhotochemicalOzoneCreationTRACIMaterialResult>, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Raw Material Supply module in the Product stage.")]
        public override double A1 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Transport module in the Product stage.")]
        public override double A2 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Manufacturing module in the Product stage.")]
        public override double A3 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the full Product stage.")]
        public override double A1toA3 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Transport module in the Construction Process stage.")]
        public override double A4 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Construction Installation Process module in the Construction Process stage.")]
        public override double A5 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Use module in the Use stage.")]
        public override double B1 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Maintenance module in the Use stage.")]
        public override double B2 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Repair module in the Use stage.")]
        public override double B3 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Replacement module in the Use stage.")]
        public override double B4 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Refurbishment module in the Use stage.")]
        public override double B5 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Operational Energy Use module in the Use stage.")]
        public override double B6 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Operational Water Use module in the Use stage.")]
        public override double B7 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the full Use Stage.")]
        public override double B1toB7 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the De-construction Demolition module in the End of Life stage.")]
        public override double C1 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Transport module in the End of Life stage.")]
        public override double C2 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Waste Processing module in the End of Life stage.")]
        public override double C3 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the Disposal module in the End of Life stage.")]
        public override double C4 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to the full End of Life stage.")]
        public override double C1toC4 { get; protected set; }

        [PhotochemicalOzoneCreationTRACI]
        [Description("Resulting Photochemical Ozone Creation as defined by the TRACI standard relating to benefits and loads beyond the system boundary.")]
        public override double D { get; protected set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PhotochemicalOzoneCreationTRACIElementResult(
            IComparable objectId,
            ScopeType scope,
            ObjectCategory category,
            IReadOnlyList<PhotochemicalOzoneCreationTRACIMaterialResult> materialResults,

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
            ) : base(objectId, scope, category, EnvironmentalMetrics.PhotochemicalOzoneCreationTRACI, materialResults, a1, a2, a3, a1toa3, a4, a5, b1, b2, b3, b4, b5, b6, b7, b1tob7, c1, c2, c3, c4, c1toc4, d)
        {
        }

        /***************************************************/
    }
}

