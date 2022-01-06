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
using System;
using BH.oM.Quantities.Attributes;
using BH.oM.Geometry;

namespace BH.oM.Structure.Results
{
    [Description("Modal mass for a Node.")]
    public class NodeModalMass : NodeResult
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Mass]
        [Description("Nodal modal mass in the X-direction as defined by orientation basis.")]
        public virtual double MassX { get; }

        [Mass]
        [Description("Nodal modal mass in the Y-direction as defined by orientation basis.")]
        public virtual double MassY { get; }

        [Mass]
        [Description("Nodal modal mass in the Z-direction as defined by orientation basis.")]
        public virtual double MassZ { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NodeModalMass(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, Basis orientation, double massX, double massY, double massZ) :
            base(objectId, resultCase, modeNumber, timeStep, orientation)
        {
            MassX = massX;
            MassY = massY;
            MassZ = massZ;
        }


        /***************************************************/
    }
}


