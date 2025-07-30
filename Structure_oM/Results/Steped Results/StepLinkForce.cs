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

using BH.oM.Analytical.Results;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static BH.oM.Structure.Results.TimeHistoryResult;

namespace BH.oM.Structure.Results
{
    [Description("Resulting forces at the endpoints of a link.")]
    public class StepLinkForce : ITimeStepResult, IResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [ScenarioIdentifier]
        [Description("The time step indentifier for the result.")]
        public virtual double TimeStep { get; }

        [Force]
        [Description("Axial force along the local x-axis. Positive for tension, negative for compression.")]
        public virtual double FX { get; }

        [Force]
        [Description("Shear force along the local y-axis. Generally minor axis shear force.")]
        public virtual double FY { get; }

        [Force]
        [Description("Shear force along the local z-axis. Generally major axis shear force.")]
        public virtual double FZ { get; }

        [Moment]
        [Description("Torsional moment.")]
        public virtual double MX { get; }

        [Moment]
        [Description("Bending moment about the local y-axis.")]
        public virtual double MY { get; }

        [Moment]
        [Description("Bending moment about the local z-axis.")]
        public virtual double MZ { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            StepLinkForce otherRes = other as StepLinkForce;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.TimeStep.CompareTo(otherRes.TimeStep);
            return n;
        }

        public StepLinkForce(double timeStep, double fx, double fy, double fz, double mx, double my, double mz)
        {
            TimeStep = timeStep;
            FX = fx;
            FY = fy;
            FZ = fz;
            MX = mx;
            MY = my;
            MZ = mz;
        }

        /***************************************************/
    }
    
    public class TimeHistoryLinkForce : TimeHistoryResult, IImmutable
    {
        [Description("List of results for each step.")]
        public List<StepLinkForce> StepResults { get; } 

        public TimeHistoryLinkForce(IComparable objectId, IComparable resultCase, int modeNumber, string position, List<StepLinkForce> stepResults)
        : base(objectId, resultCase, modeNumber, position)
        {
           StepResults = stepResults;
        }
    }
    
}
