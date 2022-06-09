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

namespace BH.oM.Data.Collections
{
    public class DiscretePoint : IDataStructure, IComparable<DiscretePoint>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual int X { get; set; } = 0;
        public virtual int Y { get; set; } = 0;
        public virtual int Z { get; set; } = 0;


        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(DiscretePoint other)
        {
            if (X != other.X)
                return X.CompareTo(other.X);
            else if (Y != other.Y)
                return Y.CompareTo(other.Y);
            else
                return Z.CompareTo(other.Z);
        }

        /***************************************************/

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /***************************************************/

        public override bool Equals(object obj)
        {
            if (obj is DiscretePoint)
            {
                DiscretePoint other = (DiscretePoint)obj;
                return ((this.X == other.X) && (this.Y == other.Y) && (this.Z == other.Z));
            }
            return false;
        }

        /***************************************************/
    }
}



