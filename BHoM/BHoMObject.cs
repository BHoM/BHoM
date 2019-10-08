/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

namespace BH.oM.Base
{
    public class BHoMObject : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Guid BHoM_Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = "";

        public FragmentSet<IBHoMFragment> Fragments { get; set; } = new FragmentSet<IBHoMFragment>();

        public HashSet<string> Tags { get; set; } = new HashSet<string>();

        public Dictionary<string, object> CustomData { get; set; } = new Dictionary<string, object>();


        /***************************************************/
        /**** Public Local Methods                      ****/
        /***************************************************/

        public IBHoMObject GetShallowClone(bool newGuid = false)
        {
            BHoMObject obj = (BHoMObject)this.MemberwiseClone();

            if (CustomData != null)
                obj.CustomData = new Dictionary<string, object>(CustomData);
            else
                obj.CustomData = new Dictionary<string, object>();

            if (Tags != null)
                obj.Tags = new HashSet<string>(Tags);
            else
                obj.Tags = new HashSet<string>();

            if (newGuid)
                obj.BHoM_Guid = Guid.NewGuid();

            return obj;
        }

        /***************************************************/
    }
}
