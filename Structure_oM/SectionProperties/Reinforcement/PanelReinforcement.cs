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

using BH.oM.Base;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Spatial.Layouts;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.Structure.SectionProperties.Reinforcement
{
    [Description("Defines the  reinforcement of a Panel in the longitudinal and transverse direction specified by the Basis of the ReinforcementRegion.")]
    public class PanelReinforcement : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Material of the reinforcement.")]
        public virtual IMaterialFragment Material { get; set; }

        [Description("The region defining the area of the Panel to be reinforced.")]
        public virtual ReinforcementRegion Region { get; set; }

        [Description("The diameter of the longitudinal reinforcement.")]
        public virtual double LongitudinalDiameter { get; set; }

        [Description("The spacing of longitudinal reinforcement.")]
        public virtual double LongitudinalSpacing { get; set; }

        [Description("The depth of longitudinal reinforcement measured from the centre of Panel. This will be negative for bottom reinforcement.")]
        public virtual double LongitudinalDepth { get; set; }

        [Description("The diameter of the transverse reinforcement.")]
        public virtual double TransverseDiameter { get; set; }

        [Description("The spacing of transverse reinforcement.")]
        public virtual double TransverseSpacing { get; set; }

        [Description("The depth of transverse reinforcement measured from the centre of Panel. This will be negative for bottom reinforcement.")]
        public virtual double TransverseDepth { get; set; }

        [Description("Minimum cover for the reinforcement defined in this PanelReinforcement.")]
        public virtual double MinimumCover { get; set; }
        /***************************************************/
    }
}

