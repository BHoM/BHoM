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
using BH.oM.Dimensional;
using BH.oM.Geometry.CoordinateSystem;
using BH.oM.Quantities.Attributes;
using BH.oM.Spatial.ShapeProfiles;
using System.ComponentModel;

namespace BH.oM.Architecture.BuildersWork
{
    [Description("Object representing a builders work opening as an entity independent of its host.")]
    public class Opening : BHoMObject, IElement0D
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Profile of the opening.")]
        public virtual IProfile Profile { get; set; } = null;

        [Length]
        [Description("Total depth of the opening, distributed equally from the origin in both directions along the local z axis.")]
        public virtual double Depth { get; set; } = 0;

        [Description("Local coordinate system of the opening with local z being the direction along the opening, local x representing direction along width in plane and y along height respectively.")]
        public virtual Cartesian CoordinateSystem { get; set; } = new Geometry.CoordinateSystem.Cartesian();

        /***************************************************/
    }
}



