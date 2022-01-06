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
using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Results
{
    [Description("Displacements and rotations at a discrete location in the Panel/FEMesh.")]
    public class MeshDisplacement : MeshElementResult, IImmutable, IMeshDisplacement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Translation in global X-direction.")]
        public virtual double UXX { get; }

        [Length]
        [Description("Translation in global Y-direction.")]
        public virtual double UYY { get; }

        [Length]
        [Description("Translation in global Z-direction.")]
        public virtual double UZZ { get; }

        [Angle]
        [Description("Rotation about global X-axis.")]
        public virtual double RXX { get; }

        [Angle]
        [Description("Rotation about global Y-axis.")]
        public virtual double RYY { get; }

        [Angle]
        [Description("Rotation about global Z-axis.")]
        public virtual double RZZ { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshDisplacement(IComparable objectId,
                                IComparable nodeId,
                                IComparable meshFaceId,
                                IComparable resultCase,
                                int modeNumber,
                                double timeStep,
                                MeshResultLayer meshResultLayer,
                                double layerPosition,
                                MeshResultSmoothingType smoothing,
                                Basis orientation,
                                double uXX,
                                double uYY,
                                double uZZ,
                                double rXX,
                                double rYY,
                                double rZZ) : base(objectId, nodeId, meshFaceId, resultCase, modeNumber, timeStep, meshResultLayer, layerPosition, smoothing, orientation)
        {
            UXX = uXX;
            UYY = uYY;
            UZZ = uZZ;
            RXX = rXX;
            RYY = rYY;
            RZZ = rZZ;
        }

        /***************************************************/
    }
}



