﻿/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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

using BH.oM.Base;
using System;

namespace BH.oM.DeepLearning.Layers
{
    public class Convolution2d : BHoMObject, IModule
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int FeaturesIn { get; set; } = 0;

        public int FeaturesOut { get; set; } = 0;

        public Shape2d KernelSize { get; set; } = new Shape2d() { Dim1 = 3, Dim2 = 3 };

        public Shape2d Stride { get; set; } = new Shape2d() { Dim1 = 1, Dim2 = 1 };

        public Shape2d Padding { get; set; } = new Shape2d() { Dim1 = 0, Dim2 = 0 };

        public Shape2d Dilation { get; set; } = new Shape2d() { Dim1 = 1, Dim2 = 1 };

        /***************************************************/
    }
}
