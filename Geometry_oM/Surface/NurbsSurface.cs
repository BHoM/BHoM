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

using BH.oM.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BH.oM.Geometry
{
    public class NurbsSurface : ISurface, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ReadOnlyCollection<Point> ControlPoints { get; }

        public ReadOnlyCollection<double> Weights { get; }

        public ReadOnlyCollection<double> UKnots { get; }

        public ReadOnlyCollection<double> VKnots { get; }

        public int UDegree { get; }

        public int VDegree { get; }

        public ReadOnlyCollection<SurfaceTrim> InnerTrims { get; }

        public ReadOnlyCollection<SurfaceTrim> OuterTrims { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NurbsSurface(IEnumerable<Point> controlPoints, IEnumerable<double> weights, IEnumerable<double> uKnots, IEnumerable<double> vKnots, int uDegree, int vDegree, IEnumerable<SurfaceTrim> innerTrims, IEnumerable<SurfaceTrim> outerTrims)
        {
            ControlPoints = new ReadOnlyCollection<Point>(controlPoints.ToList());
            Weights = new ReadOnlyCollection<double>(weights.ToList());
            UKnots = new ReadOnlyCollection<double>(uKnots.ToList());
            VKnots = new ReadOnlyCollection<double>(vKnots.ToList());
            UDegree = uDegree;
            VDegree = vDegree;
            InnerTrims = new ReadOnlyCollection<SurfaceTrim>(innerTrims.ToList());
            OuterTrims = new ReadOnlyCollection<SurfaceTrim>(outerTrims.ToList());
        }

        /***************************************************/
    }
}

