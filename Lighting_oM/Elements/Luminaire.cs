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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Dimensional;
using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;

namespace BH.oM.Lighting.Elements
{
    public class Luminaire : BHoMObject, IElement0D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Position of the Luminaire in global Cartesian 3D space.")]
        public virtual Point Position { get; set; } = null;

        [Description("The type of the Luminaire (e.g. recessed cove, task lighting, etc)")]
        public virtual string Type { get; set; } = "";

        [Description("The direction that the Luminaire is oriented towards.")]
        public virtual Vector Direction { get; set; } = new Vector();

        [Description("The Luminaire Type applied to the Luminaire.")]
        public virtual LuminaireType LuminaireType { get; set; } = new LuminaireType();

        /***************************************************/
    }
}


