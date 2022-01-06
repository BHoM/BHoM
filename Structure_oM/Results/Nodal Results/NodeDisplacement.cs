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
using BH.oM.Geometry;

namespace BH.oM.Structure.Results
{
    [Description("Resulting displacements and rotations for a Node.")]
    public class NodeDisplacement : NodeResult, INodeDisplacement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Translational displacement in the X-direction as defined by orientation basis.")]
        public virtual double UX { get; }

        [Length]
        [Description("Translational displacement in the Y-direction as defined by orientation basis.")]
        public virtual double UY { get; }

        [Length]
        [Description("Translational displacement in the Z-direction as defined by orientation basis.")]
        public virtual double UZ { get; }

        [Angle]
        [Description("Rotational displacement about the X-axis as defined by orientation basis.")]
        public virtual double RX { get; }

        [Angle]
        [Description("Rotational displacement about the Y-axis as defined by orientation basis.")]
        public virtual double RY { get; }

        [Angle]
        [Description("Rotational displacement about the Z-axis as defined by orientation basis.")]
        public virtual double RZ { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NodeDisplacement(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, Basis orientation, double ux, double uy, double uz, double rx, double ry, double rz) :
            base(objectId, resultCase, modeNumber, timeStep, orientation)
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



