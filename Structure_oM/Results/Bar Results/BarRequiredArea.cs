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
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Base;

namespace BH.oM.Structure.Results
{
    [Description("Minimum required area of reinforcement for a Bar.")]
    public class BarRequiredArea : BarResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Area]
        [Description("Minimum required area of reinforcement in the top layer.")]
        public virtual double Top { get; }

        [Area]
        [Description("Minimum required area of reinforcement in the bottom layer.")]
        public virtual double Bottom { get; }

        [Area]
        [Description("Minimum required area of perimeter reinforcement.")]
        public virtual double Perimeter { get; }

        [AreaPerUnitLength]
        [Description("Minimum required area of shear reinforcement expressed as an area per unit length.")]
        public virtual double Shear { get; }

        [Area]
        [Description("Minimum required area of torsion reinforcement.")]
        public virtual double Torsion { get; }

        [Description("Material name for the reinforcement.")]
        public virtual string MaterialName { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarRequiredArea(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double position, int divisions, 
            double top, double bottom, double perimeter, double shear, double torsion, string materialName)
            : base(objectId, resultCase, modeNumber, timeStep, position, divisions)
        {
            Top = top;
            Bottom = bottom;
            Perimeter = perimeter;
            Shear = shear;
            Torsion = torsion;
            MaterialName = materialName;
        }

        /***************************************************/
    }
}



