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
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structure.Results
{
    public class MeshStress: MeshResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Normal stress in X direction in N/m2")]
        public double SXX { get; }

        [Description("Normal stress in Y direction in N/m2")]
        public double SYY { get; }

        [Description("Normal stress in XY direction in N/m2")]
        public double SXY { get; }

        [Description("Shear stress in X direction in N/m2")]
        public double TXX { get; }

        [Description("Shear stress in Y direction in N/m2")]
        public double TYY { get;  }

        [Description("Principal stress in first principal direction in N/m2")]
        public double Principal_1 { get; }

        [Description("Principal stress in second principal direction in N/m2")]
        public double Principal_2 { get; }

        [Description("Principal stress in middle principal direction in N/m2")]
        public double Principal_1_2 { get; }
        
        /***************************************************/

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshStress(  IComparable objectId,
                            IComparable nodeId,
                            IComparable meshFaceId,
                            IComparable resultCase,
                            double timeStep,
                            MeshResultLayer meshResultLayer,
                            double layerPosition,
                            MeshResultSmoothingType smoothing,
                            Basis orientation,
                            double sXX,
                            double sYY,
                            double sXY,
                            double tXX,
                            double tYY,
                            double principal_1,
                            double principal_2,
                            double principal_1_2): base(objectId, nodeId, meshFaceId, resultCase, timeStep, meshResultLayer, layerPosition, smoothing, orientation)
        {           
            SXX = sXX;
            SYY = sYY;
            SXY = sXY;
            TXX = tXX;
            TYY = tYY;
            Principal_1 = principal_1;
            Principal_2 = principal_2;
            Principal_1_2 = principal_1_2;
        }

        /***************************************************/
    }
}
