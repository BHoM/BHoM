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

using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Quantities.Attributes;
using BH.oM.Reflection.Attributes;

namespace BH.oM.Structure.Loads
{
    [Description("Definition of a set of uniform loads in the gravity direction (-Z).")]
    public class UniformLoadSet : BHoMObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("Description of this set of loads, as would appear on a load map")]
        public override string Name { get; set; } = "";

        [Description("The individual load items for the load set")]
        public virtual List<UniformLoadSetRecord> Loads { get; set; } = new List<UniformLoadSetRecord>();
        /***************************************************/
    }
}


