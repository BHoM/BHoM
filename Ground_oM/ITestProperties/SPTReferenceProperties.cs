/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Ground
{

    [Description("Properties related references and location of the standard penetration test.")]
    public class SPTReferenceProperties : BHoMObject, ITestProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Associated file reference (FILE_FSET).")]
        public virtual string FileReference { get; set; }

        [Description("Remarks or Comments (ISPT_REM).")]
        public virtual string Remarks { get; set; }

        /***************************************************/
    }
}
