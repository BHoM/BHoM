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

namespace BH.oM.Structure.SurfaceProperties
{
    /***************************************************/
    public enum PanelModifier
    {
        //In plane axial stiffness in the local X direction
        f11 = 0,
        //In plane axial stiffness in the local XY direction
        f12,
        //In plane axial stiffness in the local Y direction
        f22,
        //In plane flexural stiffness in the local X direction
        m11,
        //In plane flexural stiffness in the local XY direction
        m12,
        //In plane flexural stiffness in the local Y direction
        m22,
        //Shear stiffness in the X - normal direction
        v13,
        //Shear stiffness in the Y - normal direction
        v23,
        //Mass modifier
        Mass,
        //weight modifier
        Weight
    }
    /***************************************************/
}
