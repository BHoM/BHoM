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

namespace BH.oM.Structure.Constraints
{
    [Description("Defines the rigid connectivity between a master and set of slave nodes.")]
    public class LinkConstraint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("True defines a rigid connectivity between master and slave for translations along the X-axis, i.e. true prohibits relative translation along the X-axis between master and slave.")]
        public bool XtoX { get; set; } = false;

        [Description("True defines a rigid connectivity between master and slave for translations along the Y-axis, i.e. true prohibits relative translation along the Y-axis between master and slave.")]
        public bool YtoY { get; set; } = false;

        [Description("True defines a rigid connectivity between master and slave for translations along the Z-axis, i.e. true prohibits relative translation along the Z-axis between master and slave.")]
        public bool ZtoZ { get; set; } = false;

        [Description("True means that a X-translation imposes a rigid Y-axis rotation.")]
        public bool XtoYY { get; set; } = false;

        [Description("True means that a X-translation imposes a rigid Z-axis rotation.")]
        public bool XtoZZ { get; set; } = false;

        [Description("True means that a Y-translation imposes a rigid X-axis rotation.")]
        public bool YtoXX { get; set; } = false;

        [Description("True means that a Y-translation imposes a rigid Z-axis rotation.")]
        public bool YtoZZ { get; set; } = false;

        [Description("True means that a Z-translation imposes a rigid X-axis rotation.")]
        public bool ZtoXX { get; set; } = false;

        [Description("True means that a Z-translation imposes a rigid Y-axis rotation.")]
        public bool ZtoYY { get; set; } = false;

        [Description("True defines a rigid connectivity between master and slave for rotations about the X-axis, i.e. true prohibits relative rotation about the X-axis between master and slave.")]
        public bool XXtoXX { get; set; } = false;

        [Description("True defines a rigid connectivity between master and slave for rotations about the Y-axis, i.e. true prohibits relative rotation about the Y-axis between master and slave.")]
        public bool YYtoYY { get; set; } = false;

        [Description("True defines a rigid connectivity between master and slave for rotations about the Z-axis, i.e. true prohibits relative rotation about the Z-axis between master and slave.")]
        public bool ZZtoZZ { get; set; } = false;


        /***************************************************/
    }
}
