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
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Results
{
    [Description("von Mises stress, force and moment at a discrete location in the Panel/FEMesh.")]
    public class MeshVonMises: MeshElementResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Stress]
        [Description("von Mises Stress.")]
        public virtual double S { get; }

        [ForcePerUnitLength]
        [Description("von Mises normal/membrane forces.")]
        public virtual double N { get; }

        [MomentPerUnitLength]
        [Description("von Mises moments.")]
        public virtual double M { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshVonMises(IComparable objectId,
                            IComparable nodeId,
                            IComparable meshFaceId,
                            IComparable resultCase,
                            int modeNumber,
                            double timeStep,
                            MeshResultLayer meshResultLayer,
                            double layerPosition,
                            MeshResultSmoothingType smoothing,
                            Basis orientation,
                            double s,
                            double n,
                            double m): base(objectId, nodeId, meshFaceId, resultCase, modeNumber, timeStep, meshResultLayer, layerPosition, smoothing, orientation)
        {
            S = s;
            N = n;
            M = m;
        }

        /***************************************************/
    }
}



