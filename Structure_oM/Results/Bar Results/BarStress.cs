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

using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using System;
using BH.oM.Analytical.Results;
using BH.oM.Base;

namespace BH.oM.Structure.Results
{
    [Description("Resulting stresses in local coordinates along the bar.")]
    public class BarStress : BarResult, IResultItem, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Stress]
        [Description("Axial stress induced by an axial force along the Bar axis. Positive for tension, negative for compression.")]
        public virtual double Axial { get; }

        [Stress]
        [Description("Shear stress along the local y-axis. Generally minor axis shear stress.")]
        public virtual double ShearY { get; }

        [Stress]
        [Description("Shear stress along the local z-axis. Generally major axis shear stress.")]
        public virtual double ShearZ { get; }

        [Stress]
        [Description("Stress induced by bending about the local y-axis at the 'uppermost' extreme fiber. Generally the major axis bending stresses in one of the extreme fibers.")]
        public virtual double BendingY_Top { get; }

        [Stress]
        [Description("Stress induced by bending about the local y-axis at the 'lowermost' extreme fiber. Generally the major axis bending stresses in one of the extreme fibers.")]
        public virtual double BendingY_Bot { get; }

        [Stress]
        [Description("Stress induced by bending about the local z-axis at the 'uppermost' extreme fiber. Generally the minor axis bending stresses in one of the extreme fibers.")]
        public virtual double BendingZ_Top { get; }

        [Stress]
        [Description("Stress induced by bending about the local z-axis at the 'lowermost' extreme fiber. Generally the minor axis bending stresses in one of the extreme fibers.")]
        public virtual double BendingZ_Bot { get; }

        [Stress]
        [Description("Worst case tensile normal stress from combined axial and bending in two directions.")]
        public virtual double CombAxialBendingPos { get; }

        [Stress]
        [Description("Worst case compressive normal stress from combined axial and bending in two directions.")]
        public virtual double CombAxialBendingNeg { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarStress(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double position, int divisions,
                        double axial,
                        double shearY,
                        double shearZ,
                        double bendingY_Top,
                        double bendingY_Bot,
                        double bendingZ_Top,
                        double bendingZ_Bot,
                        double combAxialBendingPos,
                        double combAxialBendingNeg)
            : base(objectId, resultCase, modeNumber, timeStep, position, divisions)
        {
            Axial = axial;
            ShearY = shearY;
            ShearZ = shearZ;
            BendingY_Top = bendingY_Top;
            BendingY_Bot = bendingY_Bot;
            BendingZ_Top = bendingZ_Top;
            BendingZ_Bot = bendingZ_Bot;
            CombAxialBendingPos = combAxialBendingPos;
            CombAxialBendingNeg = combAxialBendingNeg;
        }

        /***************************************************/
    }
}





