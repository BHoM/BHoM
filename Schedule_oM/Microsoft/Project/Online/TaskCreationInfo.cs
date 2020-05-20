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

using System;
using System.ComponentModel;

namespace BH.oM.Schedule.Microsoft.Project.Online.Components
{
    [Description("Mock MS Project Online TaskCreationInfo object")]
    public class TaskCreationInfo
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual bool IsManual { get; set; }
        public virtual DateTime Finish { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual Guid AddAfterId { get; set; }
        public virtual Guid Id { get; set; }
        public virtual Guid ParentId { get; set; }
        public virtual string TypeId { get; }
        public virtual string Duration { get; set; }
        public virtual string Name { get; set; }
        public virtual string Notes { get; set; }
        public virtual User StatusManager { get; set; }

        /***************************************************/
        
        public TaskCreationInfo()
        { ; }
    }
}
