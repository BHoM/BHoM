/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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
using BH.oM.Structure.Loads;
using System.ComponentModel;

namespace BH.oM.Structure.Loads
{
    [Description("Defines a time history analysis case with time integration parameters.")]
    public class TimeHistoryLoadcase : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Unique name identifying the time history load case.")]
        public virtual string Name { get; set; }

        [Description("Numerical identifier for the load case.")]
        public virtual int Number { get; set; }

        [Description("End time of the time history analysis in seconds.")]
        public virtual double EndTime { get; set; }

        [Description("Time step used for the integration in seconds.")]
        public virtual double TimeStep { get; set; }

        [Description("Base load case whose magnitude is scaled at each time step.")]
        public virtual string InitialLoadCase { get; set; }

        /***************************************************/
    }
}








