/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;
using BH.oM.Dimensional;

using BH.oM.Structure.SectionProperties;

namespace BH.oM.Structure.Elements
{
    [Description("A pile object defined by it's location and section.")]
    public class Pile : BHoMObject, IFoundation, IElement1D, IElementM
    {
        [Description("Defines the top Node. Note that Nodes can contain Supports.")]
        public virtual Node TopNode { get; set; }

        [Description("Defines the end position of the Pile. Note that Nodes can contain Supports.")]
        public virtual Node BottomNode { get; set; }


        [Description("Section property of the Pile, containing all sectional constants and material as well as profile geometry and dimensions, where applicable.")]
        public virtual ISectionProperty Section { get; set; }

        [Angle]
        [Description("Controls the local axis orientation of the Pile \n" +
             "For non-vertical members the local z is aligned with the global Z and rotated with the orientation angle about the local x. \n" +
             "For vertical members the local y is aligned with the global Y and rotated with the orientation angle about the local x. \n" +
             "A Pile is vertical if its projected length to the horizontal plane is less than 0.0001, i.e. a tolerance of 0.1mm on verticality. \n" +
             "For general structural conventions please see the documentation.")]
        [DocumentationURL("https://bhom.xyz/documentation/Conventions/BHoM-Structural-Conventions/", DocumentationType.Documentation)]
        public virtual double OrientationAngle { get; set; } = 0;

    }
}
