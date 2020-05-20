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

namespace BH.oM.Schedule.Components
{
    public class Duration
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Gets a System.Windows.Duration value that is automatically determined.")]
        // Returns:
        //     A System.Windows.Duration initialized to an automatic value.
        public static Duration Automatic { get; }

        [Description("Gets a System.Windows.Duration value that represents an infinite interval.")]
        // Returns:
        //     A System.Windows.Duration initialized to a forever value.
        public static Duration Forever { get; }

        [Description(" Gets a value that indicates if this System.Windows.Duration represents a System.TimeSpan value")]
        // Returns:
        //     True if this Duration is a System.TimeSpan value; otherwise, false.
        public virtual bool HasTimeSpan { get; private set; }

        /***************************************************/

        [Description("Initializes a new instance of the System.Windows.Duration structure with the supplied System.TimeSpan value.")]
        // Parameters:
        //   timeSpan:
        //     Represents the initial time interval of this duration.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     Occurs when timeSpan is initialized to a negative value.
        public Duration(TimeSpan timeSpan)
        {
            TimeSpan = timeSpan;
            HasTimeSpan = true;
        }


        [Description("Gets the System.TimeSpan value that this System.Windows.Duration represents.")]
        // Returns:
        //     The System.TimeSpan value that this System.Windows.Duration represents.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Occurs if System.Windows.Duration is null.
        public virtual TimeSpan TimeSpan { get; set; }
    }
}
