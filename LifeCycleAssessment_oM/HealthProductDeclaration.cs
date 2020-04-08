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
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    public class HealthProductDeclaration : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("MasterForman description.")]
        public string MasterFormat { get; set; } = "";

        [Description("Uniformat description.")]
        public string Uniformats { get; set; } = "";

        [Description("Cancer Orange description.")]
        public double CancerOrange { get; set; } = double.NaN;

        [Description("Developmental Orange description.")]
        public double DevelopmentalOrange { get; set; } = double.NaN;

        [Description("Endocrine Orange description.")]
        public double EndocrineOrange { get; set; } = double.NaN;

        [Description("Eye Irritation Orange description.")]
        public double EyeIrritationOrange { get; set; } = double.NaN;

        [Description("Mammalian Orange description.")]
        public double MammalianOrange { get; set; } = double.NaN;

        [Description("Mutagenicity Orange description.")]
        public double MutagenicityOrange { get; set; } = double.NaN;

        [Description("Neurotoxicity Orange description.")]
        public double NeurotoxicityOrange { get; set; } = double.NaN;

        [Description("Organ Toxicant Orange description.")]
        public double OrganToxicantOrange { get; set; } = double.NaN;

        [Description("Reproductive Orange description.")]
        public double ReproductiveOrange { get; set; } = double.NaN;

        [Description("Respiratory Orange description.")]
        public double RespiratoryOrange { get; set; } = double.NaN;

        [Description("Respiratory Occupational Only Orange description.")]
        public double RespiratoryOccupationalOnlyOrange { get; set; } = double.NaN;

        [Description("Skin Sensitization Orange description.")]
        public double SkinSensitizationOrange { get; set; } = double.NaN;

        [Description("Cancer Red description.")]
        public double CancerRed { get; set; } = double.NaN;

        [Description("Cancer Occupational Only Red description.")]
        public double CancerOccupationalOnlyRed { get; set; } = double.NaN;

        [Description("Developmental Red description.")]
        public double DevelopmentalRed { get; set; } = double.NaN;

        [Description("Mutagenicity Red description.")]
        public double MutagenicityRed { get; set; } = double.NaN;

        [Description("Persistant Bioaccumulative Toxicant Red description.")]
        public double PersistantBioaccumulativeToxicantRed { get; set; } = double.NaN;

        [Description("Reproductive Red description.")]
        public double ReproductiveRed { get; set; } = double.NaN;

        [Description("Respiratory Red description.")]
        public double RespiratoryRed { get; set; } = double.NaN;

        [Description("Persistant Bioaccumulative Toxicant Purple description.")]
        public double PersistantBioaccumulativeToxicantPurple { get; set; } = double.NaN;
        /***************************************************/
    }
}