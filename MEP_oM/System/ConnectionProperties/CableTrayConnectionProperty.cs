/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.MEP.System.ConnectionProperties;

namespace BH.oM.MEP.System.ConnectionProperties
{
    [Description("A Cable Tray connection property to store information about its physical connectors.")]
    public class CableTrayConnectionProperty : BHoMObject, IConnectionProperty
    {
        /***************************************************/
        /****                 Properties                ****/
        /***************************************************/

        [Description("The point at which the Connector object begins.")]
        public virtual Point StartPoint { get; set; }

        [Description("The point at which the Connector bject ends.")]
        public virtual Point EndPoint { get; set; }

        [Description("Whether the start point of the Cable Tray is connected to another segment or not.")]
        public virtual bool IsStartConnected { get; set; }

        [Description("Whether the end point of the Cable Tray is connected to another segment or not.")]
        public virtual bool IsEndConnected { get; set; }       

        /***************************************************/
    }
}

