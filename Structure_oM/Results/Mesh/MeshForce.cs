/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.Base;
using BH.oM.Geometry;
using System;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Results
{
    [Description("Gives a full set of shell and membrane forces at a discrete location in the Panel/FEMesh.")]
    public class MeshForce : MeshElementResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [ForcePerUnitLength]
        [Description("Axial/membrane force in x-direction.")]
        public virtual double NXX { get; } = 0.0;

        [ForcePerUnitLength]
        [Description("Axial/membrane force in y-direction.")]
        public virtual double NYY { get; } = 0.0;

        [ForcePerUnitLength]
        [Description("Axial/membrane force in xy-direction.")]
        public virtual double NXY { get; } = 0.0;

        [ForcePerUnitLength]
        [Description("Bending moment in x-direction.")]
        public virtual double MXX { get; } = 0.0;

        [MomentPerUnitLength]
        [Description("Bending moment in y-direction.")]
        public virtual double MYY { get; } = 0.0;

        [MomentPerUnitLength]
        [Description("Bending moment in xy-direction.")]
        public virtual double MXY { get; } = 0.0;

        [ForcePerUnitLength]
        [Description("Shear force in x-direction.")]
        public virtual double VX { get; } = 0.0;

        [ForcePerUnitLength]
        [Description("Shear force in y-direction.")]
        public virtual double VY { get; } = 0.0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshForce(   IComparable objectId,
                            IComparable nodeId,
                            IComparable meshFaceId,
                            IComparable resultCase,
                            double timeStep,
                            MeshResultLayer meshResultLayer,
                            double layerPosition,
                            MeshResultSmoothingType smoothing,
                            Basis orientation,
                            double nXX,
                            double nYY,
                            double nXY,
                            double mXX,
                            double mYY,
                            double mXY,
                            double vX,
                            double vY) : base(objectId, nodeId, meshFaceId, resultCase, timeStep, meshResultLayer, layerPosition, smoothing, orientation)
        {            
            NXX = nXX;
            NYY = nYY;
            NXY = nXY;
            MXX = mXX;
            MYY = mYY;
            MXY = mXY;
            VX = vX;
            VY = vY;
        }

        /***************************************************/
    }
}

