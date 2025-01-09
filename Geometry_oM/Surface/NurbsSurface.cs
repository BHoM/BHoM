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

using System.ComponentModel;
using BH.oM.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BH.oM.Geometry
{
    [Description("A free-form surface constructed as a UV grid of weighted NURBS ControlPoints. A continuous form is generated by approximating a two-directional network of piece-wise polynomial splines across the U and V directions, creating a smooth surface patch." +
                 "\nSupports Inner and Outer Trim Curves which enable greater flexibility in final shape through allowing free-form boundaries to be cut across the underlying UV surface domain." +              
                 "\nA NurbsSurface is immutable as its defining properties are not mutually perpendicular to facilitate robust conversion between platforms." +
                 "\nSee also BH.oM.Geometry.NurbsCurve for more info on non-uniform rational basis spline (or B-spline) weightings and other parameters.")]
    public class NurbsSurface : ISurface, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("An ordered list of three-dimensional points defining the overall surface patch geometry. Each row of Points in the UV grid are listed sequentially as a single vector. The control point locations are approximating, as opposed to interpolating, meaning in the general case the resulting surface will not pass through the control point locations themselves.")]                    
        public virtual ReadOnlyCollection<Point> ControlPoints { get; }

        [Description("A list of scalar factors, one for each ControlPoint. The weights in effect add an additional degree of freedom, allowing control over the relative influence of each control point on the surface shape.")]
        public virtual ReadOnlyCollection<double> Weights { get; }

        [Description("Defines the spans and transition points of the basis functions in the U domain. See also BH.oM.Geometry.NurbsCurve for more info on Knot Vectors.")]
        public virtual ReadOnlyCollection<double> UKnots { get; }

        [Description("Defines the spans and transition points of the basis functions in the V domain. See also BH.oM.Geometry.NurbsCurve for more info on Knot Vectors.")]
        public virtual ReadOnlyCollection<double> VKnots { get; }

        [Description("Sets the degree of the polynomial basis functions in the U direction of the surface patch. This ultimately defines the number of local U ControlPoints that influence a given point of the surface.")]
        public virtual int UDegree { get; }

        [Description("Sets the degree of the polynomial basis functions in the V direction of the surface patch. This ultimately defines the number of local V ControlPoints that influence a given point of the surface.")]
        public virtual int VDegree { get; }

        [Description("Allows definition of a set of free-form shapes to be cut from the underlying Surface.")]
        public virtual ReadOnlyCollection<SurfaceTrim> InnerTrims { get; }

        [Description("Allows definition of free-form external perimeter to the NurbsSurface patch.")]
        public virtual ReadOnlyCollection<SurfaceTrim> OuterTrims { get; }


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






