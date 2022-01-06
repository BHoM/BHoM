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

namespace BH.oM.Structure.Results
{
    [Description("Resulting local deformation of the Bar in local coordinates. This is disregarding rigid body motion and/or rotation of the Bar.")]
    public class BarDeformation : BarResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Local deformation of the Bar along the local x-axis. Local axial deformation of the Bar.")]
        public virtual double UX { get; }

        [Length]
        [Description("Local deformation of the Bar along the local y-axis. Generally minor axis deformation.")]
        public virtual double UY { get; }

        [Length]
        [Description("Local deformation of the Bar along the local z-axis. Generally major axis deformation.")]
        public virtual double UZ { get; }

        [Angle]
        [Description("Localised rotation of the Bar about the local x-axis. Twist of the Bar.")]
        public virtual double RX { get; }

        [Angle]
        [Description("Localised rotation of the Bar about the local y-axis. Generally major axis rotation.")]
        public virtual double RY { get; }

        [Angle]
        [Description("Localised rotation of the Bar about the local z-axis. Generally minor axis rotation.")]
        public virtual double RZ { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarDeformation(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, double position, int divisions, double ux, double uy, double uz, double rx, double ry, double rz)
            : base(objectId, resultCase, modeNumber, timeStep, position, divisions)
        {
            UX = ux;
            UY = uy;
            UZ = uz;
            RX = rx;
            RY = ry;
            RZ = rz;
        }

        /***************************************************/
    }
}



