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

using System.ComponentModel;

namespace BH.oM.Quantities.Base
{
    /***************************************************/

    [Description("The dimension symbols for the base quantaties as defined by the International System of Quantities.")]
    public enum Dimension
    {
        [Description("1")]
        Dimensionless =  1,

        [Description("Length")]
        L,

        [Description("Mass")]
        M,

        [Description("Time")]
        T,

        [Description("Electric current")]
        I,

        [Description("Temperature")]
        Θ,

        [Description("Amount of substance")]
        N,

        [Description("Luminous intensity")]
        J,
    }

    /***************************************************/

}
