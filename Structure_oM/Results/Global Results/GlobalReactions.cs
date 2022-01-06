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
using BH.oM.Quantities.Attributes;
using System;

namespace BH.oM.Structure.Results
{
    [Description("Total global reactions for a given Loadcase or LoadCombination.")]
    public class GlobalReactions : StructuralGlobalResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Force]
        [Description("Total force in the global X-direction.")]
        public virtual double FX { get; }

        [Force]
        [Description("Total force in the global Y-direction.")]
        public virtual double FY { get; }

        [Force]
        [Description("Total force in the global Z-direction.")]
        public virtual double FZ { get; }

        [Moment]
        [Description("Total moment about the global X-axis.")]
        public virtual double MX { get; }

        [Moment]
        [Description("Total moment about the global Y-axis.")]
        public virtual double MY { get; }

        [Moment]
        [Description("Total moment about the global Z-axis.")]
        public virtual double MZ { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GlobalReactions(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double fx, double fy, double fz, double mx, double my, double mz) :
            base(objectId, resultCase, modeNumber, timeStep)
        {
            FX = fx;
            FY = fy;
            FZ = fz;
            MX = mx;
            MY = my;
            MZ = mz;
        }

        /***************************************************/
    }
}



