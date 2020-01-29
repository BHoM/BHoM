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
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Offsets;
using BH.oM.Analytical.Elements;

namespace BH.oM.Structure.Elements
{

    [Description("1D finite element for structural analysis. Linear 2-noded element defined by a start and end node." +
                 "For structural conventions and orientation of the bar please see https://github.com/BHoM/documentation/wiki/BHoM-Structural-Conventions")]
    public class Bar : BHoMObject, IElement1D, ILink<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Start node of the bar. Defines the start position of the element. \nNote that Nodes can contain Supports, not to be mixed up with releases")]
        public Node StartNode { get; set; }

        [Description("End node of the bar. Defines the end position of the element. \nNote that Nodes can contain Supports, not to be mixed up with releases")]
        public Node EndNode { get; set; }

        [Description("Section property of the bar, containing all sectional constants and and material as well as, depending on section type, sectional geometry and dimensions")]
        public ISectionProperty SectionProperty { get; set; } = null;

        [Description("Bar orientation angle in radians \n" +
                     "For non-vertical members the local z is aligned with the global z and rotated with the orientation angle around the local x. \n" +
                     "For vertical members the local y is aligned with the global y and rotated with the orientation angle around the local x. \n"+
                     "A bar is vertical if its projected length to the horizontal plane is less than 0.0001, i.e. a tolerance of 0.1mm on verticality. \n" +
                     "For general structural conventions please see  https://github.com/BHoM/documentation/wiki/BHoM-Structural-Conventions")]
        public double OrientationAngle { get; set; } = 0;

        [Description("Contains the start and endrelease of the Bar. The releases defines how the bar is attached to its end nodes")]
        public BarRelease Release { get; set; } = null;

        [Description("Contains the start and endrelease of the Bar. The releases defines how the bar is attached to its end nodes")]
        public BarFEAType FEAType { get; set; } = BarFEAType.Flexural;

        [Description("Linear support for the bar. 3 translational degrees of freedom and one rotational. The rotational defines constraint around the axis of the bar.")]
        public Constraint4DOF Support { get; set; } = null;

        [Description("Offset of the bar as two vectors, one per end node, in bar local coordinates. Defines offsets from centreline to be applied in analysis packages.")]
        public Offset Offset { get; set; } = null;


        /***************************************************/
    }
}

