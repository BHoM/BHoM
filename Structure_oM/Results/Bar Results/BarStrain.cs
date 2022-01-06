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
    [Description("Resulting axial strain along the bar in local coordinates.")]
    public class BarStrain : BarResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Strain]
        [Description("Axial strain induced by an axial force along the Bar axis. Positive for elongation, negative for contraction.")]
        public virtual double Axial { get; }

        [Strain]
        [Description("Shear strain along the local y-axis. Generally minor axis shear strain.")]
        public virtual double ShearY { get; }

        [Strain]
        [Description("Shear strain along the local z-axis. Generally major axis shear strain.")]
        public virtual double ShearZ { get; }

        [Strain]
        [Description("Strain induced by bending about the local y-axis at the 'uppermost' extreme fiber. Generally the major axis bending strains in one of the extreme fibers.")]
        public virtual double BendingY_Top { get; }

        [Strain]
        [Description("Strain induced by bending about the local y-axis at the 'lowermost' extreme fiber. Generally the major axis bending strains in one of the extreme fibers.")]
        public virtual double BendingY_Bot { get; }

        [Strain]
        [Description("Strain induced by bending about the local z-axis at the 'uppermost' extreme fiber. Generally the minor axis bending strains in one of the extreme fibers.")]
        public virtual double BendingZ_Top { get; }

        [Strain]
        [Description("Strain induced by bending about the local z-axis at the 'lowermost' extreme fiber. Generally the minor axis bending strains in one of the extreme fibers.")]
        public virtual double BendingZ_Bot { get; }

        [Strain]
        [Description("Worst case elongation (axial strain) from combined axial and bending in two directions.")]
        public virtual double CombAxialBendingPos { get; }

        [Strain]
        [Description("Worst case contraction (axial strain) from combined axial and bending in two directions.")]
        public virtual double CombAxialBendingNeg { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarStrain(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double position, int divisions,
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



