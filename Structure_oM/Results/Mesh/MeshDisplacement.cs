/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

namespace BH.oM.Structure.Results
{
    public class MeshDisplacement : MeshElementResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        
        [Description("Translation in local X direction (defined by result coordinate system), in m")]
        public double UXX { get; } = 0.0;

        [Description("Translation in local Y direction (defined by result coordinate system), in m")]
        public double UYY { get; } = 0.0;

        [Description("Translation in local Z direction (defined by result coordinate system), in m")]
        public double UZZ { get; } = 0.0;

        [Description("Rotatoin about local X axis (defined by result coordinate system), in radians")]
        public double RXX { get; } = 0.0;

        [Description("Rotatoin about local Y axis (defined by result coordinate system), in radians")]
        public double RYY { get; } = 0.0;

        [Description("Rotatoin about local Z axis (defined by result coordinate system), in radians")]
        public double RZZ { get; } = 0.0;

        /***************************************************/

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshDisplacement(IComparable objectId,
                                IComparable nodeId,
                                IComparable meshFaceId,
                                IComparable resultCase,
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
                                double rZZ) : base(objectId, nodeId, meshFaceId, resultCase, timeStep, meshResultLayer, layerPosition, smoothing, orientation)
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
