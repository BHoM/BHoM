/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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

using BH.oM.Base;

namespace BH.oM.Common.Properties
{
    public class Object2DProperties : BHoMObject
    {
        public List<CompoundLayer> CompoundLayers { get; set; } = new List<CompoundLayer>();

        /*
        Methods to implement in BHoM_Engine
        
        //Query
        
        public static double Thickness(this Object2DProperties object2DProperties)
        {
            if(object2DProperties == null || object2DProperties.CompoundLayers == null)
                return double.NaN
                
            double aResult = 0;
             object2DProperties.CompoundLayers.ForEach(x => aResult += x.Thickness)

            return aResult;
        }

        //Modify

        public static Object2DProperties AddCompoundLayer(this Object2DProperties object2DProperties, Material material, double thickness)
        {
            object2DProperties.CompoundLayers.Add(Create.CompoundLayer(material, thickness));
        }

        */
    }
}
