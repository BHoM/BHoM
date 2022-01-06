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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BH.oM.Base
{
    public class FragmentSet : KeyedCollection<Type, IFragment>, IObject
    {
        public FragmentSet()
        {
        }

        public FragmentSet(FragmentSet fragmentSet)
        {
            if (fragmentSet != null && fragmentSet.Dictionary != null && fragmentSet.Dictionary.Count != 0)
                fragmentSet.Dictionary.Values.Where(x => x != null).ToList().ForEach(v => this.Add(v));
        }

        public FragmentSet(List<IFragment> fragments)
        {
            fragments.Where(x => x != null).ToList().ForEach(v => this.Add(v));
        }

        public bool AddOrReplace(IFragment fragment) // Slower than Add() or SetItem(), but easier to use.
        {
            int? idx = this.Dictionary?.Keys.ToList().IndexOf(fragment.GetType());

            if (idx == null || idx == -1)
                base.Add(fragment);
            else
                base.SetItem((int)idx, fragment);
            return true;
        }

        protected override Type GetKeyForItem(IFragment item)
        {
            return item.GetType();
        }
    }
}



