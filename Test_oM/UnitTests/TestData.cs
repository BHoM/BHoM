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

using BH.oM.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Test.UnitTests
{
    [Description("Defines input data and expected output data for one run of a particular unit test.")]
    public class TestData : BHoMObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Inputs to the method. Inputs are matched based on index in the list, i.e. index 0 in this list will be used as the first parameter of the method tested.")]
        public virtual ReadOnlyCollection<object> Inputs { get; set; }

        [Description("The expected outputs from the method for the provided inputs.\n" +
                     "The length of this collection will only be greater than one if the method being tested returns an Output<T1,..,Tn>, for which the indices will match the ones of the Output<>.\n" +
                     "This means methods returning a collection will be seen as returning one object, where the object is the collection.")]
        public virtual ReadOnlyCollection<object> Outputs { get; set; } = null;


        /***************************************************/

        public TestData(IEnumerable<object> inputs, IEnumerable<object> outputs)
        {
            Inputs = new ReadOnlyCollection<object>(inputs == null ? new List<object>() : inputs.ToList());
            Outputs = new ReadOnlyCollection<object>(outputs == null ? new List<object>() : outputs.ToList());
        }

        /***************************************************/
    }
}
