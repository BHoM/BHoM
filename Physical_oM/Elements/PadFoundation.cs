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

using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Physical.Constructions;
using System.ComponentModel;

namespace BH.oM.Physical.Elements
{
    [Description("Physical representation of a flat pad foundation (parallel top and bottom faces).")]
    public class PadFoundation : BHoMObject, IBHoMObject, IPhysical, IElement2D, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("PlanarSurface defining the top face of a pad foundation.")]
        public virtual BH.oM.Geometry.PlanarSurface Location { get; set; } = null;

        [Description("Construction of the pad foundation defining its thickness and Material.")]
        public virtual IConstruction Construction { get; set; } = new Construction();

        /***************************************************/
    }
}




