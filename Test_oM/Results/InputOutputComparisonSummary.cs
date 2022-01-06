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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Analytical.Results;
using System.ComponentModel;

namespace BH.oM.Test.Results
{
    public class InputOutputComparisonSummary : IAnalysisResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The hashes of the item being evaluated, comma separated")]
        public virtual IComparable ObjectId { get; }

        [Description("The sets the result belongs to, comma separated.")]
        public virtual IComparable ResultCase { get; }

        [Description("The type of the object being evaluated.")]
        public virtual Type ObjectType { get; }

        [Description("Not in use")]
        public virtual double TimeStep { get; }

        public virtual InputOutputComparisonType ResultType { get; }

        [Description("Number of times a particular difference has been registred.")]
        public virtual int Occurrences { get;  }

        [Description("The name of the evaluated property. Only applicable for ResultType 'Difference'.")]
        public virtual string PropertyId { get; }

        [Description("Average difference between the input and returned item. Only applicable for Results of type 'Difference' for numerical values.")]
        public virtual double AverageDifference { get;  }

        [Description("Maximum difference between the input and returned item. Only applicable for Results of type 'Difference' for numerical values.")]
        public virtual double MaximumDifference { get;  }

        [Description("Value of the input item for the maximum difference. Only applicable for Results of type 'Difference' for numerical values.")]
        public virtual double MaximumDifferenceInputItem { get;  }

        [Description("Value of the returned item for the maximum difference. Only applicable for Results of type 'Difference' for numerical values.")]
        public virtual double MaximumDifferenceReturnedItem { get;  }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public InputOutputComparisonSummary(IComparable objectId, IComparable resultCase, Type objectType, InputOutputComparisonType resultType, string propertyId, double timeStep, int occurrences, double averageDifference, double maximumDifference, double maximumDifferenceInputItem, double maximumDifferenceReturnedItem)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            PropertyId = propertyId;
            TimeStep = timeStep;
            Occurrences = occurrences;
            ObjectType = objectType;
            ResultType = resultType;
            AverageDifference = averageDifference;
            MaximumDifference = maximumDifference;
            MaximumDifferenceInputItem = maximumDifferenceInputItem;
            MaximumDifferenceReturnedItem = maximumDifferenceReturnedItem;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            InputOutputComparisonSummary otherRes = other as InputOutputComparisonSummary;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int objectType = this.ObjectType.ToString().CompareTo(otherRes.ObjectType.ToString());

            if (objectType == 0)
            {

                int resType = this.ResultType.CompareTo(otherRes.ResultType);

                if (resType == 0)
                {

                    int p = this.PropertyId.CompareTo(otherRes.PropertyId);
                    if (p == 0)
                    {
                        int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                        if (l == 0)
                        {
                            return this.ObjectId.CompareTo(otherRes.ObjectId);

                        }
                        else
                        {
                            return l;
                        }
                    }
                    else
                    {
                        return p;
                    }
                }
                else
                {
                    return resType;
                }
            }
            else
            {
                return objectType;
            }
        }

        /***************************************************/
    }
}


