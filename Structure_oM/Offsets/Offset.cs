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
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Offsets
{
    [Description("Class defining offsets for bar objects from its end Nodes to be applied in analysis packages.")]
    public class Offset : BHoMObject, IProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Defines offset of the StartNode in local coordinates. This is x - tangential, z- along normal (generally major axis), y - perpendicular to the first two (generally minor axis).")]
        public virtual Vector Start { get; set; } = new Vector();

        [Length]
        [Description("Defines offset of the EndNode in local coordinates. This is x - tangential, z- along normal (generally major axis), y - perpendicular to the first two (generally minor axis).")]
        public virtual Vector End { get; set; } = new Vector();

        /***************************************************/
    }
}



