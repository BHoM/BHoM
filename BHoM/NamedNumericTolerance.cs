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

using System.ComponentModel;

namespace BH.oM.Base
{
    [Description("Tolerance used for specific numerical objects or properties with a specific name." +
        "When computing Hash or the property Diffing, if the analysed object or property name is found in this collection, the corresponding tolerance is considered.")]
    public class NamedNumericTolerance : IObject
    {
        [Description("When computing Hash or the property Diffing, if the analysed object name or property name is found in this collection, the corresponding tolerance is applied." +
            "\nSupports * wildcard in the property name matching. Examples: " +
            "\n\t - `BH.oM.Geometry.Vector`: applies the corresponding tolerance to all numerical properties of Vectors, i.e. X, Y, Z;" +
            "\n\t - `BH.oM.Structure.Elements.*.Position`: applies the corresponding tolerance to all numerical properties of properties named `Position` under any Structural Element," +
            "\n\t    e.g. Bar.Position.X, Bar.Position.Y, Bar.Position.Z. and at the same time also Node.Position.X, Node.Position.Y, Node.Position.Z.")]
        public virtual string Name { get; set; }

        [Description("Numeric tolerance. Applies rounding for numbers smaller than this. Defaults to 1E-12.")]
        public virtual double Tolerance { get; set; } = 1e-12;
    }
}
