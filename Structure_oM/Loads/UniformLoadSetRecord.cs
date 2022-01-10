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
using BH.oM.Base.Attributes;

namespace BH.oM.Structure.Loads
{
    [Description("Definition of a single uniform load in the gravity direction (-Z), to be added to a UniformLoadSet.")]
    public class UniformLoadSetRecord : BHoMObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("Description of the source of this load, such as: 'Partitions', 'Occupancy', or 'MEP & Ceiling'")]
        public override string Name { get; set; } = "";

        [Description("The Loadcase in which to apply this load.")]
        public virtual Loadcase Loadcase { get; set; } = null;

        [Description("The magnitude of this load, generally to be applied as an AreaUniformLoad in the gravity direction (-Z)")]
        [Pressure]
        public virtual double Load { get; set; } = 0;
        /***************************************************/
    }

}


