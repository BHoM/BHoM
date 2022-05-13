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
using BH.oM.Base.Attributes;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BH.oM.Graphics
{
    [Description("Texture material for rendering of geometry.")]
    public class Texture : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name of the Texture")]
        public override string Name { get; set; } = "";

        [Description("Diffuse color is the most instinctive meaning of the color of an object. It is that essential color that the object reveals under pure white light. It is perceived as the color of the object itself rather than a reflection of the light. Alpha channel is generally ignored. Default is BHoM Coral (Color.FromArgb(255, 255, 41, 105)).")]
        public virtual Color Diffuse { get; set; } = Color.FromArgb(255, 255, 41, 105);

        [Description("This is the self-illumination color an object has. Alpha channel is generally ignored. Default is a darker BHoM Coral (Color.FromArgb(255, 77, 12, 32))")]
        public virtual Color Emission { get; set; } = Color.FromArgb(255, 77, 12, 32);

        [Description("Ambient color is the color of an object where it is in shadow. This color is what the object reflects when illuminated by ambient light rather than direct light. Alpha channel is generally ignored. Default is Gray.")]
        public virtual Color Ambient { get; set; } = Color.Gray;

        [Description("Specular color is the color of the light of a specular reflection (specular reflection is the type of reflection that is characteristic of light reflected from a shiny surface). Alpha channel is generally ignored. Default is White.")]
        public virtual Color Specular { get; set; } = Color.White;

        [Description("Level of transparency of the material. Should be a value between 0 and 1, where 0.0 is opaque and 1.0 is transparent. Defaults to fully opaque.")]
        public virtual double Transparency { get; set; } = 0.0;

        [Description("Shine factor of the material. Should be a value between 0 and 1, where 0 is no shine and 1 is full shine.")]
        public virtual double Shine { get; set; } = 0.5;

        [FilePath]
        [Description("Optional file path to a image file to use as bitmap texture for the material.")]
        public virtual string BitmapTexture { get; set; } = "";

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Converts a colour to a texture.")]
        public static explicit operator Texture(Color diffuseColour)
        {
            return new Texture
            {
                Diffuse = diffuseColour,
                Emission = Color.FromArgb(diffuseColour.A, (int)Math.Round(diffuseColour.R * 0.3), (int)Math.Round(diffuseColour.G * 0.3), (int)Math.Round(diffuseColour.B * 0.3)),
                Specular = Color.White,
                Ambient = Color.Gray,
                Transparency = (double)(255 - diffuseColour.A) / 255.0,
                Shine = 0.5
            };
        }

        /***************************************************/

    }
}


