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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BH.oM.Base
{
    public abstract class Enumeration : IObject, IEnum 
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual string Value { get; private set; }

        public virtual string Description
        {
            get
            {
                return m_Description.Length > 0 ? m_Description : Value;
            }
            private set
            {
                m_Description = value;
            }
        }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected Enumeration(string value, string description = "")
        {
            Value = value;
            m_Description = description;
        }


        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public override string ToString()
        {
            return Value;
        }

        /***************************************************/

        public override bool Equals(object obj)
        {
            Enumeration otherValue = obj as Enumeration;
            if (otherValue == null)
                return false;

            return GetType().Equals(obj.GetType())
                && Value.Equals(otherValue.Value);
        }  

        /***************************************************/

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /***************************************************/

        public int CompareTo(IEnum other)
        {
            return Value.CompareTo(other?.Value);
        }


        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        private string m_Description = "";


        /***************************************************/
        /**** Static Methods                            ****/
        /***************************************************/

        public static bool Equals(IEnum a, IEnum b)
        {
            if (a == null || b == null)
                return false;

            return a.GetType().Equals(b.GetType())
                && a.Value.Equals(b.Value);
        }

        /***************************************************/

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();
        } 

        /***************************************************/
    }
}



