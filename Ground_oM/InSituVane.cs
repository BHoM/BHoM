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


using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;

namespace BH.oM.Ground
{

    [Description("A representation of an in-situ vane test defined by the borehole where the test was carried out and the result.")]
    public class InSituVane : BHoMObject, ITest
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Location identifier relating the borehole to the test (LOCA_ID).")]
        public virtual string Id { get; set; }

        [Length]
        [Description("Depth to the top of the sample, measured from the top of the borehole (IVAN_DEPTH).")]
        public virtual double Top { get; set; }

        [Description("Name of Test (LBST_TEST).")]
        public virtual string TestName { get; set; }

        [Description("A list of different properties including references, tests, analysis, results and detection.")]
        public virtual List<ITestProperties> Properties { get; set; }

        [Pressure]
        [Description("Vane Test Result (IVAN_IVAN).")]
        public virtual double VaneResult { get; set; }

        /***************************************************/
    }
}





