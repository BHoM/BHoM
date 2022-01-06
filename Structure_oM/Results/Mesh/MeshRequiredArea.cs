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
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Base;

namespace BH.oM.Structure.Results
{
    [Description("Minimum required area of reinforcement for an AreaElement.")]
    public class MeshRequiredArea : MeshElementResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [AreaPerUnitLength]
        [Description("Minimum required area of reinforcement in the top layer in the local x direction of the Panel.")]
        public virtual double TopPrimary { get; }

        [AreaPerUnitLength]
        [Description("Minimum required area of reinforcement in the top layer in the local y direction of the Panel.")]
        public virtual double TopSecondary { get; }

        [AreaPerUnitLength]
        [Description("Minimum required area of reinforcement in the bottom layer in the local x direction of the Panel.")]
        public virtual double BottomPrimary { get; }

        [AreaPerUnitLength]
        [Description("Minimum required area of reinforcement in the bottom layer in the local y direction of the Panel.")]
        public virtual double BottomSecondary { get; }

        [AreaPerUnitLength]
        [Description("Minimum required area of shear reinforcement.")]
        public virtual double Shear { get; }

        [AreaPerUnitLength]
        [Description("Minimum required area of torsion reinforcement.")]
        public virtual double Torsion { get; }

        [Description("Material name for the reinforcement.")]
        public virtual string MaterialName { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshRequiredArea(IComparable objectId,
                                IComparable nodeId,
                                IComparable meshFaceId,
                                IComparable resultCase,
                                int modeNumber,
                                double timeStep,
                                MeshResultLayer meshResultLayer,
                                double layerPosition,
                                MeshResultSmoothingType smoothing,
                                Basis orientation,
                                double topPrimary, double topSecondary, double bottomPrimary, double bottomSecondary, double shear, double torsion, string materialName) 
            : base(objectId, nodeId, meshFaceId, resultCase, modeNumber, timeStep, meshResultLayer, layerPosition, smoothing, orientation)
        {
            TopPrimary = topPrimary;
            TopSecondary = topSecondary;
            BottomPrimary = bottomPrimary;
            BottomSecondary = bottomSecondary;
            Shear = shear;
            Torsion = torsion;
            MaterialName = materialName;
        }

        /***************************************************/
    }
}



