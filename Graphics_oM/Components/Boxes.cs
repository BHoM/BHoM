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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Components
{
    [Description("Rectangular box configuration for representation of entity boundaries.")]
    public class Boxes : BHoMObject, IComponent
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual string Text { get; set; } = "";

        public virtual string Colour { get; set; } = "";

        public virtual string Group { get; set; } = "";

        public virtual string GroupOrder { get; set; } = "";

        public virtual double Padding { get; set; } = 0;

        public virtual bool IsHorizontal { get; set; } = false;

        public virtual List<string> GroupsToIgnore { get; set; } = new List<string>();
    }
}


