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

using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    [Description("Dependency fragment used to define one or more Relations that originate at the specified sources and use the IBHoMObject owning this fragment as the target.")]
    public class SourcesDependencyFragment : IDependencyFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Collection of Guids of entities that are sources for Relations where the IBHoMObject owning this fragment is the target.")]
        public virtual List<Guid> Sources { get; set; }

        [Description("Collection of ICurves used to represent the Relations.")]
        public virtual List<ICurve> Curves { get; set; }

        /***************************************************/
    }
}

