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
using BH.oM.Structure.MaterialFragments;
using BH.oM.Spatial.Layouts;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.Structure.Reinforcement
{
    [Description("Defines the  reinforcement of a Panel in the longitudinal and transverse direction specified by the Basis of the ReinforcementRegion.\n" +
        "If the diameter of the reinforcement is set to 0, it will be assumed that no reinforcement is present in this direction.")]
    public class PanelReinforcement : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Material of the reinforcement.")]
        public virtual IMaterialFragment Material { get; set; }

        [Description("The region defining the area of the Panel to be reinforced.")]
        public virtual ReinforcementRegion Region { get; set; }

        [Length]
        [Description("The diameter of the reinforcement in the longitudinal direction, denoted by the local x direction of the ReinforcementRegion.\n" +
            "If the diameter is set 0, it will be assumed that no reinforcement is present in the longitudinal direction.")]
        public virtual double LongitudinalDiameter { get; set; }

        [Length]
        [Description("The spacing of the reinforcement in the longitudinal direction, measured perpindicular to the local x direction of the ReinforcementRegion.")]
        public virtual double LongitudinalSpacing { get; set; }

        [Length]
        [Description("The depth of longitudinal reinforcement measured from the centre of Panel along the normal. This will be negative for bottom reinforcement.")]
        public virtual double LongitudinalDepth { get; set; }

        [Length]
        [Description("The diameter of the reinforcement in the transverse direction, denoted by the local y direction of the ReinforcementRegion.\n" +
            "If the diameter is set 0, it will be assumed that no reinforcement is present in the longitudinal direction.")]
        public virtual double TransverseDiameter { get; set; }

        [Length]
        [Description("The spacing of the reinforcement in the transverse direction, measured perpindicular to the local y direction of the ReinforcementRegion.")]
        public virtual double TransverseSpacing { get; set; }

        [Length]
        [Description("The depth of transverse reinforcement measured from the centre of Panel along the normal. This will be negative for bottom reinforcement.")]
        public virtual double TransverseDepth { get; set; }

        [Length]
        [Description("Minimum cover for the reinforcement defined in this PanelReinforcement.")]
        public virtual double MinimumCover { get; set; }
        /***************************************************/
    }
}


