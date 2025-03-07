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

    [Description("A set of data related to triaxial tests carried out")]
    public class Triaxial : BHoMObject, ITest
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Location identifier relating the borehole to the strata (LOCA_ID).")]
        public virtual string Id { get; set; }

        [Length]
        [Description("Depth to the top of the sample, measured from the top of the borehole (SAMP_TOP).")]
        public virtual double Top { get; set; }

        [Length]
        [Description("Depth to the top of the specimen (SPEC_DPTH).")]
        public virtual double SpecimenDepth { get; set; }

        [Description("Triaxial test/stage reference (TRIT_TESN).")]
        public virtual string TriaxialReference { get; set; }

        [Description("Sample Identification (SAMP_ID).")]
        public virtual string SampleID { get; set; }

        [Description("Specimen Reference (SPEC_REF).")]
        public virtual string SpecimenReference { get; set; }

        [Description("A list of different properties including references and results.")]
        public virtual List<ITestProperties> Properties { get; set; }

        [Pressure]
        [Description("Undrained shear strength at failure (TRIT_CU).")]
        public virtual double UndrainedShearStrength { get; set; }

        [Description("Mode of Failure (TRIT_MODE).")]
        public virtual string FailureMode { get; set; }

        /***************************************************/
    }
}





