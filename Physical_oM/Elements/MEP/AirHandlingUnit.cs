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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Physical.ConduitProperties;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Physical.Elements
{
    [Description("A pipe object is a passageway which conveys material (water, waste, glycol)")]
    public class AirHandlingUnit : BHoMObject, IEquipment, ICompositeEquipment
    {
        /***************************************************/
        /**** Physical Only Properties                   ****/
        /***************************************************/

        //public virtual IdentifyingData IdentifyingData { get; set; }
        public virtual Point Location { get; set; }
        public virtual List<Connector> Connections { get; set; }

        public virtual List<IPart> Parts { get; set; } = new List<IPart>();

        /***************************************************/
    }
}


