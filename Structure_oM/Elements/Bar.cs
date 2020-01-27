/*
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

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Offsets;
using BH.oM.Analytical.Elements;

namespace BH.oM.Structure.Elements
{
    /// <summary>
    /// Bar objects for 1D finite element bars.
    /// </summary>
    public class Bar : BHoMObject, IElement1D, ILink<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Node StartNode { get; set; }

        public Node EndNode { get; set; }

        public ISectionProperty SectionProperty { get; set; } = null;

        [Description("Bar orientation angle in radians \n" +
                     "For non-vertical members local z is aligned with global z and rotated with the orientation angle around the local x. \n " +
                     "For vertical members the local y is aligned with the global y and rotated with the orientation angle around the local x. \n" +
                     "A bar is vertical if its projected length to the horizontal plane is less than 0.0001, i.e. a tolerance of 0.1mm on verticality. \n" +
                     "For general structural conventions please see  https://github.com/BHoM/documentation/wiki/BHoM-Structural-Conventions")]
        public double OrientationAngle { get; set; } = 0;

        public BarRelease Release { get; set; } = null;

        public BarFEAType FEAType { get; set; } = BarFEAType.Flexural;

        public Constraint4DOF Support { get; set; } = null;

        public Offset Offset { get; set; } = null;


        /***************************************************/
    }
}
