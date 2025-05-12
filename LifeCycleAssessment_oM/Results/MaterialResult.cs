///*
// * This file is part of the Buildings and Habitats object Model (BHoM)
// * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
// *
// * Each contributor holds copyright over their respective contributions.
// * The project versioning (Git) records all such contribution source information.
// *                                           
// *                                                                              
// * The BHoM is free software: you can redistribute it and/or modify         
// * it under the terms of the GNU Lesser General Public License as published by  
// * the Free Software Foundation, either version 3.0 of the License, or          
// * (at your option) any later version.                                          
// *                                                                              
// * The BHoM is distributed in the hope that it will be useful,              
// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
// * GNU Lesser General Public License for more details.                          
// *                                                                            
// * You should have received a copy of the GNU Lesser General Public License     
// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
// */

//using BH.oM.Analytical.Results;
//using BH.oM.Base;
//using BH.oM.LifeCycleAssessment.Results.MetricsValues;
//using System.Collections.Generic;
//using System.ComponentModel;

//namespace BH.oM.LifeCycleAssessment.Results
//{
//    public class MaterialResult<T> : IEnvironmentalResult<T>, IImmutable, IMaterialResult//,IDynamicObject
//        where T : IMetricValue, new()
//    {
//        /***************************************************/
//        /**** Properties                                ****/
//        /***************************************************/

//        [Description("Name of the physical material evaluated.")]
//        public virtual string MaterialName { get; protected set; }

//        [Description("Name of the Environmental Product Declaration evaluated.")]
//        public virtual string EnvironmentalProductDeclarationName { get; protected set; }

//        [Description("Enum indicating the metric type the object relates to.")]
//        public virtual MetricType MetricType { get; protected set; }

//        //[DynamicProperty]
//        [Description("Resulting values for the material for each module.")]
//        public virtual IReadOnlyDictionary<Module, T> Metrics { get; protected set; }
        

//        /***************************************************/
//        /**** Constructors                              ****/
//        /***************************************************/

//        public MaterialResult(string materialName, string environmentalProductDeclarationName, MetricType metricType, IReadOnlyDictionary<Module, T> metrics)
//        {
//            MaterialName = materialName;
//            EnvironmentalProductDeclarationName = environmentalProductDeclarationName;
//            MetricType = metricType;
//            Metrics = metrics;
//        }

//        /***************************************************/
//        /**** IComparable Interface                     ****/
//        /***************************************************/

//        public int CompareTo(IResult other)
//        {
//            if (other == null)
//                return -1;

//            MaterialResult2 otherRes = other as MaterialResult2;

//            if (otherRes == null)
//                return this.GetType().Name.CompareTo(other.GetType().Name);

//            int l = this.MaterialName.CompareTo(otherRes.MaterialName);
//            if (l == 0)
//            {
//                return this.MaterialName.CompareTo(otherRes.MaterialName);
//            }
//            else
//            {
//                return l;
//            }

//        }

//        /***************************************************/
//    }
//}


