/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Reflection.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    public class Delta : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IBHoMObject> NewObjects { get; }

        public List<IBHoMObject> OldObjects { get; }

        public List<IBHoMObject> ModifiedObjects { get; }

        [Description("The Key is the modified object hash. The Value is another Dictionary, whose Key is the name of the modified property, while Value.Item1 is the property value in setA, Value.Item2 in setB.")]
        public Dictionary<string, Dictionary<string, Tuple<object, object>>> ModifiedPropsPerObject { get; }

        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        [Description("Creates new Delta object with information on the new, old or modified object, and (if exists) the Diffing Stream that contains them.")]
        [Input("newObjects", "Objects existing exclusively in the 'primary' set, i.e. the 'new' objects.")]
        [Input("oldObjects", "Objects existing exclusively in the 'secondary' set, i.e. the 'old' objects.")]
        [Input("modifiedObjects", "Objects existing in both sets that have some differences in their properties.")]
        [Input("modifiedPropsPerObject", "Dictionary holding the differences in properties of the 'modified' objects. See the corresponding property description for more info.")]
        public Delta(List<IBHoMObject> newObjects, List<IBHoMObject> oldObjects, List<IBHoMObject> modifiedObjects, Dictionary<string, Dictionary<string, Tuple<object, object>>> modifiedPropsPerObject = null)
        {
            NewObjects = newObjects;
            OldObjects = oldObjects;
            ModifiedObjects = modifiedObjects;
            ModifiedPropsPerObject = modifiedPropsPerObject;
        }

        /***************************************************/
    }
}

