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

using BH.oM.Schedule.Components;
using System;
using System.ComponentModel;

namespace BH.oM.Schedule.Microsoft.Project.Desktop.Components
{
    [Description("Mock MS Project Desktop baseline object, catching a moment in time within the project programme to determine which activities are ahead or behind schedule")]
    public class Baseline
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual decimal BudgetCost { get; set; }
        public virtual decimal BudgetWork { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual DateTime DeliverableFinish { get; set; }
        public virtual DateTime DeliverableStart { get; set; }
        public virtual Duration Duration { get; set; }
        public virtual Duration DurationEstimated { get; set; }
        public virtual string DurationText { get; set; }
        public virtual DateTime Finish { get; set; }
        public virtual string FinishText { get; set; }
        public virtual decimal FixedCost { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual string StartText { get; set; }
        public virtual decimal Work { get; set; }

        /***************************************************/

        public Baseline()
        { ; }
    }
}
