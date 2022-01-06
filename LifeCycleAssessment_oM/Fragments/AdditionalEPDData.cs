/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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

using System.ComponentModel;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.LifeCycleAssessment.Fragments
{
    [Description("A data fragment containing other optional information regarding the production and documentation of any Environmental Product Declaration. \n" + 
        "Use AddFragment() to combine this information with any EPD for continuous integration.")]
    public class AdditionalEPDData : IFragment
    {
        [Description("Brief summary of the EPD from the data source.")]
        public virtual string Description { get; set; } = "";

        [Description("Description of the material's treatment after its useful life.")]
        public virtual string EndOfLifeTreatment { get; set; } = "";

        [Description("Unique identifier of the EPD from the source of the information.")]
        public virtual string Id { get; set; } = "";

        [Description("Industry Standards referenced in creating the product.")]
        public virtual List<string> IndustryStandards { get; set; } = new List<string>();

        [Description("Jurisdiction within which the sector based product EPD originates.")]
        public virtual string Jurisdiction { get; set; } = "";

        [Description("The period of useful life of the product measured in years.")]
        public virtual int LifeSpan { get; set; } = 20;

        [Description("Manufacturer name responsible for the product being documented.")]
        public virtual string Manufacturer { get; set; } = "";

        [Description("Manufacturing facility name within which the product was created.")]
        public virtual string PlantName { get; set; } = "";

        [Description("Postal Code within which the product was created.")]
        public virtual int PostalCode { get; set; } = 00000;

        [Description("Publisher responsible for recording and presenting all EPD information.")]
        public virtual string Publisher { get; set; } = "";

        [Description("Year in which the EPD was created. Default set to the current year, please override if creating an EPD from legacy information.")]
        public virtual int ReferenceYear { get; set; } = System.DateTime.Today.Year;
    }
}


