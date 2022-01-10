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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    /***************************************************/

    public class Output<T> : IObject, IOutput
    {
        public virtual T Item1 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }

        public virtual T4 Item4 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4, T5> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }

        public virtual T4 Item4 { get; set; }

        public virtual T5 Item5 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4, T5, T6> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }

        public virtual T4 Item4 { get; set; }

        public virtual T5 Item5 { get; set; }

        public virtual T6 Item6 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4, T5, T6, T7> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }

        public virtual T4 Item4 { get; set; }

        public virtual T5 Item5 { get; set; }

        public virtual T6 Item6 { get; set; }

        public virtual T7 Item7 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4, T5, T6, T7, T8> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }

        public virtual T4 Item4 { get; set; }

        public virtual T5 Item5 { get; set; }

        public virtual T6 Item6 { get; set; }

        public virtual T7 Item7 { get; set; }

        public virtual T8 Item8 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }

        public virtual T4 Item4 { get; set; }

        public virtual T5 Item5 { get; set; }

        public virtual T6 Item6 { get; set; }

        public virtual T7 Item7 { get; set; }

        public virtual T8 Item8 { get; set; }

        public virtual T9 Item9 { get; set; }
    }

    /***************************************************/

    public class Output<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IObject, IOutput
    {
        public virtual T1 Item1 { get; set; }

        public virtual T2 Item2 { get; set; }

        public virtual T3 Item3 { get; set; }

        public virtual T4 Item4 { get; set; }

        public virtual T5 Item5 { get; set; }

        public virtual T6 Item6 { get; set; }

        public virtual T7 Item7 { get; set; }

        public virtual T8 Item8 { get; set; }

        public virtual T9 Item9 { get; set; }

        public virtual T10 Item10 { get; set; }
    }

    /***************************************************/
}



