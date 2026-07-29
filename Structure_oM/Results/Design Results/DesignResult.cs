/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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
using BH.oM.Analytical.Results;
using BH.oM.Base;

namespace BH.oM.Structure.Results
{
    [Description("Base class for structural design check results, storing the resistance (capacity), action (demand), " +
        "required factor of safety, and any feedback generated during the verification.")]
    public abstract class DesignResult : IStructuralResult, IImmutable, IResultItem
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the structure. Unused for many results.")]
        public virtual IComparable ObjectId { get; }

        [Description("Identifier for the Loadcase or LoadCombination that the result belongs to. Is generally name or number of the loadcase, depending on the analysis package.")]
        public virtual IComparable ResultCase { get; }

        [Description("Positive index, starting at one. Only set for cases with modal outputs such as dynamic cases.")]
        public virtual int ModeNumber { get; }

        [Description("Time step for time history results.")]
        public virtual double TimeStep { get; }

        [Description("The structural resistance or capacity of the element, representing the maximum load or stress the element can withstand.")]
        public virtual double Resistance { get; }

        [Description("The design action or demand acting on the element, representing the applied load or stress effect.")]
        public virtual double Action { get; }

        [Description("The minimum required factor of safety as specified by the applicable design standard.")]
        public virtual double RequiredFactorOfSafety { get; }

        [Description("Human-readable description of the design check, explaining what is being verified.")]
        public virtual string Description { get; }

        [Description("Specifies the type of design check, defining how Action and Resistance are evaluated.")]
        public virtual DesignCheckType CheckType { get; }

        [Description("Messages generated during the design check to communicate assumptions made, inapplicable checks, out-ofrange values, or missing data.")]
        public virtual List<string> Feedback { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public DesignResult(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, 
            double resistance, double action, double requiredFactorOfSafety, string description, List<string> feedback, DesignCheckType checkType)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            ModeNumber = modeNumber;
            TimeStep = timeStep;
            Resistance = resistance;
            Action = action;
            RequiredFactorOfSafety = requiredFactorOfSafety;
            Description = description;
            Feedback = feedback;
            CheckType = checkType;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        [Description("Controls how this result is sorted in relation to other results. Sorts with the following priority: Type, ObjectId, ResultCase, TimeStep.")]
        public int CompareTo(IResult other)
        {
            DesignResult otherRes = other as DesignResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                if (l == 0)
                {
                    int m = this.ModeNumber.CompareTo(otherRes.ModeNumber);
                    return m == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : m;
                }
                else
                {
                    return l;
                }
            }
            else
            {
                return n;
            }

        }

        /***************************************************/
    }
}







