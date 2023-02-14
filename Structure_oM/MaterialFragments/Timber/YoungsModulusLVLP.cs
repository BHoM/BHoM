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

using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class YoungsModulusLVLP : IYoungsModulusTimber
    {

        [YoungsModulus]
        [Description("Mean modulus of elasticity parallel to grain, E0,mean in Eurocode. Value same for Em,0,edge,mean, Et,0,mean, Em,0,flat,mean, and Ec,0,mean.")]
        public virtual double ParallelMean { get; set; }

        [YoungsModulus]
        [Description("Characteristic modulus of elasticity parallel to grain, E0,k in Eurocode. Value same for Em,0,edge,k, Et,0,k, Em,0,flat,k, and Ec,0,k.")]
        public virtual double ParallelCharacteristic { get; set; }

        [YoungsModulus]
        [Description("Edgewise mean modulus of elasticity perpendicular to grain, Ec,90,edge,mean in Eurocode. Value same for Et,90,edge,mean.")]
        public virtual double PerpendicularEdgeMean { get; set; }

        [YoungsModulus]
        [Description("Edgewise characteristic modulus of elasticity perpendicular to grain, Ec,90,edge,k in Eurocode. Value same for Et,90,edge,k.")]
        public virtual double PerpendicularEdgeCharacteristic { get; set; }
    }
}
