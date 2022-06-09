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
using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;

namespace BH.oM.Lighting.Elements
{
    [Description("A LuminaireType containing manufacturer, dimensional, and other property data applied to a Luminaire.")]
    public class LuminaireType : BHoMObject
    {
        [Description("Name of the Manufacturer of this LuminaireType")]
        public virtual string Manufacturer { get; set; } = "";

        [Description("Boundary Representation of the LuminaireType's Geometry")]
        public virtual BoundaryRepresentation LuminaireGeometry { get; set; } = null;

        [Description("Total Load of the LuminaireType")]
        public virtual double Load { get; set; } = 0.0;

        [Description("Total Flux of the LuminaireType")]
        public virtual double Flux { get; set; } = 0.0;

        [Description("Number of lamps included in this LuminaireType")]
        public virtual int NumberOfLamps { get; set; } = 1;

        [Description("Mounting type eg Wall-Mounted, Ceiling Recessed, etc)")]
        public virtual string MountingType { get; set; } = "";

        [Description("General description")]
        public virtual string Description { get; set; } = "";

        [Description("Model name of the LuminaireType as per the Manufacturer")]
        public virtual string Model { get; set; } = "";
    }
}


