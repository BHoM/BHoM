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
using BH.oM.Analytical.Results;
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Test.Results
{
    public class InputOutputComparisonDiffing : IAnalysisResult, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The name of the item being evaluated")]
        public virtual IComparable ObjectId { get; }

        [Description("The set the result belongs to.")]
        public virtual IComparable ResultCase { get; }

        [Description("The name of the evaluated property")]
        public virtual string PropertyId { get; }

        [Description("The type of the object being evaluated.")]
        public virtual Type ObjectType { get; }

        public virtual double TimeStep { get; }

        public virtual InputOutputComparisonDiffingType Type { get; }

        public virtual object InputValue { get; }

        public virtual object NewValue { get; }

        public virtual object ReferenceValue { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public InputOutputComparisonDiffing(IComparable objectId, IComparable resultCase, string propertyId, Type objectType, InputOutputComparisonDiffingType type, object inputValue, object newValue, object referenceValue)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            PropertyId = propertyId;
            ObjectId = objectId;
            Type = type;
            InputValue = inputValue;
            NewValue = newValue;
            ReferenceValue = referenceValue;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            InputOutputComparisonDiffing otherRes = other as InputOutputComparisonDiffing;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int l = this.ResultCase.CompareTo(otherRes.ResultCase);
            if (l == 0)
            {
                int n = this.ObjectId.CompareTo(otherRes.ObjectId);
                if (n == 0)
                {

                    int p = this.PropertyId.CompareTo(otherRes.PropertyId);
                    if (p == 0)
                    {
                        return this.Type.CompareTo(otherRes.Type);
                    }
                    else
                    {
                        return p;
                    }
                }
                else
                {
                    return n;
                }
            }
            else
            {
                return l;
            }
        }

        /***************************************************/
    }
}


