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
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Offsets;
using BH.oM.Analytical.Elements;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Elements
{

    [Description("1D finite element for structural analysis. Linear 2-noded element defined by a start and end node." +
                 "For structural conventions and orientation of the bar please see https://github.com/BHoM/documentation/wiki/BHoM-Structural-Conventions.")]
    public class Bar : BHoMObject, IElement1D, IElementM, ILink<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Defines the start position of the element. Note that Nodes can contain Supports which should not be confused with Releases.")]
        public virtual Node StartNode { get; set; }

        [Description("Defines the end position of the element. Note that Nodes can contain Supports which should not be confused with Releases.")]
        public virtual Node EndNode { get; set; }

        [Description("Section property of the bar, containing all sectional constants and material as well as profile geometry and dimensions, where applicable.")]
        public virtual ISectionProperty SectionProperty { get; set; } = null;

        [Angle]
        [Description("Controls the local axis orientation of the bar \n" +
                     "For non-vertical members the local z is aligned with the global Z and rotated with the orientation angle about the local x. \n" +
                     "For vertical members the local y is aligned with the global Y and rotated with the orientation angle about the local x. \n"+
                     "A bar is vertical if its projected length to the horizontal plane is less than 0.0001, i.e. a tolerance of 0.1mm on verticality. \n" +
                     "For general structural conventions please see  https://github.com/BHoM/documentation/wiki/BHoM-Structural-Conventions.")]
        public virtual double OrientationAngle { get; set; } = 0;

        [Description("Defines the start and end release of the Bar. The releases defines how the bar is attached to its end nodes. If not set, full fixity will be assumed.")]
        public virtual BarRelease Release { get; set; } = null;

        public virtual BarFEAType FEAType { get; set; } = BarFEAType.Flexural;

        [Description("Linear support for the bar. Three translational degrees of freedom and one rotational. The rotational DOF defines constraint about the axis of the bar.")]
        public virtual Constraint4DOF Support { get; set; } = null;

        [Description("Offset of the bar as two vectors, one per end node, in bar local coordinates. Defines offsets from centreline to be applied in analysis packages.")]
        public virtual Offset Offset { get; set; } = null;


        /***************************************************/
    }
}



