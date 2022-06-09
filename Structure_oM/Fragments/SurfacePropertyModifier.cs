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


using BH.oM.Quantities.Attributes;
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Structure.Fragments
{
    [Description("Sets modifiers to a SurfaceProperty. The modifiers are used to scale one or more of the property constants for analysis. Constants are multiplied with the modifiers, hence a modifier value of 1 means no change.")]
    public class SurfacePropertyModifier : IFragment
    {
        [Ratio]
        [Description("Modifier of the axial stiffness along the local x-axis. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double FXX { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the axial stiffness along the local y-axis. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double FYY { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the the in-plane shear. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double FXY { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the bending stiffness about the local x-axis. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double MXX { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the bending stiffness about the local y-axis. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double MYY { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the in-plane twist stiffness. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double MXY { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the xz-out of plane shear stiffness. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double VXZ { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the yz-out of plane shear stiffness. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double VYZ { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the mass. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double Mass { get; set; } = 1;

        [Ratio]
        [Description("Modifier of the weight. Value of the SurfaceProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double Weight { get; set; } = 1;
    }
}


