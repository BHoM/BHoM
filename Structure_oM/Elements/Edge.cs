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

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.Constraints;
using BH.oM.Analytical.Elements;

namespace BH.oM.Structure.Elements
{
    /// <summary>
    /// BH.oM edge class to describe the edges of panels (or other objects) by a curve plus properties
    /// </summary>
    public class Edge : BHoMObject, IElement1D, IEdge
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
                
        public ICurve Curve { get; set; }
        public Constraint4DOF Release { get; set; } = null;
        public Constraint6DOF Support { get; set; } = null;

        
        /***************************************************/
    }
}
       
