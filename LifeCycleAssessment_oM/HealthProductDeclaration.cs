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
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    public class HealthProductDeclaration : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        //public string Cpid { get; set; } = "";
        //public string Version { get; set; } = "";
        public string MasterFormat { get; set; } = "";
        public string Uniformats { get; set; } = "";
        public double CancerOrange { get; set; } = double.NaN;
        public double DevelopmentalOrange { get; set; } = double.NaN;
        public double EndocrineOrange { get; set; } = double.NaN;
        public double EyeIrritationOrange { get; set; } = double.NaN;
        public double MammalianOrange { get; set; } = double.NaN;
        public double MutagenicityOrange { get; set; } = double.NaN;
        public double NeurotoxicityOrange { get; set; } = double.NaN;
        public double OrganToxicantOrange { get; set; } = double.NaN;
        public double ReproductiveOrange { get; set; } = double.NaN;
        public double RespiratoryOrange { get; set; } = double.NaN;
        public double RespiratoryOccupationalOnlyOrange { get; set; } = double.NaN;
        public double SkinSensitizationOrange { get; set; } = double.NaN;
        public double CancerRed { get; set; } = double.NaN;
        public double CancerOccupationalOnlyRed { get; set; } = double.NaN;
        public double DevelopmentalRed { get; set; } = double.NaN;
        public double MutagenicityRed { get; set; } = double.NaN;
        public double PersistantBioaccumulativeToxicantRed { get; set; } = double.NaN;
        public double ReproductiveRed { get; set; } = double.NaN;
        public double RespiratoryRed { get; set; } = double.NaN;
        public double PersistantBioaccumulativeToxicantPurple { get; set; } = double.NaN;
        /***************************************************/
    }
}