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

using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    public class HealthProductDeclaration : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual string MasterFormat { get; set; } = "";
        public virtual string Uniformats { get; set; } = "";
        public virtual double CancerOrange { get; set; } = double.NaN;
        public virtual double DevelopmentalOrange { get; set; } = double.NaN;
        public virtual double EndocrineOrange { get; set; } = double.NaN;
        public virtual double EyeIrritationOrange { get; set; } = double.NaN;
        public virtual double MammalianOrange { get; set; } = double.NaN;
        public virtual double MutagenicityOrange { get; set; } = double.NaN;
        public virtual double NeurotoxicityOrange { get; set; } = double.NaN;
        public virtual double OrganToxicantOrange { get; set; } = double.NaN;
        public virtual double ReproductiveOrange { get; set; } = double.NaN;
        public virtual double RespiratoryOrange { get; set; } = double.NaN;
        public virtual double RespiratoryOccupationalOnlyOrange { get; set; } = double.NaN;
        public virtual double SkinSensitizationOrange { get; set; } = double.NaN;
        public virtual double CancerRed { get; set; } = double.NaN;
        public virtual double CancerOccupationalOnlyRed { get; set; } = double.NaN;
        public virtual double DevelopmentalRed { get; set; } = double.NaN;
        public virtual double MutagenicityRed { get; set; } = double.NaN;
        public virtual double PersistantBioaccumulativeToxicantRed { get; set; } = double.NaN;
        public virtual double ReproductiveRed { get; set; } = double.NaN;
        public virtual double RespiratoryRed { get; set; } = double.NaN;
        public virtual double PersistantBioaccumulativeToxicantPurple { get; set; } = double.NaN;
        /***************************************************/
    }
}

