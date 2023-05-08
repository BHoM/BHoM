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

using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Physical.Materials
{
    [Description("Defines the make up of an object through a list of Materials and their corresponding quantities corresponding to each material.")]
    public class GeneralMaterialTakeoff : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("List of the the materials with corresponding qunatities relevant to the particular material.")]
        public virtual List<TakeoffItem> MaterialTakeoffItems { get; set; } = new List<TakeoffItem>();


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Converts a VolumetricMaterialTakeoff to a GeneralMaterialTakeoff, collection information about Material, volume and mass as well as general BHoM properties from the Volumetric takeoff. All other properties are set to default values.")]
        public static explicit operator GeneralMaterialTakeoff(VolumetricMaterialTakeoff volTakeoff)
        {
            if(volTakeoff == null)
                return null;

            List<TakeoffItem> items = new List<TakeoffItem>();

            for (int i = 0; i < volTakeoff.Materials.Count; i++)
            {
                Material mat = volTakeoff.Materials[i];
                double volume = volTakeoff.Volumes[i];
                items.Add(new TakeoffItem
                {
                    Material = mat,
                    Volume = volume,
                    Mass = volume*mat.Density
                });
            }

            return new GeneralMaterialTakeoff 
            {
                MaterialTakeoffItems  = items, 
                CustomData = new Dictionary<string, object>(volTakeoff.CustomData),
                Name = volTakeoff.Name,
                Tags = new HashSet<string>(volTakeoff.Tags),
                Fragments = new FragmentSet(volTakeoff.Fragments)
            };
        }

        /***************************************************/

    }
}


